using UnityEngine;
using UnityEngine.UI;

public class rifleBulletUI : MonoBehaviour
{
    public Text bulletText;
    private rifle playerRifle;

    void Start()
    {
        // 找到玩家的 rifle 腳本
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
                bulletText.text = "子彈用盡!\n填裝中...";
            }
        }

    }
}
