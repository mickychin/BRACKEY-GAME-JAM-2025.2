using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] private float MoveSpeed;
    [SerializeField] CatchingMenu catchingMenu;
    [SerializeField] UI_Inventory uiInventory;
    [SerializeField] GameObject GoNextDayCanvas;
    [SerializeField] private GameObject HeadLight_Mask;
    [SerializeField] private Light2D HeadLight_Light;
    [SerializeField] private float HeadLightRadius;
    [SerializeField] private GameObject FlashLight_Mask;
    [SerializeField] private Light2D FlashLight_Light;

    public bool canMove;
    private Vector2 movement;
    private Inventory inventory;
    AudioSource audioSource;

    [SerializeField] AudioClip[] WalkSFX;
    [SerializeField] private float StepsTakeToMakeWalkSound;
    private float step;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        if(FindObjectOfType<GameMaster>().MainInventory != null)
        {
            inventory = FindObjectOfType<GameMaster>().MainInventory;
        }
        else
        {
            inventory = new Inventory();
        }
        uiInventory.SetInventory(inventory);

        foreach (Item item in FindObjectOfType<GameMaster>().MainInventory.GetItemLists()) // check through every item in inventory
        {
            if(item.itemType == Item.ItemType.Headlight) // check if we have headlight
            {
                //have head light
                HeadLight_Light.pointLightOuterRadius = HeadLightRadius;
                HeadLight_Mask.transform.localScale = new Vector2(HeadLightRadius, HeadLightRadius);
            }
            if (item.itemType == Item.ItemType.Flashlight) // check if we have flashlight
            {
                //have flashlight
                FlashLight_Mask.SetActive(true);
                FlashLight_Light.gameObject.SetActive(true);
            }
        }
        //StartCoroutine(LateStart());
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x != 0) //walking horizontally
        {
            TakeStep();
            animator.SetInteger("Walk", 1);
            transform.localScale = new Vector2(movement.x * Mathf.Abs(transform.localScale.x), transform.localScale.y);
            FlashLight_Light.transform.localEulerAngles = new Vector3(0, 0, 0);
            FlashLight_Mask.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (movement.y < 0) //walking down
        {
            TakeStep();
            animator.SetInteger("Walk", 2);
            FlashLight_Light.transform.localEulerAngles = new Vector3(0, 0, -90);
            FlashLight_Mask.transform.localEulerAngles = new Vector3(0, 0, -90);
        }
        else if (movement.y > 0) //walking up
        {
            TakeStep();
            animator.SetInteger("Walk", 3);
            FlashLight_Light.transform.localEulerAngles = new Vector3(0, 0, 90);
            FlashLight_Mask.transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        else //not walking
        {
            animator.SetInteger("Walk", 0);
        }
    }

    private void TakeStep()
    {
        step += Time.deltaTime;
        if(step > StepsTakeToMakeWalkSound)
        {
            // take a step
            step = 0;
            float minPitch = 0.9f;
            float maxPitch = 1.1f;
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.clip = WalkSFX[Random.Range(0, WalkSFX.Length)];
            audioSource.Play();
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movement.normalized * MoveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spider"))
        {
            // collide with spider
            //Debug.Log("SPIDER");

            FindObjectOfType<GameMusic>().PlayEncounterMusic();
            catchingMenu.gameObject.SetActive(true);
            catchingMenu.SetSpiderImage(collision.GetComponent<Spider>().Render.sprite); // Set the spider Image in the bg
            FindObjectOfType<Spinwheel>().SetSpider(collision.GetComponent<Spider>()); // set risk of the wheel
            canMove = false;
        }

        if (collision.CompareTag("Van"))
        {
            // collide with van
            GoNextDayCanvas.SetActive(true);
        }
    }

    public void addItemToINV(Item item)
    {
        inventory.AddItem(item);
        FindObjectOfType<GameMaster>().MainInventory = inventory;
    }

    public void removeItemFromINV(Item item)
    {
        inventory.RemoveItem(item);
        FindObjectOfType<GameMaster>().MainInventory = inventory;
    }

    public bool isIteminInventory(Item item)
    {
        foreach(Item items in inventory.GetItemLists())
        {
            if(items.itemType == item.itemType)
            {
                return true;
            }
        }
        return false;
    }

    public void PassOut()
    {
        //reduce money maybe
        FindObjectOfType<GameOverAndPassOut>().LoadPassout();
    }

    public void Die()
    {
        FindObjectOfType<GameMaster>().CurrentMoney = 0; //reset money when die
        FindObjectOfType<GameMaster>().MainInventory = new Inventory(); //reset money when die
        FindObjectOfType<GameOverAndPassOut>().LoadGameOver();
    }
}
