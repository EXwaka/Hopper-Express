using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    private void Awake()
    {
        Time.timeScale = 1;

        if (instance == null)
        {
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        Wavespawner.monsCount = 0;
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);


    }


    public void LoadScene(string sceneName) 
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(sceneName);
    }

}
