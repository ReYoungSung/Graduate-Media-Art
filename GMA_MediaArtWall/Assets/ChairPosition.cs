using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairPosition : MonoBehaviour
{
    Vector3 vec;
    float positionX, positionY, positionZ;

    void Start()
    {

    }

    void Update()
    {
        vec = transform.position;
        positionX = vec.x;
        positionY = vec.y;
        positionZ = vec.z;
    }

}