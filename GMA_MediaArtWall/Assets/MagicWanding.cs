using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWanding : MonoBehaviour
{
    [SerializeField] LogoTextManager logoTextManager;
    private int count = 0;
    private int count2 = 0;


    public Transform targetPosition1; // 이동할 목표 위치
    public Transform targetPosition2; // 이동할 목표 위치
    private Vector3 initialPosition; // 초기 카메라 위치
    private Vector3 targetPositionInitial; // 이동할 목표 위치의 초기 위치
    public GameObject mainCamera;

    void Start()
    {
        initialPosition = mainCamera.transform.localPosition; // 초기 카메라 위치 저장
    }

    public void MoveCamera()
    {
        SoundManager.instance.PlaySFX("InteractionSFX", 0.4f);

        if ((count2+1) % 3 == 0)
        {
            mainCamera.transform.localPosition = initialPosition;
        }
        else if((count2 + 1) % 3 == 1)
        {
            mainCamera.transform.localPosition = targetPosition1.localPosition; ;
        }
        else if ((count2 + 1) % 3 == 2)
        {
            mainCamera.transform.localPosition = targetPosition2.localPosition; ;
        }
        count2++;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartPoint"))
        {
            StartPointFunction();
        }
        else if (other.CompareTag("A"))
        {
            AFunction();
        }
        else if (other.CompareTag("B"))
        {
            BFunction();
        }
        else if (other.CompareTag("C"))
        {
            CFunction();
        }
        else if (other.CompareTag("D"))
        {
            MoveCamera();
        }
        else if(other.CompareTag("ArtTrigger"))
        {
            ArtTriggerFuction();
        }
    }

    // StartPoint와 상호작용할 때 실행할 함수
    void StartPointFunction()
    {
        SoundManager.instance.PlaySFX("InteractionSFX", 0.4f);
        logoTextManager.ChangeVFXColor(count);
        count = (count + 1) % 4;
        logoTextManager.ResetArt(); 
    }

    void ArtTriggerFuction()
    {

        logoTextManager.DestroySphereToRadius();
    }

    // A와 상호작용할 때 실행할 함수
    void AFunction()
    {
        SoundManager.instance.PlaySFX("InteractionSFX", 0.4f);
        StartCoroutine(logoTextManager.ActivateLogo(1));
    }

    // B와 상호작용할 때 실행할 함수
    void BFunction()
    {
        SoundManager.instance.PlaySFX("InteractionSFX", 0.4f);
        StartCoroutine(logoTextManager.ActivateLogo(2));
    }

    // C와 상호작용할 때 실행할 함수
    void CFunction()
    {
        SoundManager.instance.PlaySFX("InteractionSFX", 0.4f);
        StartCoroutine(logoTextManager.ActivateLogo(0));
    }

    // D와 상호작용할 때 실행할 함수
    void DFunction()
    {
        SoundManager.instance.PlaySFX("InteractionSFX", 0.4f);
        StartCoroutine(logoTextManager.ActivateLogo(3));
    }
}
