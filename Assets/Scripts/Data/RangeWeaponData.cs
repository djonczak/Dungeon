using UnityEngine;

[CreateAssetMenu(menuName = "Range Weapon Data")]
public class RangeWeaponData : ScriptableObject
{
    public string weaponName;
    public GameObject weaponModel;
    public string projectileName;
    public float weaponDamage;
    public float weaponCriticalChance;
    public float projectileSpeed;
    public bool canKnockBack;
    public float goldCost;
}
