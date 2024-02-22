using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class AudioData
{
    public string title;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 1f; // Volume for each audio clip
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public List<AudioData> bgmList;
    public List<AudioData> sfxList;

    private AudioSource bgmSource;
    private AudioSource sfxSource;

    private Dictionary<string, AudioClip> bgmClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();

    public float bgmVolume = 1f; // Variable to control overall BGM volume
    public float sfxVolume = 1f; // Variable to control overall SFX volume

    private bool isBGMPlaying = false;
    private float pausedTime;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            bgmSource = gameObject.AddComponent<AudioSource>();
            sfxSource = gameObject.AddComponent<AudioSource>();

            foreach (AudioData bgmData in bgmList)
            {
                bgmClips[bgmData.title] = bgmData.clip;
            }

            foreach (AudioData sfxData in sfxList)
            {
                sfxClips[sfxData.title] = sfxData.clip;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // �� ���� ���� BGM ����
        string sceneName = scene.name;

        pausedTime = 0; //����
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void PlayBGM(string bgmTitle, bool loop = true)
    {
        if (!bgmClips.ContainsKey(bgmTitle))
        {
            Debug.LogError("Invalid BGM title");
            return;
        }

        bgmSource.clip = bgmClips[bgmTitle];
        bgmSource.volume = bgmVolume;
        bgmSource.loop = loop;

        if (isBGMPlaying)
        {
            bgmSource.time = pausedTime;
            bgmSource.Play();
        }
        else
        {
            bgmSource.Play();
            isBGMPlaying = true;
        }
    }


    public void PlaySFX(string sfxTitle)
    {
        if (!sfxClips.ContainsKey(sfxTitle))
        {
            Debug.LogError("Invalid SFX title");
            return;
        }

        sfxSource.PlayOneShot(sfxClips[sfxTitle], sfxVolume);
    }

    public void PlaySFX(string sfxTitle, float localSfxVolume)
    {
        if (!sfxClips.ContainsKey(sfxTitle))
        {
            Debug.LogError("Invalid SFX title");
            return;
        }

        sfxSource.PlayOneShot(sfxClips[sfxTitle], localSfxVolume);
    }

    public void StopSFX(string sfxTitle)
    {

        if (!sfxClips.ContainsKey(sfxTitle))
        {
            Debug.LogError("Invalid SFX title");
            return;
        }

        sfxSource.Stop();
    }

    // BGM ���� �޼���
    public void StopBGM()
    {
        if (bgmSource.isPlaying)
        {
            bgmSource.Pause();
            isBGMPlaying = false;
            pausedTime = bgmSource.time;
        }
    }

    public void RePlayBGM()
    {
        if (!isBGMPlaying)
        {
            bgmSource.UnPause();
            isBGMPlaying = true;
        }
    }

    // ��ü BGM ���� ���� �޼���
    public void SetBGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        bgmSource.volume = bgmVolume;
    }

    // ��ü SFX ���� ���� �޼���
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
    }
}
