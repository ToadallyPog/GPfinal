using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class arrowdamage : MonoBehaviour
{
    public int arrowdamaged;
    public GameObject player;
    public GameObject arrow;
    private float distance;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "enemy" )
        {
            other.gameObject.GetComponent<enemyhealth>().damageenemy(arrowdamaged);
            Destroy(gameObject);        
        }

        if(other.gameObject.tag != "player")
        {
            Destroy(gameObject);
        }
        
        }
    }


