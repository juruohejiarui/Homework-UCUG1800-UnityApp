using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DragBar : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    public RectTransform mainPanel;
    // Start is called before the first frame update
    void Start()
    {
        isDown = false;
        mainPanel = GetComponentInParent<RectTransform>();
    }

    private bool isDown;

    public void OnPointerDown(PointerEventData evt) {
        Debug.Log("Mouse Down Position: " + evt.position);
        isDown = true;
    }

    public void OnPointerUp(PointerEventData evt) {
        Debug.Log("Mouse Up Position: " + evt.position);
        isDown = false;
    }

    public void OnPointerMove(PointerEventData evt) {
        // Debug.Log("Mouse Move");
        if (isDown) mainPanel.offsetMin = new Vector2(mainPanel.offsetMin.x, mainPanel.offsetMin.x + evt.delta.y);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
