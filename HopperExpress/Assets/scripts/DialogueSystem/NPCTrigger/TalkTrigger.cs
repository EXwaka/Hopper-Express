using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class TalkTrigger : MonoBehaviour
{
    public GameObject Ebutton;
    private bool CanTalk;
    private bool Talked;
    static public bool Talking;
    DialogueAnimation dialogueAnimation;
    void Start()
    {
        Talking = false;
        Talked = false;
        dialogueAnimation = FindObjectOfType<DialogueAnimation>();
        Ebutton.SetActive(false);
        CanTalk = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanTalk)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!Talked)
                {
                    CharacterMove.ableToMove = false;
                    dialogueAnimation.SlideIn();
                    CanTalk = false;
                    Ebutton.SetActive(false);
                    Talked = true;
                }


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character") && !Talked)
        {
            Ebutton.SetActive(true);
            CanTalk = true;
            Talking=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Ebutton.SetActive(false);

            CanTalk = false;
            Talking = false;

        }
    }
}