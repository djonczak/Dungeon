using System.Collections.Generic;
using UnityEngine;

namespace Adventurer.Player
{
    [CreateAssetMenu(menuName = "Player Data")]
    public class AdventurerData : ScriptableObject
    {
        public Weapon.MeleeWeaponData MeleeWeapon;
        public Weapon.RangeWeaponData RangeWeapon;
        public float GoldAmount;
        public int SmallPotion;
        public int MediumPotion;
        public int BigPotion;

        public List<QuestSystem.Quest> Mission = new List<QuestSystem.Quest>();
    }
}
