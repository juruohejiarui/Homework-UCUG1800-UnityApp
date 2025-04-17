using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TabBtn : MonoBehaviour, IPointerClickHandler
{
    private bool isSelected = false;

    private Image selfImageComponent;
    private Image iconComponent;

    private TMP_Text textComponent;

    private TabPanel belong;

    public bool IsSelected {
        get => isSelected; 
        set {
            isSelected = value;
            if (isSelected) {
                selfImageComponent.color = belong.SelectedColor;
                if (iconComponent != null) iconComponent.color = belong.SelectedIconColor;
                if (textComponent != null) textComponent.color = belong.SelectedIconColor;
            } else {
                selfImageComponent.color = belong.UnselectedColor;
                if (iconComponent != null) iconComponent.color = belong.UnselectedIconColor;
                if (textComponent != null) textComponent.color = belong.UnselectedIconColor;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        belong = GetComponentInParent<TabPanel>();
        TabBtn[] btns = belong.GetComponentsInChildren<TabBtn>();
        selfImageComponent = GetComponent<Image>();
        if (transform.Find("icon") != null)
            iconComponent = transform.Find("icon").GetComponent<Image>();
        else iconComponent = null;

        if (transform.Find("text") != null)
            textComponent = transform.Find("text").GetComponent<TMP_Text>();
        else textComponent = null;
        
        IsSelected = btns[0] == this;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void OnPointerClick(PointerEventData eventData) {
        for (int i = 0; i < belong.tabBtns.Length; i++) {
            if (belong.tabBtns[i] == this) {
                belong.ChangeSelected(i);
                break;
            }
        }
    }
}
