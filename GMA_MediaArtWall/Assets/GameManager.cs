using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    bool trigger = false;



    // Update is called once per frame
    void Update()
    {

        if (trigger)
        {
            ChangeScene();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeScene();
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Scene2");
    }

}

