using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class Talktrigger2 : MonoBehaviour
{
    public GameObject Ebutton;
    private bool CanTalk;
    private bool Talked;
    static public bool Talking2;
    DiaAnim2 dialogueAnimation;
    void Start()
    {
        Talking2 = false;
        Talked = false;
        dialogueAnimation = FindObjectOfType<DiaAnim2>();
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
            Talking2 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Ebutton.SetActive(false);

            CanTalk = false;
            Talking2 = false;

        }
    }
}