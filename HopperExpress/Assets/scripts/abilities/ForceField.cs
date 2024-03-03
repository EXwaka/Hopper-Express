using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public GameObject forcefield;

    public static float cooldown = 0.3f;
    public float Timer;
    //public static bool Damaging = true;

    // Start is called before the first frame update
    void Start()
    {
        if (Skills.skill_forcefield == true)
        {
            forcefield.SetActive(true);
        }
        else
        {
            forcefield.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("enemy"))
    //    {
    //        if (!Damaging)
    //        {
    //            StartCoroutine(DamageOverTime(other.gameObject));
    //        }
    //    }
    //}
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("enemy"))
    //    {
    //        Damaging = false;
    //    }
    //}

    //IEnumerator DamageOverTime(GameObject enemy)
    //{
    //    Damaging = true;
    //    while (Damaging)
    //    {
    //        yield return new WaitForSeconds(cooldown);
    //    }
    //}
}
