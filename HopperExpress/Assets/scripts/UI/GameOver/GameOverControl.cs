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
        rectTransform.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);
    }



    public void Restart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");

    }


}
