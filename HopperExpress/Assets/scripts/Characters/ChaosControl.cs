using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaosControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ChaosImg;
    void Start()
    {
        ChaosImg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(CharacterMove.inChaos)
        {
            ChaosImg.SetActive(true);
        }
        else
        {
            ChaosImg.SetActive(false);
        }
    }
}
