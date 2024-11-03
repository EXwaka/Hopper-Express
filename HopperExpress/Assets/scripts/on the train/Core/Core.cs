using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject core;
    public int HPmax_core=100;
    public int HPcurrent_core;
    public HBbar healthBar;
    private bool dead;
    public GameOverControl gameOverControl;

    private FlashDam flashDam;
    // Start is called before the first frame update
    void Start()
    {
        ////
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(HPmax_core);
        }
        else
        {
            Debug.LogError("HealthBar is not assigned in the inspector.");
        }
        ////
        flashDam = GetComponent<FlashDam>();
        dead = false;
        HPcurrent_core = HPmax_core;
        healthBar.SetMaxHealth(HPmax_core);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("coreHP: " + HP_core);
        if (HPcurrent_core <= 0&&!dead)
        {
            StartCoroutine(DeadAnim());
            dead = true;
        
        }
    }

    public void GetHit(int damage)
    {
        HPcurrent_core -= damage;
        healthBar.SetHealth(HPcurrent_core);
        flashDam.Flash();
    }

    IEnumerator DeadAnim()
    {
        Time.timeScale = 0.2f;
        //play dead anim
        yield return new WaitForSecondsRealtime(1f);
        gameOverControl.SlideIn();
        Time.timeScale = 0;

    }
}
