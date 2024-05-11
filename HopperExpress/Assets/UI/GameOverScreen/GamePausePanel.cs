using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class GamePausePanel : MonoBehaviour
{
    public GameObject mainCanvas;

    public RectTransform rectTransform;
    public float topPosY, middlePosY;
    public float tweenDuration;
    public GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        mainCanvas.SetActive(false);
        pauseButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        mainCanvas.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();

        }

    }

    void SlideIn()
    {
        rectTransform.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }
    void SlideOut()
    {
        rectTransform.DOAnchorPosY(topPosY, tweenDuration).SetUpdate(true);

    }

    public void Pause()
    {
        SlideIn();
        pauseButton.SetActive(false);
        mainCanvas.SetActive(true);
        Time.timeScale = 0;

    }
    public void Resume()
    {
        SlideOut();
        pauseButton.SetActive(true);
        mainCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
    public void BackToMenu()
    {
        pauseButton.SetActive(true);
        mainCanvas.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");

    }


}
