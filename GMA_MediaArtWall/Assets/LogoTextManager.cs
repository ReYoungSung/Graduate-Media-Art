using UnityEngine;
using UnityEngine.VFX;
using System.Collections.Generic;
using System.Collections;

public class LogoTextManager : MonoBehaviour
{
    public List<VisualEffect> visualEffects = new List<VisualEffect>();

    private int activedLogoNum;
    private int ColorNum;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateAllVFX();
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            DestroySphereToRadius();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0)) //한동 로고일 때
        {
            activedLogoNum = 0;
            StartCoroutine(ActivateLogo());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1)) //숫자 1을 눌렀을 때 
        {
            activedLogoNum = 1;
            StartCoroutine(ActivateLogo());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) //숫자 2을 눌렀을 때
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
        else if (Input.GetKeyDown(KeyCode.T)) //24
        {
            ColorNum = 4;
            ChangeVFXColor();
        }

        
    }

    IEnumerator ActivateLogo()
    {
        DeActivateOtherVFX();
        yield return new WaitForSeconds(3f); // 2초간 대기
        ActivateSpecificLogo();
    }

    private void DeActivateOtherVFX()
    {
        for (int i = 0; i < visualEffects.Count; i++)
        {
            if (i != activedLogoNum) // 선택된 로고가 아닌 경우
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
        DeActivateSpecificLogo();
        for (int i = 0; i < visualEffects.Count; i++)
        {
            visualEffects[i].SetInt("LifeTimeBool", 0);
        }
    }

    private void DestroySphereToRadius()  //가두고 있는 구체를 제거하는 코드
    {
        for (int i = 0; i < visualEffects.Count; i++)
        {
            visualEffects[i].SetFloat("Radius", 1);
        }
    }

    private void ChangeVFXColor()
    {
        for (int i = 0; i < visualEffects.Count; i++)
        {
            visualEffects[i].SetInt("TextureColorNum", ColorNum); 
        }
    }
}
