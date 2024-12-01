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

        // 計算子彈與目標的方向和距離
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;


        // 子彈向目標移動
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
