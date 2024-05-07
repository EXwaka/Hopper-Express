using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirAttackControl : MonoBehaviour
{
    Camera cam;
    bool aimimg = false;
    public GameObject AttackAim;
    public GameObject AttackArea;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        aimimg =  false;
        AttackAim.SetActive(false);
        AttackArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Aiming" + aimimg);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            aimimg = !aimimg;

            if (aimimg == true && Skills.skill_airattack == true)
            {
                AttackAim.SetActive(true);
            }
            else
            {
                AttackAim.SetActive(false);
            }
        }

        if (aimimg)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;
            mousePosition.y = 450;
            transform.position = cam.ScreenToWorldPoint(mousePosition);
            if(Input.GetMouseButtonDown(0))
            {
                AttackArea.SetActive(true);
                aimimg = false;
            }
        }

    }


}
