using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class TabPanel : MonoBehaviour
{
    public TabBtn[] tabBtns;
    public TabBtn selectedTabBtn { get => tabBtns[selectedIndex]; }

    public int selectedIndex;

    public Color SelectedColor = Color.white;
    public Color SelectedIconColor = Color.red;

    public Color UnselectedColor = Color.red;
    public Color UnselectedIconColor = Color.white;
    // Start is called before the first frame update

    public void ChangeSelected(int index) {
        selectedTabBtn.IsSelected = false;
        selectedIndex = index;
        selectedTabBtn.IsSelected = true;
    }
    void Start()
    {
        tabBtns = GetComponentsInChildren<TabBtn>();
        selectedIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
