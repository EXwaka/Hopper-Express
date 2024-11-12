using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingAnim : MonoBehaviour
{
    public GameObject Ebutton;
    public GameObject Character;
    public GameObject Train;
    public GameObject Fade;
    // Start is called before the first frame update
    void Start()
    {
        Fade.SetActive(false);
        Ebutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Ebutton.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            Fade.SetActive (true);
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
    void Ending()
    {
        SceneManager.LoadSceneAsync("Ending1");

    }
}
