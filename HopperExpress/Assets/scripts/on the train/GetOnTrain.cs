using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetOnTrain : MonoBehaviour
{
    public GameObject Ebutton;
    public GameObject Character;
    public GameObject Train;
    // Start is called before the first frame update
    void Start()
    {
        Ebutton.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Ebutton.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            if (SkillSelectUI.Chapter1Done)
            {
                TrainMoneAnim.TrainGo = true;
                Invoke("Chapter2", 5f);
                Invoke("TrainNoGo", 5f);

            }
            else if (!SkillSelectUI.Chapter1Done)
            {
                TrainMoneAnim.TrainGo = true;
                Invoke("Chapter1", 5f);
                Invoke("TrainNoGo", 5f);
            }
        }

            if (TrainMoneAnim.TrainGo)
            {
                Character.transform.position = new Vector3(Train.transform.position.x, Character.transform.position.y, Character.transform.position.z);
            }
            else
            {
                Character.transform.position = Character.transform.position;
            }

    }
    void TrainNoGo()
    {
        TrainMoneAnim.TrainGo = false;

    }
    void Chapter1()
    {
        SceneManager.LoadSceneAsync("Level1-0");

    }
    void Chapter2()
    {
        SceneManager.LoadSceneAsync("Level2-1");

    }
    void Chapter3()
    {
        SceneManager.LoadSceneAsync("Level3-1");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Ebutton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Ebutton.SetActive(false);
        }
    }
}
