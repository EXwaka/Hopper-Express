using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashScreen : MonoBehaviour
{
    public Animator flashAnimation;

    void Start()
    {
        flashAnimation.enabled = false;
    }

    void Update()
    {
        if (startScreenTrain.trainArrived == true)
        {
            flashAnimation.enabled = true;
            flashAnimation.SetTrigger("Flash");
        }
    }
}
