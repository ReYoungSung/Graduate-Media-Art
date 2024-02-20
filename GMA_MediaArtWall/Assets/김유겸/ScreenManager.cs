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
    [SerializeField] private GameObject screen3;
    [SerializeField] private GameObject images;

    [SerializeField] VisualEffect VE1;
    [SerializeField] VisualEffect VE2;
    [SerializeField] VisualEffect VE3;
    [SerializeField] private Transform box1;
    [SerializeField] private Transform spot1;
    [SerializeField] private Transform spot2;
    [SerializeField] private Transform spot3;

    string number = "";
    int count = 0;
    private float deltabox1X;
    private float deltabox1Z;
    float distance1=0, distance2=0, distance3=0;
    bool StartCameraMoving = false;
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


        if(StartCameraMoving)
        {
            AllScreenForward();
        }

        if (!(isMoving))
        {

            distance1 = Vector3.Distance(spot1.position, box1.position);
            distance2 = Vector3.Distance(spot2.position, box1.position);
            distance3 = Vector3.Distance(spot3.position, box1.position);

            if (count == 0)
            {
                if (distance1 >= 1)
                {
                    VE1.SetFloat("SBSize1", 120 - (distance1 * 3));

                }
                else
                {
                    StartCameraMoving = true;
                    count++;
                }
            }

            else if (count == 1)
            {
                if (distance2 >= 1)
                {
                    VE2.SetFloat("SBSize2", 80- distance2 * 3);
                }
                else
                {
                    count++;
                }
            }

            else if (count == 2)
            {
                if (distance3 >= 1)
                {
                    VE2.SetFloat("SBSize3", 80- distance3 * 3);
                }
                else
                {
                    count++;
                }
            }

            else if (count == 3)
            {
                if (distance1 <= 1)
                {
                    count++;
                    StartCoroutine(FallDown());
                }
            }

        }
    }

    void screen1_move()
    {
        //SoundManager.instance.PlaySFX();
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

    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(3f);
        VE3.SetFloat("Gravity", -10);
        yield return new WaitForSeconds(2f);
        images.SetActive(false);
        screen2.SetActive(false);
        yield return new WaitForSeconds(1f);
        VE3.SetFloat("Gravity", 0);
    }

   void AllScreenForward()
    {
        screen2.SetActive(true);
        float screen1_Z = screen1.transform.position.z - speed * Time.deltaTime * 2;
        screen1.transform.position = new Vector3(screen1.transform.position.x, screen1.transform.position.y, screen1_Z);

        float screen2_Z = screen2.transform.position.z - speed * Time.deltaTime * 20;
        screen2.transform.position = new Vector3(screen2.transform.position.x, screen2.transform.position.y, screen2_Z);

        if (screen2_Z <= -1)
        {
            images.SetActive(true);
            StartCameraMoving = false;
        }
    }

    
}

