using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electric : MonoBehaviour
{
    public GameObject electric;
    public float cooldown = 3;
    public float duration = 1;

    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        electric.SetActive(false);
        startTime = Time.time; 
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime; 
        Debug.Log("Elapsed Time:" + elapsedTime);

        if (elapsedTime >= cooldown)
        {
            electric.SetActive(true);

            if (elapsedTime >= cooldown + duration)
            {
                startTime = Time.time;
            }
        }
        else
        {
            electric.SetActive(false);
        }
    }

}
