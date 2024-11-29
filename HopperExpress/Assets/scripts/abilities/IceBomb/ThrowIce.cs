using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowIce : MonoBehaviour
{
    [SerializeField] private Camera mainCam;

    public Transform SpawnPoint;
    public GameObject projectile;
    public float speedx = 3;
    public float speedy = 3;
    bool readyToThrow;
    static public float iceBombCD = 6;
    static public bool CDactivated=false;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        CDactivated = false;
        timer = iceBombCD;
        readyToThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -mainCam.transform.position.z;
        Vector3 targetPosition = mainCam.ScreenToWorldPoint(mousePosition);
        targetPosition.z = 0f;
        Vector3 directionToMouse = targetPosition - transform.position;
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;//ºË·Ç¤è¦V

        //Debug.Log(timer);
        if (Input.GetKeyDown(KeyCode.Alpha1) && Skills.skill_throwice == true && readyToThrow == true)
        {
            FindObjectOfType<AudioManager>().Play("greekFire");

            CDactivated = true;
            readyToThrow = false;
            //if (CharacterMove.moveRight == true)
            //{
            //    Vector3 spawnPosition = new Vector3(0.8f + SpawnPoint.position.x, 1f + SpawnPoint.position.y, SpawnPoint.position.z);
            //    var _projectile = Instantiate(projectile, spawnPosition, transform.rotation);
            //    _projectile.GetComponent<Rigidbody>().velocity = new Vector3(speedx, speedy, 0);
            //}
            //else
            //{
            //    Vector3 spawnPosition = new Vector3(-0.8f + SpawnPoint.position.x, 1f + SpawnPoint.position.y, SpawnPoint.position.z);
            //    var _projectile = Instantiate(projectile, spawnPosition, transform.rotation);
            //    _projectile.GetComponent<Rigidbody>().velocity = new Vector3(-speedx, speedy, 0);
            //}
            if (directionToMouse.x < 0)
            {
                Vector3 spawnPosition = new Vector3(-0.8f + SpawnPoint.position.x, 1f + SpawnPoint.position.y, SpawnPoint.position.z);
                var _projectile = Instantiate(projectile, spawnPosition, transform.rotation);
                _projectile.GetComponent<Rigidbody>().velocity = new Vector3(-speedx, speedy, 0);



            }
            else
            {

                Vector3 spawnPosition = new Vector3(0.8f + SpawnPoint.position.x, 1f + SpawnPoint.position.y, SpawnPoint.position.z);
                var _projectile = Instantiate(projectile, spawnPosition, transform.rotation);
                _projectile.GetComponent<Rigidbody>().velocity = new Vector3(speedx, speedy, 0);


            }
        }
        if (readyToThrow == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                readyToThrow = true;
                timer = iceBombCD;
                CDactivated = false;
            }
        }
    }
}
