using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unreal_Screen_Move : MonoBehaviour
{
    float speed = 2f;
    bool isMoving = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            isMoving = true;
        }

        if (isMoving)
        {
            MoveUpSmoothly();
        }
    }

    void MoveUpSmoothly()
    {
        float Y = transform.position.y + speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Y, transform.position.z);

        if (transform.position.y >= 20f)
        {
            isMoving = false;
        }
    }
}
