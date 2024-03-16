using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public Animator Fade;


    public void Playgame()
    {
        Fade.SetTrigger("Start");
        SceneManager.LoadSceneAsync("FirstScene");
    }
    public void NextStory()
    {
        Fade.SetTrigger("Start");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
