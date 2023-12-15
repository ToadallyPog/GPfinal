using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gamecontrollerplayname : MonoBehaviour
{

    public string data;

    public TMP_InputField thisname;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetInput() 
    {
        GlobalsController.name = thisname.text;
        Debug.Log(GlobalsController.name);
    }
}
