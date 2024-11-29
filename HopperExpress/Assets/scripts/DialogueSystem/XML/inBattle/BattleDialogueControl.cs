using System.Collections;
using UnityEngine;

public class BattleDialogueControl : MonoBehaviour
{
    DialogueAnimation dialogueAnimation;
    DialogueControl dialogueControl;
    static public bool Active = true;
    public GameObject Thisobj;

    void Start()
    {
        Active = true;
        dialogueControl = FindObjectOfType<DialogueControl>();
        dialogueAnimation = FindObjectOfType<DialogueAnimation>();
        Invoke("TSlideIn", 5f);
    }
    private void Update()
    {
        if (!Active)
        {
            Thisobj.SetActive(false);
        }
    }
    void TSlideIn()
    {
        StartCoroutine(SlideIn());

    }

    IEnumerator SlideIn()
    {
        StartCoroutine(dialogueControl.StartFirstDialogue());
        Time.timeScale = 0.2f;

        yield return new WaitForSecondsRealtime(1f);

        dialogueAnimation.SlideIn();

        Time.timeScale = 0f;
    }


}