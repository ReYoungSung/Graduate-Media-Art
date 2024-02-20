using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ScreenManager : MonoBehaviour
{
    float speed = 4f;
    bool isMoving = false;
    [SerializeField] private GameObject screen1;
    [SerializeField] private GameObject screen2;


    [SerializeField] VisualEffect VE1;
    [SerializeField] VisualEffect VE2;
    [SerializeField] private Transform box1;
    [SerializeField] private Transform spot1;
    [SerializeField] private Transform spot2;
    [SerializeField] private Transform spot3;

    string number = "";
    int count = 0;
    private float deltabox1X;
    private float deltabox1Z;
    float distance1=0, distance2=0, distance3=0;
    void Start()
    {
        isMoving = true;

    }
    void Update()
    {
        if (isMoving)
        {
            screen1_move();
        }



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




        distance1 = Vector3.Distance(spot1.position, box1.position);
        distance2 = Vector3.Distance(spot2.position, box1.position);
        distance3 = Vector3.Distance(spot3.position, box1.position);

        VE1.SetFloat("SBSize1", 20 + distance1 * 20);
        VE2.SetFloat("SBSize2", 20 + distance2 * 20);
        VE2.SetFloat("SBSize3", 20 + distance2 * 20);
    }

    void screen1_move()
    {
        float Y = screen1.transform.position.y - speed * Time.deltaTime;
        screen1.transform.position = new Vector3(screen1.transform.position.x, Y, screen1.transform.position.z);

        if (screen1.transform.position.y <= 0)
        {
            isMoving = false;
        }
    }



    void ChangeScreen(string number)
    {
        if (number == "1")
        {
            VE2.SetInt("ImageNumber", 0);
        }
        else if (number == "2")
        {
            VE2.SetInt("ImageNumber", 1);
        }
        else if (number == "3")
        {
            VE2.SetInt("ImageNumber", 2);
        }
    }
}

