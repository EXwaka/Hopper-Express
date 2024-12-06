using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class watchView : MonoBehaviour
{
    public GameObject fade;  
    public GameObject view;    
    public GameObject m_button;   
    public GameObject ExitButton;


    void Start()
    {
        fade.SetActive(false);
        view.SetActive(false);
        ExitButton.SetActive(false);
        m_button.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && m_button.activeSelf)
        {
            var audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null)
            {
                audioManager.Play("Stair");
            }

            CharacterMove.ableToMove = false;
            fade.SetActive(true); 
            view.SetActive(true); 
            ExitButton.SetActive(true) ;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            m_button.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            m_button.SetActive(false); 

        }
    }

    public void Exit()
    {
        CharacterMove.ableToMove = true;

        fade.SetActive(false);
        view.SetActive(false);
        ExitButton.SetActive(false);

    }

}