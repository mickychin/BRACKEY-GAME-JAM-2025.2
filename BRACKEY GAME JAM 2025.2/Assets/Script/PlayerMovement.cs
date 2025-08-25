using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float MoveSpeed;
    [SerializeField] CatchingMenu catchingMenu;

    public bool canMove;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
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
            Debug.Log("SPIDER");

            catchingMenu.gameObject.SetActive(true);
            FindObjectOfType<Spinwheel>().SetRisk(collision.GetComponent<Spider>().Default_Risk); // set risk of the wheel
            canMove = false;
        }
    }
}
