using UnityEngine;
using UnityEngine.VFX;
using System.Collections.Generic;

public class ChangeVisualEffectTemplate : MonoBehaviour
{
    public List<VisualEffectAsset> visualEffectAssets = new List<VisualEffectAsset>(); // VisualEffectAsset들의 리스트

    private VisualEffect visualEffect;
    private int currentTemplateIndex = 0; // 현재 템플릿의 인덱스

    void Start()
    {
        visualEffect = GetComponent<VisualEffect>(); // VisualEffect 컴포넌트 가져오기
        if (visualEffect == null)
        {
            Debug.LogError("VisualEffect Component를 찾을 수 없습니다.");
            enabled = false; // 스크립트 비활성화
            return;
        }

        UpdateVisualEffectTemplate(); // 초기 템플릿 설정
    }

    void Update()
    {
        // 숫자 키를 사용하여 템플릿 변경
        for (int i = 0; i < visualEffectAssets.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)) // 키보드 숫자 1부터 순서대로 검사
            {
                currentTemplateIndex = i;
                UpdateVisualEffectTemplate(); // 템플릿 변경
                break;
            }
        }
    }

    // 현재 템플릿에 해당하는 VisualEffectAsset으로 변경하는 함수
    void UpdateVisualEffectTemplate()
    {
        if (visualEffect != null && visualEffectAssets.Count > 0)
        {
            visualEffect.visualEffectAsset = visualEffectAssets[currentTemplateIndex];
        }
    }
}
