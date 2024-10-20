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
    public int bulletCount = 6; // 子彈數量
    public float spreadAngle = 20f; // 偏移角度範圍
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

            // 計算發射方向
            Vector3 shootDirection = (worldMousePosition - bulletSpawnPoint.position).normalized;


            for (int i = 0; i < bulletCount; i++)
            {
                // 隨機生成一個偏移角度
                float angleOffset = Random.Range(-spreadAngle, spreadAngle);

                // 計算旋轉後的新方向
                Quaternion rotationOffset = Quaternion.Euler(0, 0, angleOffset);
                Vector3 spreadDirection = rotationOffset * shootDirection;

                // 計算子彈的旋轉角度
                float angle = Mathf.Atan2(spreadDirection.y, spreadDirection.x) * Mathf.Rad2Deg;

                // 生成子彈並設置旋轉
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, 0, angle - 90));

                // 設置子彈速度
                bullet.GetComponent<Rigidbody>().velocity = spreadDirection * 40f;
            }

            // 播放開槍動畫和音效
            animator.SetTrigger("IsFiring");
            FindObjectOfType<AudioManager>().Play("Gun2");

            // 更新子彈剩餘數量並更新UI
            bulletLeft--;
            UpdateAmmoUI();
        }
    }

    IEnumerator Reload()
    {
        reloading = true;
        WeaponSwap.reloading = true;

        ammoText.fontSize = 45;
        ammoText.text = "裝填中...";

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
                ammoText.text = "子彈用盡!\n按下滑鼠左鍵填裝!";
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