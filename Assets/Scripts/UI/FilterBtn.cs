using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FilterBtn : MonoBehaviour, IPointerClickHandler
{
    public bool isSelected;

    private Image selfImageComponent;
    private Image iconComponent;
    private TMP_Text textComponent;

    public Color selectedIconColor = Color.white;
    public Color unselectedIconColor = Color.black;

    public Color selectedColor = Color.blue;
    public Color unselectedColor = Color.white;

    private void UpdateUI() {
        if (isSelected) {
            iconComponent.color = textComponent.color = selectedIconColor;
            selfImageComponent.color = selectedColor;
        } else {
            iconComponent.color = textComponent.color = unselectedIconColor;
            selfImageComponent.color = unselectedColor;
        }
    }

    public bool IsSelected {
        get => isSelected;
        set {
            isSelected = value;
            UpdateUI();
        }
    }

    public Sprite Icon {
        get => iconComponent.sprite;
        set {
            iconComponent.sprite = value;
        }
    }
    public string Text {
        get => textComponent.text;
        set {
            textComponent.text = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        selfImageComponent = GetComponent<Image>();
        iconComponent = transform.Find("icon").GetComponent<Image>();
        textComponent = transform.Find("text").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        IsSelected = !IsSelected;
    }
}
