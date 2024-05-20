using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class GameOverControl : MonoBehaviour
{
    public GameObject mainCanvas;

    public RectTransform rectTransform;
    public float topPosY, middlePosY;
    public float tweenDuration;
    // Start is called before the first frame update
    void Start()
    {
        mainCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void SlideIn()
    {
        Time.timeScale = 0;
        rectTransform.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }



    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;

    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");

    }


}