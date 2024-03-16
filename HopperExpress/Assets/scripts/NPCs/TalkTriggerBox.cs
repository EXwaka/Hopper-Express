using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTriggerBox : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject Ebutton;
    // Start is called before the first frame update
    void Start()
    {
        dialogue.SetActive(false);
        Ebutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Ebutton.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            dialogue.SetActive(true);
            Ebutton.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Ebutton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            dialogue.SetActive(false);
            Ebutton.SetActive(false);
        }
    }
}
