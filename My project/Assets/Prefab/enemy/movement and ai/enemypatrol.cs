using System;
using UnityEngine;

public class enemypatrol : MonoBehaviour
{
    public GameObject player;
    private float distance;

    private float snapshotX;
    private int stuckcount = 0;

    Rigidbody2D rb;


    [Header("Patrol Points")]
    [SerializeField] private Transform leftedge;
    [SerializeField] private Transform rightedge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("idle behavior")]
    [SerializeField] private float idleduration;
    private float idletimer;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (Math.Floor(transform.position.x) == Math.Floor(snapshotX))
        {

            stuckcount++;
            Debug.Log(stuckcount + "enemy");
            if (stuckcount >= 10)
            {
                //transform.position = new Vector2(transform.position.x-5, transform.position.y);
                //transform.position = new Vector2(transform.position.x-.1f, transform.position.y+.1f);
                rb.velocity = new Vector2(2, 10);
                stuckcount = 0;
            }
        }
        else
        {
            stuckcount = 0;
        }
        snapshotX = transform.position.x;
        if (distance < 10)
        {
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //moves enemy towards player
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            // transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }


        if (movingLeft)
        {
            if (enemy.position.x >= leftedge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                directionchange();
            }

        }
        else
        {
            if (enemy.position.x <= rightedge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                directionchange();
            }
        }


    }
    private void directionchange()
    {
        anim.SetBool("moving", false);

        idletimer += Time.deltaTime;

        if (idletimer > idleduration)
        {
            movingLeft = !movingLeft;
        }


    }

    private void MoveInDirection(int _direction)
    {
        idletimer = 0;
        anim.SetBool("moving", true);
        //make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        //then make enemy move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }

    private void OnDisable()
    {
        if (anim != null)
        {
            anim.SetBool("moving", false);
        }
    }
}