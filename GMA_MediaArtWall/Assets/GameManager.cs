using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool trigger = false; //���� ��� ������ ������  Can't choose trigger yet. Add later.
    // Start is called before the first frame update
    void Start()
    {

    }

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

