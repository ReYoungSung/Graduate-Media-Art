using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWanding : MonoBehaviour
{
    [SerializeField] LogoTextManager logoTextManager;
    private int count = 0;
    private bool coolingDown = false;
    private float cooldownDuration = 0.75f; // ��Ÿ��


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

    // StartPoint�� ��ȣ�ۿ��� �� ������ �Լ�
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

    // A�� ��ȣ�ۿ��� �� ������ �Լ�
    void AFunction()
    {
        StartCoroutine(logoTextManager.ActivateLogo(1));
    }

    // B�� ��ȣ�ۿ��� �� ������ �Լ�
    void BFunction()
    {
        StartCoroutine(logoTextManager.ActivateLogo(2));
    }

    // C�� ��ȣ�ۿ��� �� ������ �Լ�
    void CFunction()
    {
        StartCoroutine(logoTextManager.ActivateLogo(0));
    }

    // D�� ��ȣ�ۿ��� �� ������ �Լ�
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
