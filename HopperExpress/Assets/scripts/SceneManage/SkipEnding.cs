using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipEnding : MonoBehaviour
{
    public GameObject button;
    private Coroutine buttonTimerCoroutine;

    void Start()
    {
        button.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!button.activeSelf)
            {
                button.SetActive(true);
                buttonTimerCoroutine = StartCoroutine(HideButtonAfterDelay(3f));
            }
            else
            {
                if (buttonTimerCoroutine != null)
                {
                    StopCoroutine(buttonTimerCoroutine);
                }
                buttonTimerCoroutine = StartCoroutine(HideButtonAfterDelay(3f));
            }
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }

    IEnumerator HideButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        button.SetActive(false);
    }
}
