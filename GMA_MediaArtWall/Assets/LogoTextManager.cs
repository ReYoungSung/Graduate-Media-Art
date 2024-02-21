using UnityEngine;
using UnityEngine.VFX;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LogoTextManager : MonoBehaviour
{
    public List<VisualEffect> visualEffects = new List<VisualEffect>();

    public List<GameObject> textOfStudentID = new List<GameObject>();

    private int activedLogoNum = 0; 
    private int ColorNum = 4;

    private bool isActivateLogo = false;

    [SerializeField] private Transform busBox;
    [SerializeField] private Transform sartPoint;
    [SerializeField] private Transform magicWand;
    float distance1 = 0, distance2 = 0, distance3 = 0;
    private bool isLoadNextScene = false;

    private void Start()
    {
        SoundManager.instance.SetBGMVolume(1);
        if (ColorNum == 4)
        {
            activedLogoNum = 0;
            ColorNum = 4;
        }
        isActivateLogo = false;
    }

    void Update()
    {
        distance1 = Vector3.Distance(sartPoint.position, busBox.position);
        if (distance1 < 1 && !isLoadNextScene)
        {
            StartCoroutine(ChangeScene());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroySphereToRadius();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0)) //한동 로고일 때
        {
            StartCoroutine(ActivateLogo(0));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1)) //고생했어
        {
            StartCoroutine(ActivateLogo(1));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) //말씀
        {
            StartCoroutine(ActivateLogo(2));
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            StartCoroutine(ActivateStudentIDLogo()); 
        }

        if (Input.GetKeyDown(KeyCode.Q)) //17
        {
            ChangeVFXColor(0);
        }
        else if (Input.GetKeyDown(KeyCode.W)) //18
        {
            ChangeVFXColor(1);
        } 
        else if (Input.GetKeyDown(KeyCode.E)) //19
        {
            ChangeVFXColor(2);
        }
        else if (Input.GetKeyDown(KeyCode.R)) //20
        {
            ChangeVFXColor(3);
        }
        else if (Input.GetKeyDown(KeyCode.T)) //Default
        {
            ChangeVFXColor(4);
        }
    }

    IEnumerator ActivateLogo(int num)
    {
        if (isActivateLogo == false)
        {
            isActivateLogo = true;
            activedLogoNum = num;
            SoundManager.instance.PlaySFX("ActiveLogo");
            DeActivateOtherVFX();
            yield return new WaitForSeconds(3f); // 3초간 대기
            visualEffects[activedLogoNum].SetFloat("AnimationValue", 1);
            visualEffects[activedLogoNum].SetInt("SpawnRate", 50000);
            yield return new WaitForSeconds(10f);
            visualEffects[activedLogoNum].SetInt("SpawnRate", 10000);
                        
            ActivateAllVFX();
        }
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

    private void ActivateAllVFX() 
    {
        SoundManager.instance.PlaySFX("DeActiveLogo");
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

    private void DestroySphereToRadius()  //가두고 있는 구체를 제거하는 코드
    {
        if(ColorNum != 4)
        { 
            SoundManager.instance.PlaySFX("BreakSphere");
            for (int i = 0; i < visualEffects.Count; i++)
            {
                visualEffects[i].SetFloat("Radius", 1);
            }
            
            Invoke("ChangeBGM",2f); 

            StartCoroutine(ActivateStudentIDLogo());
        }
    }

    IEnumerator ActivateStudentIDLogo()
    {
        if (isActivateLogo == false)
        {
            isActivateLogo = true; 
            DeActivateAllVFX();
            textOfStudentID[ColorNum].SetActive(true);  //학번에 맞게 Text를 띄워주고 일정 시간 후에 지워줌
            textOfStudentID[ColorNum].GetComponent<VisualEffect>().SetInt("LifeTimeBool", 0);
            yield return new WaitForSeconds(4f);
            SoundManager.instance.PlaySFX("ActiveLogo");
            textOfStudentID[ColorNum].GetComponent<VisualEffect>().SetFloat("AnimationValue", 1);
            yield return new WaitForSeconds(2f);
            textOfStudentID[ColorNum].transform.GetChild(0).gameObject.SetActive(true);
            textOfStudentID[ColorNum].transform.GetChild(0).GetComponent<VisualEffect>().SetInt("LifeTimeBool", 0);
            yield return new WaitForSeconds(9f);
            textOfStudentID[ColorNum].transform.GetChild(0).GetComponent<VisualEffect>().SetInt("LifeTimeBool", 1);
            yield return new WaitForSeconds(1f);
            textOfStudentID[ColorNum].GetComponent<VisualEffect>().SetFloat("AnimationValue", 0);
            textOfStudentID[ColorNum].GetComponent<VisualEffect>().SetInt("LifeTimeBool", 1);
            ActivateAllVFX();
            yield return new WaitForSeconds(5f);
            textOfStudentID[ColorNum].SetActive(false);
            textOfStudentID[ColorNum].transform.GetChild(0).gameObject.SetActive(false);
            isActivateLogo = false; 
        }
    }

    private void ChangeVFXColor(int num) //학번에 맞게 색 바꾸는 함수
    {
        if(isActivateLogo == false)
        {
            ColorNum = num;
            for (int i = 0; i < visualEffects.Count; i++)
            {
                visualEffects[i].SetInt("TextureColorNum", ColorNum); 
            }
        }
    }

    private void ChangeBGM() //학번에 맞게 BGM 바꾸는 함수
    {
        int bgmName = ColorNum + 17;
        SoundManager.instance.PlayBGM(bgmName.ToString());
    }

    IEnumerator ChangeScene()
    {
        isLoadNextScene = true;
        DeActivateAllVFX();
        yield return new WaitForSeconds(1f);
        SoundManager.instance.PlaySFX("BusStart");
        SoundManager.instance.StopBGM();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("GMA_BLock_Art_Wall");
    } 
}
