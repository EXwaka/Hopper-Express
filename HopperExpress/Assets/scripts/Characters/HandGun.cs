using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject handGunImg;
    public Transform bulletSpawnPoint;
    public int ammo = 10;
    public int bulletLeft = 10;
    public float reloadTime = 3;
    public TextMeshProUGUI ammoText;
    public Animator animator;
    bool reloading=false;
    //public GameObject text;

    void Start()
    {
        animator = GetComponent<Animator>();
        UpdateAmmoUI();
        reloading = false;

    }

    void OnEnable()
    {
        UpdateAmmoUI();
    }

    void OnDisable()
    {
        HideAmmoUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && bulletLeft > 0)
        {
            Shoot(bulletPrefab, bulletSpawnPoint);
        }
        else if (bulletLeft<=0 )
        {
            if (Input.GetMouseButtonDown(0)&&!reloading)
            {
                StartCoroutine(Reload());
            }
        }

        // Check for the E key press to update ammo display
        if (Input.GetKeyDown(KeyCode.E))
        {
            UpdateAmmoUI();
        }
    }

    public void Shoot(GameObject bulletPrefab, Transform bulletSpawnPoint)
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = bulletSpawnPoint.position.z - Camera.main.transform.position.z;

            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector3 shootDirection = (worldMousePosition - bulletSpawnPoint.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            bullet.GetComponent<Rigidbody>().velocity = shootDirection * 40f;
            animator.SetTrigger("IsFiring");

        }
        bulletLeft--;
        UpdateAmmoUI();
    }

    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);
        bulletLeft = ammo;
        UpdateAmmoUI();
        reloading = false;
    }

    private void UpdateAmmoUI()
    {
        if (gameObject.activeSelf && ammoText != null)
        {
            if (bulletLeft > 0)
            {
                handGunImg.SetActive(true);
                ammoText.fontSize = 45;
                ammoText.text = $"{bulletLeft}/{ammo}";
                ammoText.gameObject.SetActive(true);
            }
            else
            {
                handGunImg.SetActive(false);
                ammoText.fontSize = 30;
                ammoText.text = "¤l¼u¥ÎºÉ!\n«ö¤U·Æ¹«¥ªÁä¶ñ¸Ë!";
                ammoText.gameObject.SetActive(true);
            }
        }
    }

    private void HideAmmoUI()
    {
        if (ammoText != null)
        {
            ammoText.gameObject.SetActive(false);
        }
    }
}