using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    public float range = 10f;             // 炮台的偵測範圍
    public string enemyTag = "Enemy";     // 敵人標籤
    public Transform partToRotate;        // 瞄準的炮台部分（通常是炮管）
    public float turnSpeed = 5f;          // 炮台旋轉速度
    public GameObject bulletPrefab;       // 子彈的預製件
    public Transform firePoint;           // 子彈的發射點
    public float fireRate = 1f;           // 每秒發射的頻率
    private float fireCountdown = 0f;     // 發射的倒數計時
    public Animator Turretfire;
    private Transform target;             // 目標敵人的 Transform

    void Start()
    {
        Turretfire = GetComponent<Animator>();
        // 定時檢測目標
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        // 查找所有帶有"Enemy"標籤的敵人
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity; // 初始化最短距離為無窮大
        GameObject nearestEnemy = null; // 最靠近的敵人

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // 如果找到最近的敵人，將其設為目標
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
            return;

        // 瞄準敵人
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,0f, rotation.z); // 只旋轉z軸，保持炮台水平瞄準

        // 如果冷卻時間到了，則發射子彈
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate; // 重置冷卻時間
        }

        fireCountdown -= Time.deltaTime; // 更新冷卻計時
    }

    void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("turretFire");

        Vector3 direction = (target.position - firePoint.position).normalized;

        Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, direction);

        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, bulletRotation);


        TurretBullet bullet = bulletGO.GetComponent<TurretBullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }

        //Fire animation
        Transform headTransform = transform.Find("head");
        if (headTransform != null)
        {
            Animator headAnimator = headTransform.GetComponent<Animator>();
            if (headAnimator != null)
            {
                headAnimator.SetTrigger("TurretFire");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // 繪製炮台偵測範圍的輔助線
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
