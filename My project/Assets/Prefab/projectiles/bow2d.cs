using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow2d : MonoBehaviour
{
    public Transform arrowspawnpoint;
    public GameObject arrowprefab;
    public float arrowspeed = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            var arrow = Instantiate(arrowprefab, arrowspawnpoint.position, arrowspawnpoint.rotation);

            // Set arrow direction based on player's look direction
            Vector2 arrowDirection = arrowspawnpoint.right;

            // Flip the arrow sprite if moving to the left
            if (arrowDirection.x < 0)
            {
              arrowDirection  =  arrow.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                arrow.transform.localScale = new Vector3(1, 1, 1);
            }

            arrow.GetComponent<Rigidbody2D>().velocity = arrowDirection * arrowspeed;
        }
    }
}
