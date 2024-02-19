using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    float timer = 0f;
    bool isPlaying = false;
    private void OnTriggerEnter(Collider other)
    {

        // 충돌한 오브젝트가 Target 태그를 가지고 있는지 확인
        if (other.CompareTag("Target") && !(isPlaying))
        {
            isPlaying = true;
            timer = Time.time;
            // SoundManager의 인스턴스 가져오기
            SoundManager soundManager = SoundManager.instance;
            soundManager.StopSFX("AAA");
            if (soundManager != null)
            {

                // "AAA"라는 SFX 재생
                soundManager.PlaySFX("AAA");
                Debug.Log(timer);
            }
            else
            {
                Debug.LogError("SoundManager를 찾을 수 없습니다.");
            }
        }
    }

    void Update()
    {
        if (Time.time - timer >= 5f)
        {
            isPlaying = false;
        }
    }
}
