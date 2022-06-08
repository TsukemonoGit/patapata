using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MenuPanelController : MonoBehaviour
{
    [SerializeField]
    private PataPataController controller;
    [SerializeField]
    private MenuController menu;
    [SerializeField]
    TMP_Dropdown widthDD;
    [SerializeField]
    TMP_Dropdown colorDD;
    [SerializeField]
    TMP_Dropdown tesuuDD;

public void ClickCreateButton()
    {
       
        controller.width = widthDD.value+2;
        controller.max_color = colorDD.value+2;
        controller.tekazu = tesuuDD.value+1;

     //   Debug.Log(widthDD.value);
  //      Debug.Log(colorDD.value);
       // Debug.Log(tesuuDD.value);
        controller.ClickCreate();
        
        menu.MenuButtonClick();

    }
}
