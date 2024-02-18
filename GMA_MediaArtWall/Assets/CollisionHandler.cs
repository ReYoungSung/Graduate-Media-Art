using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� Target �±׸� ������ �ִ��� Ȯ��
        if (other.CompareTag("Target"))
        {
            // SoundManager�� �ν��Ͻ� ��������
            SoundManager soundManager = SoundManager.instance;
            if (soundManager != null)
            {
                // "AAA"��� SFX ���
                soundManager.PlaySFX("AAA");
            }
            else
            {
                Debug.LogError("SoundManager�� ã�� �� �����ϴ�.");
            }
        }
    }
}
