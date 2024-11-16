using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class TalkTrigger : MonoBehaviour
{
    public GameObject Ebuttom;
    private bool CanTalk;
    DialogueTrigger dialogueTrigger;
    //public RectTransform TalkBox;
    //public float topPosY, middlePosY;
    //public float tweenDuration;
    // Start is called before the first frame update
    void Start()
    {
        dialogueTrigger = GetComponentInParent<DialogueTrigger>();
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
                //TalkBox.DOAnchorPosY(middlePosY, tweenDuration).SetUpdate(true);

                dialogueTrigger.TriggerDialogue();
                CanTalk = false ;
                Ebuttom.SetActive(false);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Ebuttom.SetActive(true);
            CanTalk=true ;

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
