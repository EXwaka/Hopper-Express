using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMissileControl : MonoBehaviour
{
    public GameObject AutoMissile;
    public GameObject missile;
    public Transform launchPoint;
    static public float CD = 8;
    private bool Ready=true;
    static public bool UILaunching=true;

    void Start()
    {
        Ready = true;
        CD = 8;
        UILaunching = false;
        if (!Skills.skill_automissile)
        {
            AutoMissile.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2)&&Ready)
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
        UILaunching=true;
        Invoke("Reload", CD);
    }
    void Reload()
    {
        Ready = true;
        UILaunching = false;
    }
}
