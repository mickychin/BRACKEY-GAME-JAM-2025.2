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

    public bool canMove;
    private Vector2 movement;
    private Inventory inventory;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        inventory = new Inventory();
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
            FindObjectOfType<Spinwheel>().SetSpider(collision.GetComponent<Spider>()); // set risk of the wheel
            canMove = false;
        }
    }

    public void addItemToINV(Item item)
    {
        inventory.AddItem(item);
    }

    public void removeItemFromINV(Item item)
    {
        inventory.RemoveItem(item);
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
}
