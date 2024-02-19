using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuUIManaer : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject soundMenuPanel;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            if (!menuPanel.activeSelf && !soundMenuPanel.activeSelf && SceneManager.GetActiveScene().name != "TitleScene")
            {
                menuPanel.SetActive(true);
            }
            else if(menuPanel.activeSelf)
            {
                menuPanel.SetActive(false);
            }
        }
    }


    void MenuOpenOpen()
    {

    }


}
