using UnityEngine;
using UnityEngine.UI;

public class handGunBulletUI : MonoBehaviour
{
    public Text bulletText;
    private HandGun playerHandGun;
    public GameObject handGunImg;

    void Start()
    {
        // ��쪱�a�� HandGun �}��
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
                handGunImg.SetActive(true);
                bulletText.fontSize = 22;
                bulletText.text = $"{bulletCount}/{playerHandGun.ammo}";
            }
            else
            {
                bulletText.fontSize = 14;
                bulletText.text = "�l�u�κ�!\n��ˤ�...";
                handGunImg.SetActive(false);
            }
        }

    }
}
