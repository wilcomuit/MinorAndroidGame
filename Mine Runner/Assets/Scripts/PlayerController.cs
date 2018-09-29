using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using g = Globals;

public class PlayerController : MonoBehaviour {

    public static float speed;
    Animator animator;
    SpriteRenderer spriteRenderer;
    bool isFacingRight = true;
    bool isGrounded = false;
    bool animatedMoney = false;
    private Data data;

    public static List<Vector3> ghostList = new List<Vector3>();

    public static List<float> ghostListX = new List<float>();
    public static List<float> ghostListY = new List<float>();
    public static List<bool> ghostListFlip = new List<bool>();
    public static List<float> ghostListSpeed = new List<float>();

    public static int moneyMultiplier;
    public static int speedMultiplier;

    GameObject abilityButton;
    BoxCollider2D boxCollider;
    Rigidbody2D rigidBody;
    GameObject animatedMoneyInstance;

    private bool usedAbility = false;
    private float timer = 0;
    private float timerMax = 0;
    private float timerAbility = 0;
    private float timerMaxAbility = 0;
    private float abilityCooldown = 0f;

    void Start () {
        data = DataDeserializer.Deserialize();
        ghostList = new List<Vector3>();
        ghostListX = new List<float>();
        ghostListY = new List<float>();
        ghostListFlip = new List<bool>();
        ghostListSpeed = new List<float>();
        speed = g.player_Speed;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moneyMultiplier = data.getMoneyMultiplier();
        speedMultiplier = data.getSpeedMultiplier();
        abilityButton = GameObject.Find("Dash");
        boxCollider = GetComponent<BoxCollider2D>();
        animatedMoneyInstance = GameObject.Find("AnimatedMoney");
        rigidBody = GetComponent<Rigidbody2D>();
        GetComponent<AudioSource>().volume = ((float)data.getVolume() / 100);

        switch (data.getSelectedAbility())
        {
            case 1:
                abilityCooldown = 0f;
                break;
            case 2:
                abilityCooldown = 5f;
                break;
            case 3:
                abilityCooldown = 5f;
                break;
            default:
                break;
        }

    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        foreach (Touch touch in Input.touches)
        {
            RectTransform transf = abilityButton.GetComponent<RectTransform>();
            if (touch.position.x < transf.position.x || touch.position.x > transf.position.x + transf.sizeDelta.x ||
                touch.position.y > transf.position.y || touch.position.y < transf.position.y - transf.sizeDelta.y)
            {
                if (touch.position.x < Screen.width / 2)
                {
                    horizontal = -0.75f;
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    horizontal = 0.75f;
                }
            }
        }
        if (!GameController.paused)
        {
            if ((horizontal < 0 && isFacingRight || horizontal > 0 && !isFacingRight) && GameController.gameType != 2)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                isFacingRight = !isFacingRight;
            }
            else if (((horizontal * -1) < 0 && isFacingRight || (horizontal * -1) > 0 && !isFacingRight) && GameController.gameType == 2)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                isFacingRight = !isFacingRight;
            }
            ghostListX.Add(transform.position.x);
            ghostListY.Add(transform.position.y);
            switch (GameController.gameType)
            {
                case 2:
                    animator.SetFloat("speed", Math.Abs(horizontal));
                    transform.Translate((horizontal * speed * GetSpeed(speedMultiplier))*2 * -1, 0, 0);
                    ghostListSpeed.Add(horizontal * -1);
                    break;
                case 3:
                    float acceleration = Input.acceleration.x;
                    acceleration = (acceleration > 0.35f) ? 0.35f : acceleration;
                    acceleration = (acceleration < -0.35f) ? -0.35f : acceleration;
                    animator.SetFloat("speed", Math.Abs(acceleration));
                    if (acceleration < 0 && isFacingRight || acceleration > 0 && !isFacingRight)
                    {
                        spriteRenderer.flipX = !spriteRenderer.flipX;
                        isFacingRight = !isFacingRight;
                    }
                    ghostListSpeed.Add(acceleration);
                    transform.Translate(((acceleration * 5) * speed * GetSpeed(speedMultiplier)), 0, 0);
                    break;
                default:
                    ghostListSpeed.Add(horizontal);
                    animator.SetFloat("speed", Math.Abs(horizontal));
                    transform.Translate((horizontal * speed * GetSpeed(speedMultiplier))*2, 0, 0);
                    break;
            }

            ghostListFlip.Add(isFacingRight);
        }
    }

    public static float GetSpeed(int multiplier)
    {
        switch (multiplier)
        {
            case 2:
                return 1.30f;
            case 3:
                return 1.35f;
            default:
                return 1.25f;
        }
    }

    void Update () {
        if (animatedMoney && Waited(0.05f))
        {
            foreach (Transform transform in GameObject.Find("AnimatedMoney").transform)
            {
                if (transform.name == "Icon")
                {
                    transform.localScale = new Vector3(1f, 1f, 1);
                }
                else if (transform.name == "Amount")
                {
                    transform.GetComponent<Text>().fontSize = 30;
                }

            }
            animatedMoney = false;
        }
        if (usedAbility && Waited(abilityCooldown))
        {
            GameObject.Find("Dash").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            usedAbility = false;
        }
    }

    bool Waited(float seconds)
    {
        timerMax = seconds;
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            timer = 0;
            timerMax = 0;
            return true;
        }
        return false;
    }

    bool WaitedForAbility(float seconds)
    {
        timerMaxAbility = seconds;
        timerAbility += Time.deltaTime;
        if (timerAbility >= timerMaxAbility)
        {
            timerAbility = 0;
            timerMaxAbility = 0;
            return true;
        }
        return false;
    }

    void Ability(GameObject collider)
    {
        if (usedAbility || !isGrounded || GameController.paused) return;
        GameObject.Find("Dash").GetComponent<Image>().color = new Color32(255,255,255,100);
        switch (data.getSelectedAbility())
        {
            case 1:
                Jump();
                break;
            case 2:
                Dash(collider);
                break;
            case 3:
                PickupAllInView();
                break;
            default:
                break;
        }
        usedAbility = true;
    }

    void Dash(GameObject collider)
    {
        transform.position = new Vector3(gameObject.transform.position.x, collider.transform.position.y - (boxCollider.size.y/2), gameObject.transform.position.z);
        GameController.amountOfPlatforms += 1;
        GameController.updateFloorCount();
    }

    void Jump()
    {
        rigidBody.AddForce(new Vector3(0, 3, 0), ForceMode2D.Impulse);
    }

    void PickupAllInView()
    {
        GameObject[] goldPickups = GameObject.FindGameObjectsWithTag("Pickup");
        foreach(GameObject pickup in goldPickups)
        {
            if (!pickup.name.Contains("Placeholder"))
            {
                if (pickup.GetComponent<Renderer>().IsVisibleFrom(Camera.main))
                {
                    PickupGold(pickup);
                }
            }       
        }

        GameObject[] diamondPickups = GameObject.FindGameObjectsWithTag("Pickup2");
        foreach (GameObject pickup in diamondPickups)
        {
            if (pickup.GetComponent<Renderer>().IsVisibleFrom(Camera.main))
            {
                PickupDiamond(pickup);
            }
        }
        AnimateMoney();
        GetComponent<AudioSource>().Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            if (!other.name.Contains("Placeholder"))
            {
                if (data.getSelectedAbility() == 5)
                {
                    PickupLine(other.gameObject);
                }
                else
                {
                    PickupGold(other.gameObject);
                }
                AnimateMoney();
                GetComponent<AudioSource>().Play();
            }
        } else if (other.gameObject.tag == "Pickup2")
        {
            if (data.getSelectedAbility() == 5)
            {
                PickupLine(other.gameObject);
            }
            else
            {
                PickupDiamond(other.gameObject);
            }
            AnimateMoney();
            GetComponent<AudioSource>().Play();
        } else if (other.gameObject.tag == "Platform")
        {
            isGrounded = true;
            abilityButton.GetComponent<Button>().onClick.AddListener(() => Ability(other.gameObject));
        }
    }

    void PickupLine(GameObject other)
    {
        if (data.getSelectedAbility() == 5)
        {
            Transform parent = other.transform.parent;
            foreach (Transform child in parent)
            {
                if (child.tag == "Pickup")
                {
                    PickupGold(child.gameObject);
                }
                else if (child.tag == "Pickup2")
                {
                    PickupDiamond(child.gameObject);
                }
            }
        }
    }

    void PickupGold(GameObject gold)
    {
        Destroy(gold);
        GameController.score += GetGoldValue(moneyMultiplier);
        GameController.updateScore();
    }

    void PickupDiamond(GameObject diamond)
    {
        Destroy(diamond);
        GameController.score += GetDiamondValue(moneyMultiplier);
        GameController.updateScore();
    }

    void AnimateMoney()
    {
        foreach (Transform transform in animatedMoneyInstance.transform)
        {
            if (transform.name == "Icon")
            {
                transform.localScale = new Vector3(1.3f, 1.3f, 1);
            }
            else if (transform.name == "Amount")
            {
                transform.GetComponent<Text>().fontSize = 35;
            }
        }
        animatedMoney = true;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            if (data.getSelectedAbility() == 4)
            {
                speed = g.obstacle_Speed * 1.1f;
            }
            else {
                speed = g.obstacle_Speed * 1;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                speed = g.player_Speed;
                break;
            case "Platform":
                abilityButton.GetComponent<Button>().onClick.RemoveAllListeners();
                isGrounded = false;
                break;
            default:
                break;
        }
    }

    public static int GetDiamondValue(int moneyMultiplier)
    {
        switch (moneyMultiplier)
        {
            case 1:
                return 10;
            case 2:
                return 10;
            case 3:
                return 15;
            case 4:
                return 15;
            case 5:
                return 20;
            case 6:
                return 20;
            case 7:
                return 25;
            default:
                return 10;
        }
    }
    public static int GetGoldValue(int moneyMultiplier)
    {
        switch (moneyMultiplier)
        {
            case 1:
                return 2;
            case 2:
                return 3;
            case 3:
                return 3;
            case 4:
                return 4;
            case 5:
                return 4;
            case 6:
                return 5;
            case 7:
                return 5;
            default:
                return 2;
        }
    }
}
