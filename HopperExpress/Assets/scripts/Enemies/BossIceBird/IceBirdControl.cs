using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBirdControl : MonoBehaviour
{
    Animator animator;
    private int Damage = 20;
    private float idleMinTime = 5f;
    private float idleMaxTime = 8f;
    public GameObject iceBurstPrefab;  
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Wavespawner.monsCount += 1;

        StartCoroutine(IdleAttackRoutine());
    }


    IEnumerator IdleAttackRoutine()
    {
        while (true)
        {
            animator.SetBool("Walk", true);
            yield return new WaitForSeconds(Random.Range(idleMinTime, idleMaxTime));

            AnimationAttack();

            Invoke("SpawnIceBursts", 1.6f);
            yield return new WaitForSeconds(2.3f);
            
            animator.SetTrigger("Down");
            yield return new WaitForSeconds(1.7f);

            AnimationIdle();
        }


    }

    void AnimationAttack()
    {
        animator.SetBool("Walk", false);
        animator.SetTrigger("Attack");
    }

    void AnimationIdle()
    {
        animator.SetBool("Walk", true);
    }
    void SpawnIceBursts()
    {
        List<int> selectedIndexes = new List<int>();
        while (selectedIndexes.Count < 6)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);

            if (!selectedIndexes.Contains(randomIndex))
            {
                selectedIndexes.Add(randomIndex);
                Instantiate(iceBurstPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
            }
        }
        Invoke("Attack", 0.3f);

    }
    void Attack()
    {
        FindObjectOfType<AudioManager>().Play("Eagle");

        Core core = FindObjectOfType<Core>();
        if (core != null)
        {
            core.GetHit(Damage);
        }
    }

}
