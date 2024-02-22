using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicWanding : MonoBehaviour
{
    [SerializeField] LogoTextManager logoTextManager;
    private int count = 0;
    private int count2 = 0;


    public Transform targetPosition1; // �̵��� ��ǥ ��ġ
    public Transform targetPosition2; // �̵��� ��ǥ ��ġ
    private Vector3 initialPosition; // �ʱ� ī�޶� ��ġ
    private Vector3 targetPositionInitial; // �̵��� ��ǥ ��ġ�� �ʱ� ��ġ
    public GameObject mainCamera;

    void Start()
    {
        initialPosition = mainCamera.transform.localPosition; // �ʱ� ī�޶� ��ġ ����
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

    // StartPoint�� ��ȣ�ۿ��� �� ������ �Լ�
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

    // A�� ��ȣ�ۿ��� �� ������ �Լ�
    void AFunction()
    {
        SoundManager.instance.PlaySFX("InteractionSFX", 0.4f);
        StartCoroutine(logoTextManager.ActivateLogo(1));
    }

    // B�� ��ȣ�ۿ��� �� ������ �Լ�
    void BFunction()
    {
        SoundManager.instance.PlaySFX("InteractionSFX", 0.4f);
        StartCoroutine(logoTextManager.ActivateLogo(2));
    }

    // C�� ��ȣ�ۿ��� �� ������ �Լ�
    void CFunction()
    {
        SoundManager.instance.PlaySFX("InteractionSFX", 0.4f);
        StartCoroutine(logoTextManager.ActivateLogo(0));
    }

    // D�� ��ȣ�ۿ��� �� ������ �Լ�
    void DFunction()
    {
        SoundManager.instance.PlaySFX("InteractionSFX", 0.4f);
        StartCoroutine(logoTextManager.ActivateLogo(3));
    }
}
