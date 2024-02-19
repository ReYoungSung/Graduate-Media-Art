using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    float timer = 0f;
    bool isPlaying = false;
    private void OnTriggerEnter(Collider other)
    {

        // �浹�� ������Ʈ�� Target �±׸� ������ �ִ��� Ȯ��
        if (other.CompareTag("Target") && !(isPlaying))
        {
            isPlaying = true;
            timer = Time.time;
            // SoundManager�� �ν��Ͻ� ��������
            SoundManager soundManager = SoundManager.instance;
            soundManager.StopSFX("AAA");
            if (soundManager != null)
            {

                // "AAA"��� SFX ���
                soundManager.PlaySFX("AAA");
                Debug.Log(timer);
            }
            else
            {
                Debug.LogError("SoundManager�� ã�� �� �����ϴ�.");
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
