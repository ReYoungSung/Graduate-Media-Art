using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ImageChanger : MonoBehaviour
{ 
    [SerializeField]
    VisualEffect VE;
    string number="";


    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeScreen("1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeScreen("2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeScreen("3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeScreen("4");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeScreen("5");
        }
    }

    void ChangeScreen(string number)
    {
        if (number=="1")
        {
            VE.SetInt("ImageNumber", 0);
        }
        else if (number=="2")
        {
            VE.SetInt("ImageNumber", 1);
        }
        else if (number == "3")
        {
            VE.SetInt("ImageNumber", 2);
        }
        else if (number == "4")
        {
            VE.SetInt("ImageNumber", 3);
        }
        else if (number == "5")
        {
            VE.SetInt("ImageNumber", 4);
        }
    }

}
