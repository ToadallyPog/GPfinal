using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackcooldown;
    private Animator anim;
    private playermovement PlayerMovement;
    private float cooldowntimer = Mathf.Infinity;

    private void Awake()
    {
        anim.GetComponent<Animator>();
        PlayerMovement = GetComponent<playermovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButton(0) && cooldowntimer > attackcooldown && PlayerMovement.canAttack())
            Attack();

        cooldowntimer += Time.deltaTime;

    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldowntimer = 0;
    }
}
