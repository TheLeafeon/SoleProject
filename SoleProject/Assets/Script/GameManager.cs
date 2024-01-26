using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public bool openUI = false;
    public GameObject menu_Panel;
    public GameObject soundMenu_Panel;


    void Update()
    {

        if (Input.GetButtonDown("Cancel"))
        {
            if(!openUI)
            {
                OpenMenu();
            }
            else if(openUI && menu_Panel.activeSelf) 
            {
                Close_Menu();
            }
            else if(openUI && soundMenu_Panel.activeSelf)
            {
                Close_SoundMenu();
            }
                    
        }

        if(openUI && !menu_Panel.activeSelf && !soundMenu_Panel.activeSelf)
        {
            openUI = false;
        }
    }

    void Close_SoundMenu()
    {
        UnityEngine.Debug.Log("soundMenu Close");
        soundMenu_Panel.SetActive(false);
        openUI = false;

    }
    void Close_Menu()
    {
        UnityEngine.Debug.Log("menu Close");
        menu_Panel.SetActive(false);
        openUI = false;
    }
    void OpenMenu()
    {
        UnityEngine.Debug.Log("menu Open");
        menu_Panel.SetActive(true);
        openUI = true;
    }
}
