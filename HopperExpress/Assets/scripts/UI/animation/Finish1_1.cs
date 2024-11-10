using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish1_1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Invoke("NextLv", 5f);
    }



    void NextLv()
    {
        SceneController.instance.NextLevel();
    }
}
