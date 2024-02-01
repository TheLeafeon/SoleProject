using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonFunction : MonoBehaviour
{
    public void MoveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        UnityEngine.Debug.Log(sceneName);
    }

    public void OpenPanel(GameObject PanelName)
    {
        if(!PanelName.activeSelf)
        {
            PanelName.SetActive(true);
        }
        
    }

    public void ClosePanel(GameObject PanelName)
    {
        PanelName.SetActive(false);
    }

    public void MovePanel(GameObject OpenPanelName, GameObject ClosePanelName)
    {
        ClosePanelName.SetActive(false);
        OpenPanelName.SetActive(true);
    }
}
