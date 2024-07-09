using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] List<UpgradeButton> upgradeButtons;

    public void OpenPanel(List<UpgradeDeta> upgradeDetas)
    {
        for (int i = 0; i < upgradeDetas.Count; i++)
        {
            upgradeButtons[i].Set(upgradeDetas[i]);
        }
    }
}
