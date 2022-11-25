using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(menuName = "Item/Range Weapon Data")]
    public class RangeWeaponData : Shop.Item
    {
        public string ProjectileName;
        public GameObject WeaponModel;
        public float WeaponDamage;
        public float WeaponCriticalChance;
        public float ProjectileSpeed;
        public bool CanKnockBack;
    }
}
