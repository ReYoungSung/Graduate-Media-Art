using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ImageChanger : MonoBehaviour
{
    [SerializeField]
    VisualEffect VE;

    string number = "";
    int count = 0;
    Vector3 vec1 = new Vector3(-13, 0, -20);
    Vector3 vec2 = new Vector3(12.5f, 0, -20);

    void Start()
    {
        VE.SetVector3("ScreenBreaker", vec1);
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenBreak();
        }
    }

    void ChangeScreen(string number)
    {
        if (number == "1")
        {
            VE.SetInt("ImageNumber", 0);
        }
        else if (number == "2")
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

    void ScreenBreak()
    {
        VE.SetInt("SBSize", 20);
        if (count == 0)
        {
            VE.SetInt("SBSize", 50);
            count++;
        }
        else if (count == 1)
        {
            VE.SetVector3("ScreenBreaker", vec2);
            VE.SetInt("SBSize", 50);
        }
    }
}
