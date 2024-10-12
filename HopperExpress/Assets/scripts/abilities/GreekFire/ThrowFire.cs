using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFire : MonoBehaviour
{
    [SerializeField] private Camera mainCam;

    public Transform SpawnPoint;
    public GameObject projectile;
    public float speedx=3;
    public float speedy=5;
    bool readyToThrow;
    static public float greekFireCD=10;
    static public bool CDactivated = false;
    float timer=0;
    // Start is called before the first frame update
    void Start()
    {
        timer = greekFireCD;
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
        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;


        if (Input.GetKeyDown(KeyCode.Q)&&Skills.skill_throwfire==true&&readyToThrow==true)
        {
            readyToThrow = false;
            CDactivated = true;

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
            //原始腳本 朝玩家面對方向擲出
            //if (CharacterMove.moveRight==true)
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
        }
        if (readyToThrow==false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                readyToThrow = true;
                timer = greekFireCD;
                CDactivated = false;

            }
        }
    }

}
