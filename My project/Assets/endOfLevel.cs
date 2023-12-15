using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endOfLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "_forestOne":
                    GlobalsController.forestOneComplete = true; break;
                case "_forestTwo":
                    GlobalsController.forestTwoComplete = true; break;
                case "_mineOne":
                    GlobalsController.mineOneComplete = true; break;
                case "_mineTwo":
                    GlobalsController.mineTwoComplete = true; break;
                case "_wild forest cave":
                    GlobalsController.forestCaveComplete = true; break;
                case "_lost mine cave":
                    GlobalsController.mineCaveComplete = true; break;
                case "_icey cave":
                    GlobalsController.IceCaveComplete = true;
                    break;
                default:

                    break;
            }

            Destroy(this.GameObject());
        }
    }

}
