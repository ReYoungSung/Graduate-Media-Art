using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ImageChanger : MonoBehaviour
{
    [SerializeField]
    VisualEffectAsset VE_Asset;

    VisualEffect VE;


    void Start()
    {
        VE=GetComponent<VisualEffect>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) && VE_Asset != null)
        {
            ChangeVE();
        }
    }

    void ChangeVE()
    {
        VE.Stop();

        VE.visualEffectAsset = VE_Asset;

        VE.Play();
    }
}
