using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UpgradeType
{
    WeaponUpgrade,
    ItemUpgeade,
    WeaponUnlock,
    ItemUnlock

}
[CreateAssetMenu]

public class UpgradeDeta : ScriptableObject
{
    public UpgradeType upgradeType;
    public string Name;
    public Sprite icon;
}
