using UnityEngine;
using UnityEngine.UI;

public class handGunBulletUI : MonoBehaviour
{
    public Text bulletText;
    private HandGun playerHandGun;

    void Start()
    {
        // ��쪱�a�� rifle �}��
        playerHandGun = FindObjectOfType<HandGun>();
        UpdateBulletCount(playerHandGun.bulletLeft);
        GetComponent<Text>();
    }

    void Update()
    {
        UpdateBulletCount(playerHandGun.bulletLeft);
    }

    public void UpdateBulletCount(int bulletCount)
    {
        if (bulletText != null)
        {

            if (bulletCount > 0)
            {
                bulletText.fontSize = 22;
                bulletText.text = $"{bulletCount}/{playerHandGun.ammo}";
            }
            else
            {
                bulletText.fontSize = 14;
                bulletText.text = "�l�u�κ�!\n��ˤ�...";
            }
        }

    }
}
