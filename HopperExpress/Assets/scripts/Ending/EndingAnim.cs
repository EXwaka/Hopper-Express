using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingAnim : MonoBehaviour
{
    public GameObject Ebutton;
    public GameObject warn;
    public GameObject Character;
    public GameObject Train;
    public GameObject Fade;
    // Start is called before the first frame update
    void Start()
    {
        warn.SetActive(false);
        Fade.SetActive(false);
        Ebutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Ebutton.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            if (!LightenUpCore.LightUp)
            {
                Ebutton.SetActive(false);
                warn.SetActive(true);
            }
            else
            {
                Fade.SetActive(true);
                Invoke("Ending", 2.5f);
            }

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
            warn.SetActive(false);
        }
    }
    void Ending()
    {
        SceneManager.LoadSceneAsync("Ending1");

    }
}
