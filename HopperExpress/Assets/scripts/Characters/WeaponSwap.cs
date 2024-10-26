using Unity.VisualScripting;
using UnityEngine;
public class WeaponSwap : MonoBehaviour
{
    public int selectedWeapon = 0;
    public static bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading) return;
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            FindObjectOfType<AudioManager>().Play("weapon_swap");
            selectedWeapon++;

            if(selectedWeapon >= 2) 
            {
                selectedWeapon = 0;
            
            }
            SelectWeapon();

        }
    }
    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if(i== selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }

}
