using UnityEngine;
using UnityEngine.UI;

public class rifleBulletUI : MonoBehaviour
{
    public Text bulletText;
    private rifle playerRifle;

    void Start()
    {
        // ��쪱�a�� rifle �}��
        playerRifle = FindObjectOfType<rifle>();
        UpdateBulletCount(playerRifle.bulletLeft);
        GetComponent<Text>();
    }

    void Update()
    {
        UpdateBulletCount(playerRifle.bulletLeft);
    }

    public void UpdateBulletCount(int bulletCount)
    {
        if (bulletText != null)
        {

            if (bulletCount > 0)
            {
                bulletText.fontSize = 22;
                bulletText.text = $"{bulletCount}/{playerRifle.ammo}";
            }
            else
            {
                bulletText.fontSize = 14;
                bulletText.text = "�l�u�κ�!\n��ˤ�...";
            }
        }

    }
}
