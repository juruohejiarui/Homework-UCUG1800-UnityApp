using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class DragBar : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform mainPanel;
    private EventSystem eventSystem;
    private RectTransform screen;
    private float sumDragY, orgOffsetY;

    public float minHeight = 20;
    public float minMarginTop = 30;

    public float TargetMarginTop = 0;

    private bool isOnDrag = false;

    // Start is called before the first frame update
    void Start()
    {
        mainPanel = transform.parent.GetComponent<RectTransform>();
        eventSystem = EventSystem.current;
        screen = GetComponentInParent<Canvas>().gameObject.transform as RectTransform;
        TargetMarginTop = minMarginTop;
    }

    // Update is called once per frame
    void Update()
    {
        // 插值，形成动画
        if (!isOnDrag) {
            // 距离足够近，就不插值了
            if (Mathf.Abs(mainPanel.offsetMax.y - TargetMarginTop) < 1) 
                mainPanel.offsetMax = new Vector2(0, TargetMarginTop);
            else mainPanel.offsetMax = Vector2.Lerp(mainPanel.offsetMax, new Vector2(0, -TargetMarginTop), Time.deltaTime * 20f);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        eventSystem.SetSelectedGameObject(gameObject);
        sumDragY = mainPanel.offsetMax.y;
        isOnDrag = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // map the delta to canvas size
        sumDragY += eventData.delta.y * screen.rect.height / Screen.height;
        float val = Mathf.Min(Mathf.Max(sumDragY, -screen.rect.height + minHeight), -minMarginTop);
        mainPanel.offsetMax = new Vector2(0, val);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        eventSystem.SetSelectedGameObject(null);
        isOnDrag = false;
        if (mainPanel.offsetMax.y > -screen.rect.height / 3)
        {
            TargetMarginTop = minMarginTop;
        }
        else if (mainPanel.offsetMax.y < -screen.rect.height * 5 / 6)
        {
            TargetMarginTop = screen.rect.height - minHeight;
        }
        else TargetMarginTop = screen.rect.height * 5 / 8;
    }
}
