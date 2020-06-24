using UnityEngine;

[CreateAssetMenu(menuName = "Item/Range Weapon Data")]
public class RangeWeaponData : Item
{
    public string ProjectileName;
    public GameObject WeaponModel;
    public float WeaponDamage;
    public float WeaponCriticalChance;
    public float ProjectileSpeed;
    public bool CanKnockBack;
}
