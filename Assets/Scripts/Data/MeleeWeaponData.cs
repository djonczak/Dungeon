using UnityEngine;

namespace Weapon 
{
    [CreateAssetMenu(menuName = "Item/Melee Weapon Data")]
    public class MeleeWeaponData : Shop.Item
    {
        public enum WeaponType
        {
            Sword,
            Axe,
            Mace,
        };

        public WeaponType Type;
        public GameObject WeaponModel;
        public float WeaponDamage { get; }
        public float WeaponCriticalChance { get; }
        public float WeaponAttackSpeed { get; }
        public bool CanKnockBack { get; }
    }
}
