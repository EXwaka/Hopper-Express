using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClimbLadder : MonoBehaviour
{
    public GameObject Ebutton;   
    public Transform A;        
    public Transform player; 

    private void Start()
    {
        Ebutton.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Ebutton.activeSelf)
        {
            var audioManager = FindObjectOfType<AudioManager>();
            if (audioManager != null)
            {
                Debug.Log("AudioManager found, trying to play sound...");
                audioManager.Play("Stair");
            }

            TeleportPlayer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Ebutton.SetActive(true); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Ebutton.SetActive(false); 
        }
    }

    private void TeleportPlayer()
    {
        Vector3 newPosition = new Vector3(A.position.x, A.position.y, player.position.z);
        player.position = newPosition;
    }
}

