using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHpBar : MonoBehaviour
{
    private Camera uiCamera;
    private Camera mainCamera;
    private Canvas _canvas;
    private RectTransform rectParent;
    private RectTransform rectHp;

    [HideInInspector] public Vector3 offset = Vector3.zero;
    [HideInInspector] public Transform targetTr;

    void Start()
    {
        _canvas = GetComponentInParent<Canvas>();
        uiCamera = _canvas.worldCamera;
        rectParent = _canvas.GetComponent<RectTransform>();
        rectHp = this.gameObject.GetComponent<RectTransform>();
        mainCamera = GameObject.Find("Main Camera")
            .GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        // Camera.main 사용시 'MainCamera' Tag가 붙어 있어야 함
        //var screenPos = Camera.main
        //    .WorldToScreenPoint(targetTr.position + offset);
        var screenPos = mainCamera
            .WorldToScreenPoint(targetTr.position + offset);
        if (screenPos.z < 0.0f)
        {
            screenPos *= -1.0f;
        }
        var localPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle
            (rectParent, screenPos, uiCamera, out localPos);
        rectHp.localPosition = localPos;
    }
}
