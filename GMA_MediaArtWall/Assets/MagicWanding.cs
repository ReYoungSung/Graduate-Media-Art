using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWanding : MonoBehaviour
{
    [SerializeField] LogoTextManager logoTextManager;
    private int count = 0;
    private bool coolingDown = false;
    private float cooldownDuration = 0.75f; // 쿨타임


    void OnTriggerEnter(Collider other)
    {
        if (!coolingDown)
        {
            if (other.CompareTag("StartPoint"))
            {
                StartPointFunction();
                StartCoroutine(StartCooldown());
            }
            else if (other.CompareTag("A"))
            {
                AFunction();
                StartCoroutine(StartCooldown());
            }
            else if (other.CompareTag("B"))
            {
                BFunction();
                StartCoroutine(StartCooldown());
            }
            else if (other.CompareTag("C"))
            {
                CFunction();
                StartCoroutine(StartCooldown());
            }
            else if (other.CompareTag("D"))
            {
                DFunction();
                StartCoroutine(StartCooldown());
            }
            else if (other.CompareTag("ArtTrigger"))
            {
                ArtTriggerFuction();
                StartCoroutine(StartCooldown());
            }
        }
    }

    // StartPoint와 상호작용할 때 실행할 함수
    void StartPointFunction()
    {
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
        StartCoroutine(logoTextManager.ActivateLogo(1));
    }

    // B와 상호작용할 때 실행할 함수
    void BFunction()
    {
        StartCoroutine(logoTextManager.ActivateLogo(2));
    }

    // C와 상호작용할 때 실행할 함수
    void CFunction()
    {
        StartCoroutine(logoTextManager.ActivateLogo(0));
    }

    // D와 상호작용할 때 실행할 함수
    void DFunction()
    {
        StartCoroutine(logoTextManager.ActivateLogo(3));
    }

    IEnumerator StartCooldown()
    {
        coolingDown = true;
        yield return new WaitForSecondsRealtime(cooldownDuration);
        coolingDown = false;
    }
}
