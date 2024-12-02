using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typewriter : MonoBehaviour
{
    Animator animator;
    static public int monsCount;
    public float delay = 10f;
    private bool AudioPlayed;
    private bool AnimationPlayed;

    // Start is called before the first frame update
    void Start()
    {
        AnimationPlayed = false;
        AudioPlayed = false;
        monsCount = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (monsCount > 5)
        {
            if(!AudioPlayed)
            {
                AudioManager audio = FindObjectOfType<AudioManager>();
                audio.Play("type");
                AudioPlayed=true;
            }
            animator.SetBool("start", true);
            StartCoroutine(EndPaper());
        }
    }

    private IEnumerator EndPaper()
    {
        yield return new WaitForSeconds(delay);
        if (!AnimationPlayed)
        {
            animator.SetTrigger("finish");
            AnimationPlayed=true;
        }
    }
}
