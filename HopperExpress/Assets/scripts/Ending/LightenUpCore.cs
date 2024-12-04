using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightenUpCore : MonoBehaviour
{
    public GameObject Ebutton;
    public GameObject coreLight;
    static public bool LightUp;
    private bool Activated;
    // Start is called before the first frame update
    void Start()
    {
        Activated = false;
        LightUp = false;
        coreLight.SetActive(false);
        Ebutton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Ebutton.activeSelf && Input.GetKeyDown(KeyCode.E)&&!Activated)
        {
            Activated = true;
            LightUp = true;
            coreLight.SetActive(true);
            Ebutton.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character") && !Activated)
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
