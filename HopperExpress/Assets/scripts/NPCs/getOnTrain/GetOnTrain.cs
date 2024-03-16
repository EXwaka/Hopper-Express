using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetOnTrain : MonoBehaviour
{
    public GameObject Ebutton;
    // Start is called before the first frame update
    void Start()
    {
        Ebutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Ebutton.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadSceneAsync("SampleScene");

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
            Ebutton.SetActive(false);
        }
    }
}
