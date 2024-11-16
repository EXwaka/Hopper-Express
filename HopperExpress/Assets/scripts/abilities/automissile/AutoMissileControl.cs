using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMissileControl : MonoBehaviour
{
    public GameObject AutoMissile;
    public GameObject missile;
    public Transform launchPoint;
    public float CD = 3;
    private bool Ready=true;

    void Start()
    {
        Ready = true;
        if (!Skills.skill_automissile)
        {
            AutoMissile.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)&&Ready)
        {
            FindObjectOfType<AudioManager>().Play("launching");
            LaunchMissile();
        }
    }

    void LaunchMissile()
    {
        Vector3 LaunchPoint = new Vector3(-0.8f + launchPoint.position.x, 1f + launchPoint.position.y, launchPoint.position.z);
        Instantiate(missile,LaunchPoint,transform.rotation);
        Ready = false;
        Invoke("Reload", CD);
    }
    void Reload()
    {
        Ready = true;
    }
}
