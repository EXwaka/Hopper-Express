using System.Collections;
using TMPro;
using UnityEngine;

public class rifle : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject character;
    public GameObject rifleImg;
    public Transform bulletSpawnPoint;
    public int ammo = 20;
    public int bulletLeft = 20;
    public float reloadTime = 3;
    public float shootForce = 0.2f;
    public bool isShooting = false;
    private bool firstShot = false;
    public float cooldown = 0.1f;
    float shootTimer = 0;
    float shootTimer2 = 0;
    public TextMeshProUGUI ammoText;
    public Animator animator;
    bool reloading = false;
    public GameObject reloadAnim;
    private void Start()
    {
        reloadAnim.SetActive(false);
        reloading = false;
        isShooting = false;
        firstShot = false;
        shootTimer = 0; 
        UpdateAmmoUI();
        animator = gameObject.GetComponent<Animator>();
    }
    void OnEnable()
    {
        UpdateAmmoUI();
    }

    void OnDisable()
    {
        HideAmmoUI();
    }

    void Update()
    {
        //Debug.Log(" rifle" + reloading);

        if (Input.GetMouseButtonDown(0) && firstShot == false && bulletLeft > 0&& !reloading)
        {
            Shoot(bulletPrefab, bulletSpawnPoint);
            firstShot = true;
            shootTimer2 += Time.deltaTime;
        }

        if (shootTimer2 >= cooldown)
        {
            firstShot = false;
        }

        if (Input.GetMouseButton(0) && bulletLeft > 0&& !reloading)
        {
            isShooting = true;

        }
        else
        {
            isShooting = false;
            animator.SetBool("IsFiring", false);
        }

        if (Input.GetKeyDown(KeyCode.R) && !reloading)
        {
            StartCoroutine(Reload());
        }

        if (bulletLeft <= 0 && !reloading)
        {
                StartCoroutine(Reload());
        }

        if (isShooting)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= cooldown)
            {
                Shoot(bulletPrefab, bulletSpawnPoint);
                shootTimer = 0f;
            }
        }
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

            Vector3 shootDirection = (worldMousePosition - bulletSpawnPoint.position).normalized;

            //bullet shoot direction
            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.Euler(0, 0, angle-90));
            //
            bullet.GetComponent<Rigidbody>().velocity = shootDirection * 40f;
            animator.SetTrigger("IsFiring");

            Vector3 screenToWorldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, bulletSpawnPoint.position.z - Camera.main.transform.position.z));
            float characterScreenX = character.transform.position.x;

            if (screenToWorldMousePosition.x < characterScreenX)
            {
                // 滑鼠在角色左側
                Vector3 characterPosition = character.transform.position;
                characterPosition.x += shootForce; // 向右移動
                character.transform.position = characterPosition;
            }
            else
            {
                // 滑鼠在角色右側
                Vector3 characterPosition = character.transform.position;
                characterPosition.x -= shootForce; // 向左移動
                character.transform.position = characterPosition;
            }
        }

        FindObjectOfType<AudioManager>().Play("Gun1");



        bulletLeft--;
        UpdateAmmoUI();

    }

    IEnumerator Reload()
    {
        reloading = true;
        WeaponSwap.reloading = true;

        WeaponSwap.reloading = true;
        isShooting = false;
        shootTimer = 0f;
        ammoText.fontSize = 45;
        ammoText.text = "裝填中...";
        rifleImg.SetActive(false);
        reloadAnim.SetActive(true);//anim start
        yield return new WaitForSeconds(reloadTime);
        reloadAnim.SetActive(false);//anim ends
        rifleImg.SetActive(true);

        bulletLeft = ammo;
        isShooting = true;
        WeaponSwap.reloading = false;
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
