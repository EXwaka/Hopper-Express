using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleDia2 : MonoBehaviour
{
    DiaAnim2 dialogueAnimation;
    XMLDialogue2 dialogue;
    static public bool FirstCoreHit = false;
    bool AlreadyPlayed=false;

    void Start()
    {
        FirstCoreHit = false;
        dialogue = FindObjectOfType<XMLDialogue2>();
        dialogueAnimation = FindObjectOfType<DiaAnim2>();
    }
    private void Update()
    {
        if (FirstCoreHit)
        {
            if(!AlreadyPlayed)
            {
                TSlideIn();
            }
        }
    }
    void TSlideIn()
    {
        StartCoroutine(SlideIn());
        AlreadyPlayed = true;
    }

    IEnumerator SlideIn()
    {
        StartCoroutine(dialogue.StartFirstDialogue());
        yield return new WaitForSecondsRealtime(0f);

        dialogueAnimation.SlideIn();

        Time.timeScale = 0f;
    }

}
