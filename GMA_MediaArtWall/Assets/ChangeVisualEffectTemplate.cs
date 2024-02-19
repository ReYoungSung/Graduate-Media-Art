using UnityEngine;
using UnityEngine.VFX;
using System.Collections.Generic;

public class ChangeVisualEffectTemplate : MonoBehaviour
{
    public List<VisualEffectAsset> visualEffectAssets = new List<VisualEffectAsset>(); // VisualEffectAsset���� ����Ʈ

    private VisualEffect visualEffect;
    private int currentTemplateIndex = 0; // ���� ���ø��� �ε���

    void Start()
    {
        visualEffect = GetComponent<VisualEffect>(); // VisualEffect ������Ʈ ��������
        if (visualEffect == null)
        {
            Debug.LogError("VisualEffect Component�� ã�� �� �����ϴ�.");
            enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
            return;
        }

        UpdateVisualEffectTemplate(); // �ʱ� ���ø� ����
    }

    void Update()
    {
        // ���� Ű�� ����Ͽ� ���ø� ����
        for (int i = 0; i < visualEffectAssets.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) // Ű���� ���� 1���� ������� �˻�
            {
                currentTemplateIndex = i;
                UpdateVisualEffectTemplate(); // ���ø� ����
                break;
            }
        }
    }

    // ���� ���ø��� �ش��ϴ� VisualEffectAsset���� �����ϴ� �Լ�
    void UpdateVisualEffectTemplate()
    {
        if (visualEffect != null && visualEffectAssets.Count > 0)
        {
            visualEffect.visualEffectAsset = visualEffectAssets[currentTemplateIndex];
        }
    }
}
