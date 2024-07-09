using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{

    [SerializeField] Image icon;

    public void Set(UpgradeDeta upgradeDeta)
    {
        icon.sprite=upgradeDeta.icon;
    }

    internal void Clean()
    {
        icon.sprite = null;
    }
}
