using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    public enum WeaponType
    {
        Sword,
        Crossbow,
    };

    public string weaponName;
    public WeaponType weaponType;
    public float weaponDamage;
    public float weaponCriticalChance;
    public float goldCost;

}
