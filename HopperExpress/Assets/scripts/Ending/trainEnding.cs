using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class trainEnding : MonoBehaviour
{
    private float CD;
    public TMP_Text m_text;
    public float fadeDuration = 1f;
    private bool hasFadedIn = false;
    Animator animator;
    public GameObject fadeOut;
    public int sec;
    void Start()
    {
        fadeOut.SetActive(false);
        animator = GetComponent<Animator>();
        CD = sec; 
        m_text.gameObject.SetActive(false); 

        Color initialColor = m_text.color;
        initialColor.a = 0f;
        m_text.color = initialColor;
        Invoke("BackToMenu", sec+8);
    }

    void Update()
    {
        CD -= Time.deltaTime; 

        if (CD <= 0 && !hasFadedIn) 
        {
            animator.SetTrigger("TrainMove");
            m_text.gameObject.SetActive(true); 
            StartCoroutine(FadeIn()); 
            hasFadedIn = true;
            StartCoroutine(FadeInAnim());
        }
    }
    public IEnumerator FadeInAnim()
    {
        yield return new WaitForSeconds(4);
        fadeOut.SetActive(true);

    }
    public IEnumerator FadeIn()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float currentAlpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);

            Color newColor = m_text.color;
            newColor.a = currentAlpha;
            m_text.color = newColor;

            yield return null;
        }

        Color finalColor = m_text.color;
        finalColor.a = 1f;
        m_text.color = finalColor;
    }
    void BackToMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
