using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UpgradeType
{
    WeaponUnlock

}
[CreateAssetMenu]
[SerializeField]
public class UpgradeDeta : ScriptableObject
{
    public UpgradeType upgradeType;
    public string Name;
    public Sprite icon;

    public GameObject skillObject;
}
