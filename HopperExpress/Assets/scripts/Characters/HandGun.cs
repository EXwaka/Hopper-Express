using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject handGunImg;
    public GameObject reloadAnim;
    public Transform bulletSpawnPoint;
    public int ammo = 10;
    public int bulletLeft = 10;
    public float reloadTime = 3;
    public TextMeshProUGUI ammoText;
    public Animator animator;
    bool reloading =false;
    public int bulletCount = 6; // �l�u�ƶq
    public float spreadAngle = 20f; // �������׽d��
    //public GameObject text;

    void Start()
    {
        reloadAnim.SetActive(false);
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
        //Debug.Log(" handgun" + reloading);
        if (Input.GetMouseButtonDown(0) && bulletLeft > 0&&!reloading)
        {
            Shoot(bulletPrefab, bulletSpawnPoint);
        }

        if (Input.GetKeyDown(KeyCode.R) && !reloading)
        {
            StartCoroutine(Reload());
        }
        
        if (bulletLeft<=0 )
        {
            if (Input.GetMouseButtonDown(0)&&!reloading)
            {
                StartCoroutine(Reload());
            }
        }

        // Check for the E key press to update ammo display
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    UpdateAmmoUI();
        //}
    }

    public void Shoot(GameObject bulletPrefab, Transform bulletSpawnPoint)
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = bulletSpawnPoint.position.z - Camera.main.transform.position.z;

            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // �p��o�g��V
            Vector3 shootDirection = (worldMousePosition - bulletSpawnPoint.position).normalized;


            for (int i = 0; i < bulletCount; i++)
            {
                // �H���ͦ��@�Ӱ�������
                float angleOffset = Random.Range(-spreadAngle, spreadAngle);

                // �p�����᪺�s��V
                Quaternion rotationOffset = Quaternion.Euler(0, 0, angleOffset);
                Vector3 spreadDirection = rotationOffset * shootDirection;

                // �p��l�u�����ਤ��
                float angle = Mathf.Atan2(spreadDirection.y, spreadDirection.x) * Mathf.Rad2Deg;

                // �ͦ��l�u�ó]�m����
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, 0, angle - 90));

                // �]�m�l�u�t��
                bullet.GetComponent<Rigidbody>().velocity = spreadDirection * 40f;
            }

            // ����}�j�ʵe�M����
            animator.SetTrigger("IsFiring");
            FindObjectOfType<AudioManager>().Play("Gun2");

            // ��s�l�u�Ѿl�ƶq�ç�sUI
            bulletLeft--;
            UpdateAmmoUI();
        }
    }

    IEnumerator Reload()
    {
        reloading = true;
        WeaponSwap.reloading = true;

        ammoText.fontSize = 45;
        ammoText.text = "�˶�...";

        handGunImg.SetActive(false);
        reloadAnim.SetActive(true);//anim start
        yield return new WaitForSeconds(reloadTime);
        reloadAnim.SetActive(false);//anim start
        handGunImg.SetActive(true);

        bulletLeft = ammo;
        UpdateAmmoUI();

        WeaponSwap.reloading = false;
        reloading = false;
    }

    private void UpdateAmmoUI()
    {
        if (gameObject.activeSelf && ammoText != null)
        {
            if (bulletLeft > 0)
            {
                ammoText.fontSize = 45;
                ammoText.text = $"{bulletLeft}/{ammo}";
                ammoText.gameObject.SetActive(true);
            }
            else
            {
                ammoText.fontSize = 30;
                ammoText.text = "�l�u�κ�!\n���U�ƹ�������!";
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