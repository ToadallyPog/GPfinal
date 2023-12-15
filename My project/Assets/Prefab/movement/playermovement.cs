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
    float ydirection = 0.0f;
    bool isgrounded = false;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private void Awake()
    {
        //references for animator
        anim = GetComponent<Animator>();
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

        anim.SetBool("run", xdirection != 0);
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(xdirection * movespeed,rb.velocity.y);
        if (spaceBarDown)
        {
            anim.SetBool("jump", ydirection > 0);
           
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

        private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return xdirection == 0  && !onWall();
    }
}
