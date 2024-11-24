using System.Collections;
using UnityEngine;

public class BerserkControl : MonoBehaviour
{
    public GameObject berserkEF; 
    private bool activated; 

    static public float CD = 15f; 
    public float berserkDuration = 5f; 
    private float berserkDamageMultiplier = 1.5f; 

    static public bool isOnCooldown = false;
    public float fireRateMultiplier = 0.8f;

    static public bool UIActivated;
    void Start()
    {
        activated = Skills.skill_berserk;
        berserkDuration = 5;

        if (berserkEF != null)
        {
            Vector3 effectPosition = transform.position + new Vector3(0, -1, 0);
            berserkEF.transform.position = effectPosition;
            berserkEF.SetActive(false);
        }
        //InvokeRepeating("count", 0f,1);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && activated && !isOnCooldown)
        {
            berserkEF.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Berserk");

            StartCoroutine(Berserking());
        }

    }

    IEnumerator Berserking()
    {
        UIActivated = true;
        ApplyBerserkDamage(true); ApplyBerserkFireRate(true);
        isOnCooldown = true;

        yield return new WaitForSeconds(berserkDuration);

        UIActivated = false;
        berserkEF.SetActive(false);
        ApplyBerserkDamage(false); ApplyBerserkFireRate(false);

        yield return new WaitForSeconds(CD);
        isOnCooldown = false;
    }

    void ApplyBerserkDamage(bool isBerserk)
    {
        HandGunBullet[] bullets = FindObjectsOfType<HandGunBullet>();
        RifleBullet[] bullets2 = FindObjectsOfType<RifleBullet>();

        foreach (HandGunBullet bullet in bullets)
        {
            bullet.handGunBulletDamage = isBerserk
                ? bullet.handGunBulletDamage * berserkDamageMultiplier
                : bullet.handGunBulletDamage / berserkDamageMultiplier;
        }

        foreach (RifleBullet bullet in bullets2)
        {
            bullet.rifleBulletDamage = isBerserk
                ? bullet.rifleBulletDamage * berserkDamageMultiplier
                : bullet.rifleBulletDamage / berserkDamageMultiplier;
        }
    }
    void ApplyBerserkFireRate(bool isBerserk)
    {

        rifle[] rifles = FindObjectsOfType<rifle>();

        foreach (rifle rifle in rifles)
        {
            rifle.cooldown = isBerserk
                ? rifle.cooldown * fireRateMultiplier
                : rifle.cooldown / fireRateMultiplier;
        }

    }
}
