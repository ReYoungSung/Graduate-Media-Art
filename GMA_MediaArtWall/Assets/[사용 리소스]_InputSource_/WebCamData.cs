using UnityEngine;


//웹캠으로 부터 데이터 가져오는 샘플코드
public class WebCamData : MonoBehaviour
{
    [Header("---Get Texture From WebCam---")]
    public int dummy;
    [Header("UsingWebCamIndex")]
    public int CameraIndex;
    [Header("Cam Input Texture")]
    public RenderTexture targetTexture;
    public int width = 1920, height = 1080, fps = 30;
    int prevIndex;
    WebCamTexture webcamTexture;
    void Start()
    {
        prevIndex = CameraIndex;
        SetWebCamTexture(CameraIndex);
    }
    void Update()
    {
        if (CameraIndex != prevIndex)
        {
            SetWebCamTexture(CameraIndex);
        }
        Graphics.Blit(webcamTexture, targetTexture);
        prevIndex = CameraIndex;
    }
    void SetWebCamTexture(int index)
    {
        if (webcamTexture != null && webcamTexture.isPlaying) webcamTexture.Stop();
        WebCamDevice[] devices = WebCamTexture.devices;
        try
        {
            webcamTexture = new WebCamTexture(devices[index].name, this.width, this.height, this.fps);
        }
        catch (System.Exception e)
        {
            webcamTexture = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
        }
        webcamTexture.Play();
    }
    void SetResolution(int w, int h)
    {
        width = w;
        height = h;
    }


}
