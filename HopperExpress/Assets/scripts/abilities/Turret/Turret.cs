using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : MonoBehaviour
{
    public float range = 10f;             // ���x�������d��
    public string enemyTag = "Enemy";     // �ĤH����
    public Transform partToRotate;        // �˷Ǫ����x�����]�q�`�O���ޡ^
    public float turnSpeed = 5f;          // ���x����t��
    public GameObject bulletPrefab;       // �l�u���w�s��
    public Transform firePoint;           // �l�u���o�g�I
    public float fireRate = 1f;           // �C��o�g���W�v
    private float fireCountdown = 0f;     // �o�g���˼ƭp��
    public Animator Turretfire;
    private Transform target;             // �ؼмĤH�� Transform

    void Start()
    {
        Turretfire = GetComponent<Animator>();
        // �w���˴��ؼ�
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        // �d��Ҧ��a��"Enemy"���Ҫ��ĤH
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity; // ��l�Ƴ̵u�Z�����L�a�j
        GameObject nearestEnemy = null; // �̾a�񪺼ĤH

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        // �p�G���̪񪺼ĤH�A�N��]���ؼ�
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

        // �˷ǼĤH
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,0f, rotation.z); // �u����z�b�A�O�����x�����˷�

        // �p�G�N�o�ɶ���F�A�h�o�g�l�u
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate; // ���m�N�o�ɶ�
        }

        fireCountdown -= Time.deltaTime; // ��s�N�o�p��
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
        // ø�s���x�����d�򪺻��U�u
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
