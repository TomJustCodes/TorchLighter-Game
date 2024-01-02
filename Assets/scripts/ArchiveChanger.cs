using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchiveChanger : MonoBehaviour
{

    public GameObject currerentBox;
    GameObject NewBox;
    string finder;

    void Start()
    {
        currerentBox.SetActive(true);
    }

    public void OnClick(Button button)
    {
        //identifiying the button which is pressed
        finder= button.name;
        NewBox = GameObject.Find("ARCHIVE/"+finder+"/Box");
        //switches out the information
        currerentBox.SetActive(false);
        NewBox.SetActive(true);
        currerentBox = NewBox;
    }
    
}
