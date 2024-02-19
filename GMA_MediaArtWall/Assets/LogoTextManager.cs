using UnityEngine;
using UnityEngine.VFX;
using System.Collections.Generic;
using System.Collections;

public class LogoTextManager : MonoBehaviour
{
    public List<VisualEffect> visualEffects = new List<VisualEffect>();

    public List<GameObject> textOfStudentID = new List<GameObject>();

    private int activedLogoNum = 0; 
    private int ColorNum = 4;

    private bool isActivateLogo = false;

    private void Start()
    {
        if(ColorNum == 4)
        {
            activedLogoNum = 0;
            ColorNum = 4;
        }
        isActivateLogo = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateAllVFX();
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartCoroutine(DestroySphereToRadius());
        }

        if (Input.GetKeyDown(KeyCode.Alpha0)) //�ѵ� �ΰ��� ��
        {
            activedLogoNum = 0;
            StartCoroutine(ActivateLogo());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1)) //����߾�
        {
            activedLogoNum = 1;
            StartCoroutine(ActivateLogo());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) //����
        {
            activedLogoNum = 2;
            StartCoroutine(ActivateLogo());
        }
        
        if(Input.GetKeyDown(KeyCode.Q)) //17
        {
            ColorNum = 0;
            ChangeVFXColor();
        }
        else if (Input.GetKeyDown(KeyCode.W)) //18
        {
            ColorNum = 1;
            ChangeVFXColor();
        } 
        else if (Input.GetKeyDown(KeyCode.E)) //19
        {
            ColorNum = 2;
            ChangeVFXColor();
        }
        else if (Input.GetKeyDown(KeyCode.R)) //20
        {
            ColorNum = 3;
            ChangeVFXColor();
        }
        else if (Input.GetKeyDown(KeyCode.T)) //Default
        {
            ColorNum = 4;
            ChangeVFXColor();
        }

        
    }

    IEnumerator ActivateLogo()
    {
        if (isActivateLogo == false)
        {
            SoundManager.instance.PlaySFX("ActiveLogo");
            DeActivateOtherVFX();
            yield return new WaitForSeconds(3f); // 3�ʰ� ���
            ActivateSpecificLogo();
            isActivateLogo = true;
        }
    }

    private void DeActivateOtherVFX() 
    {
        for (int i = 0; i < visualEffects.Count; i++)
        {
            if (i != activedLogoNum) // ���õ� �ΰ� �ƴ� ���
            {
                visualEffects[i].SetInt("LifeTimeBool", 1);
            }
        }
    }

    private void ActivateSpecificLogo()
    {
        visualEffects[activedLogoNum].SetFloat("AnimationValue", 1);
    }
    private void DeActivateSpecificLogo()
    {
        visualEffects[activedLogoNum].SetFloat("AnimationValue", 0);
    }


    private void ActivateAllVFX() 
    { 
        for (int i = 0; i < visualEffects.Count; i++)
        {
            visualEffects[i].SetFloat("AnimationValue", 0);
            visualEffects[i].SetInt("LifeTimeBool", 0);
        }
        isActivateLogo = false; 
    }

    private void DeActivateAllVFX()
    {
        for (int i = 0; i < visualEffects.Count; i++)
        {
            visualEffects[i].SetInt("LifeTimeBool", 1);
        }
    }

    IEnumerator DestroySphereToRadius()  //���ΰ� �ִ� ��ü�� �����ϴ� �ڵ�
    {
        if(ColorNum != 4)
        { 
            SoundManager.instance.PlaySFX("BreakSphere");
            for (int i = 0; i < visualEffects.Count; i++)
            {
                visualEffects[i].SetFloat("Radius", 1);
            }
            yield return new WaitForSeconds(3f);
            DeActivateAllVFX();
            textOfStudentID[ColorNum].SetActive(true);  //�й��� �°� Text�� ����ְ� ���� �ð� �Ŀ� ������
            yield return new WaitForSeconds(4f);
            textOfStudentID[ColorNum].GetComponent<VisualEffect>().SetFloat("AnimationValue", 1);
            yield return new WaitForSeconds(7.5f);
            textOfStudentID[ColorNum].GetComponent<VisualEffect>().SetFloat("AnimationValue", 0);
            ActivateAllVFX();
            yield return new WaitForSeconds(3f);
            textOfStudentID[ColorNum].SetActive(false);
        }
    }

    private void ChangeVFXColor() //�й��� �°� �� �ٲٴ� �Լ�
    {
        for (int i = 0; i < visualEffects.Count; i++)
        {
            visualEffects[i].SetInt("TextureColorNum", ColorNum); 
        }

        ChangeBGMwithColor();
    }

    private void ChangeBGMwithColor() //�й��� �°� BGM �ٲٴ� �Լ�
    {
        int bgmName = ColorNum + 17;
        SoundManager.instance.PlayBGM(bgmName.ToString());
    }
}
