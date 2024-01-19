using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void MoveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        UnityEngine.Debug.Log(sceneName);
    }
}
