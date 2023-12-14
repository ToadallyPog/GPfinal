using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playermovement : MonoBehaviour
{


    bool spaceBarDown = false;

    float jumpspeed = 10.0f;
    float movespeed = 5.0f;
    Rigidbody2D rb;
    float xdirection = 0.0f;
    bool isgrounded = false;
    
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isgrounded && Input.GetButtonDown("Jump"))
        {
            spaceBarDown = true;
        }

        xdirection = Input.GetAxisRaw("Horizontal");
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xdirection * movespeed,rb.velocity.y);
        if (spaceBarDown)
        {
            spaceBarDown = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isgrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isgrounded = false;
        }
    }
}
