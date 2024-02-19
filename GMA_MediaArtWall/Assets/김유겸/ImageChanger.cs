using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ImageChanger : MonoBehaviour
{
    [SerializeField]
    VisualEffectAsset VE_Asset;
    VisualEffectAsset VE_Asset_0;
    [SerializeField]
    VisualEffectAsset VE_Asset_1;
    [SerializeField]
    VisualEffectAsset VE_Asset_2;

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
        if (Input.GetKeyDown(KeyCode.Alpha1) && VE_Asset_0 != VE.visualEffectAsset) //0누르면 변경
        {
            ChangeVE("1");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && VE_Asset_1 != VE.visualEffectAsset) //1누르면 변경
        {
            ChangeVE("2");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && VE_Asset_2 != VE.visualEffectAsset) //2누르면 변경
        {
            ChangeVE("3");
        }
    }

    void ChangeVE(string number)
    {
        if (number == "1")
        {
            VE.visualEffectAsset = VE_Asset_0;
        }

        else if (number == "2")
        {
            VE.visualEffectAsset = VE_Asset_1;
        }

        else if (number == "3")
        {
            VE.visualEffectAsset = VE_Asset_2;
        }

    }
}
