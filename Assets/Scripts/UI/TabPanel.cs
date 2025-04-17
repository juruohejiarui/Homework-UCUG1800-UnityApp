using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class TabPanel : MonoBehaviour
{
    public TabBtn[] tabBtns;
    public TabBtn SelectedTabBtn { get => tabBtns[SelectedIndex]; }

    public int SelectedIndex;

    public Color SelectedColor = Color.white;
    public Color SelectedIconColor = Color.red;

    public Color UnselectedColor = Color.red;
    public Color UnselectedIconColor = Color.white;
    // Start is called before the first frame update

    public void ChangeSelected(int index) {
        SelectedTabBtn.IsSelected = false;
        SelectedIndex = index;
        SelectedTabBtn.IsSelected = true;
    }
    void Start()
    {
        tabBtns = GetComponentsInChildren<TabBtn>();
        SelectedIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
