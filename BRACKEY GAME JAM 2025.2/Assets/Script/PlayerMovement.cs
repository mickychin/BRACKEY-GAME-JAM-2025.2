using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] private float MoveSpeed;
    [SerializeField] CatchingMenu catchingMenu;
    [SerializeField] UI_Inventory uiInventory;
    [SerializeField] GameObject GoNextDayCanvas;

    public bool canMove;
    private Vector2 movement;
    private Inventory inventory;


    // Start is called before the first frame update
    void Start()
    {
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
        //StartCoroutine(LateStart());
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x != 0)
        {
            animator.SetInteger("Walk", 1);
            transform.localScale = new Vector2(movement.x * Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger("Walk", 2);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger("Walk", 3);
        }
        else
        {
            animator.SetInteger("Walk", 0);
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
