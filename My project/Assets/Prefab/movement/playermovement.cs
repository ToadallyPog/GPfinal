using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{


    bool spaceBarDown = false;

    float jumpspeed = 12.0f;
    float movespeed = 9.0f;
    Rigidbody2D rb;
    float xdirection = 0.0f;
    bool isgrounded = false;


    private void Awake()
    {
        
    }

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
        if(xdirection > 0) {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (xdirection < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
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
        }else if (collision.gameObject.CompareTag("spike"))
        {
            GameManager.Instance.healthPoints -= 1;
            if(GameManager.Instance.healthPoints < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isgrounded = false;
            GameManager.Instance.healthPoints -= 1;
           
            
        }
    }
}
