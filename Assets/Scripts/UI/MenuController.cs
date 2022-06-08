using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject menuWindowObjects;
    private bool isMenuWindowActive;
    [SerializeField]
    PlayerInput input;
    private void Start()
    {
        menuWindowObjects.SetActive(true);
        isMenuWindowActive = true;
    }
    public void  MenuButtonClick()
    {
        if (isMenuWindowActive)
        {
            input.enabled = true;
            menuWindowObjects.SetActive(false);
            isMenuWindowActive = false;
        }
        else
        {
            //メニュー開いてるときはタイルのクリック不可にする
            input.enabled = false;
            menuWindowObjects.SetActive(true);
            isMenuWindowActive = true;
        }
    }
    
}
