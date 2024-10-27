using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScreenTrain : MonoBehaviour
{
    public static bool trainArrived = false;
    public Animator train_animation;

    void Start()
    {
        trainArrived = false;
        //train_animation.SetTrigger("StartTrainAnimation");
    }
    private void Update()
    {
        Debug.Log(trainArrived);
    }

    // This method should be called from the animation event
    public void OnTrainAnimationEnd()
    {
        trainArrived = true;
    }
}
