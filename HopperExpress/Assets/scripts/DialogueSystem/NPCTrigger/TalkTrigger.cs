using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class TalkTrigger : MonoBehaviour
{
    public GameObject Ebuttom;
    private bool CanTalk;
    private bool Talked;
    DialogueAnimation dialogueAnimation;

    void Start()
    {
        Talked = false;
        dialogueAnimation = FindObjectOfType<DialogueAnimation>();
        Ebuttom.SetActive(false);
        CanTalk = false ;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanTalk)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(!Talked)
                {
                    dialogueAnimation.SlideIn();
                    CanTalk = false;
                    Ebuttom.SetActive(false);
                    Talked = true;
                }


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character")&&!Talked)
        {
            Ebuttom.SetActive(true);
            CanTalk=true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Ebuttom.SetActive(false);

            CanTalk=false ;
        }
    }
}
