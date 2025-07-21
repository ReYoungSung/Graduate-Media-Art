using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneStick : MonoBehaviour
{
    [SerializeField] private Transform MagicWand;

    Vector3 OriginWandPosition;
    Vector3 currentPosition;

    void Start()
    {
        // Store the initial position of the MagicWand
        OriginWandPosition = MagicWand.position;

        currentPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        

        Vector3 DiffWandPosition = OriginWandPosition - MagicWand.position;


        transform.position = new Vector3(currentPosition.x - DiffWandPosition.x, currentPosition.y - DiffWandPosition.y, currentPosition.z);
    }
}