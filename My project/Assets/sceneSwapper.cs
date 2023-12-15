using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwapper : MonoBehaviour
{

    public string scenename;
    private bool reqLevelComplete;

    



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
            switch (scenename) {
                case "Hub World":
                    reqLevelComplete = GlobalsController.defaultComplete;
                    break;
                case "_wild forest cave":
                    reqLevelComplete = GlobalsController.forestTwoComplete;
                    break;
                case "_lost mine cave":
                    reqLevelComplete = GlobalsController.mineTwoComplete;
                    break;
                case "_icey cave":
                    reqLevelComplete = GlobalsController.iceTwoComplete;
                    break;
                default:
                    reqLevelComplete = false;
                    
                    break;
            }

            if (reqLevelComplete)
                SceneManager.LoadScene(scenename);
        }
    }
}
