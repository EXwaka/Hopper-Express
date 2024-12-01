using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    private float Damage = 5f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // �p��l�u�P�ؼЪ���V�M�Z��
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;


        // �l�u�V�ؼв���
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<MonsterManager>(out MonsterManager enemyComponent))
        {
            enemyComponent.TakeDamage(Damage);
        }
            Destroy(gameObject); 
    }
}
