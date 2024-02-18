using System.Collections;
using UnityEngine;

public class WebcamFrameDiff : MonoBehaviour
{
    [Header("차연산 텍스쳐를 계산하기 위한 인풋텍스쳐")]
    public int dummy;
    
    //웹캠입력
    [Header("RealTime Input Texture")]
    public RenderTexture realTimeInputTexture;

    [Header("이전 ColorMaptTexture")]
    public RenderTexture ColorMaptTexture;

    [Header("이전 ColorMaptTexture")]
    public RenderTexture ColorMaptTexture02;

    public void Start()
    {
        StartCoroutine("GetTexture");
    }
    private IEnumerator GetTexture()
    {
        while(true)
        {
            Graphics.Blit(realTimeInputTexture, ColorMaptTexture);
            yield return new WaitForSeconds(0.03f);
            Graphics.Blit(realTimeInputTexture, ColorMaptTexture02);
            yield return new WaitForSeconds(0.03f);
        }
    }
}
