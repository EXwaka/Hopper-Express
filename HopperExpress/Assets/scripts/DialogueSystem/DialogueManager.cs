using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;


    DialogueTrigger dialogueTrigger;
    public RectTransform TalkBox;
    public float topPosY, middlePosY;
    public float tweenDuration;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        TalkBox.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letters in sentence)
        {
            dialogueText.text += letters;
            yield return new WaitForSeconds(0.05f);
        }
    }


    void EndDialogue()
    {
        TalkBox.DOAnchorPosY(-middlePosY, tweenDuration).SetUpdate(true);

    }
}
