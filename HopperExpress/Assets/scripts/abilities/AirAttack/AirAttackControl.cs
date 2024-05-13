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
    public float CDMax = 30f;
    float CD;
    bool readyToAttack = false;

    
    // Start is called before the first frame update
    void Start()
    {
        CD = CDMax;
        readyToAttack = true;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        aimimg =  false;
        AttackAim.SetActive(false);
        //AttackArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToAttack == false)
        {
            CD -= Time.deltaTime;
            if (CD <= 0)
            {
                CD = CDMax;
                readyToAttack = true;
            }
        }

        //Debug.Log("Aiming" + aimimg);
        if (Input.GetKeyDown(KeyCode.Q)&&readyToAttack==true)
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
                Instantiate(AttackArea, transform.position, transform.rotation);

                aimimg = false;
                AttackAim.SetActive(false);
                readyToAttack = false;

            }
        }

    }


}
