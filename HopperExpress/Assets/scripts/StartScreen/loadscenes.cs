using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadscreen : MonoBehaviour
{

    public void StartButton()
    {
        SceneManager.LoadSceneAsync("Story1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
