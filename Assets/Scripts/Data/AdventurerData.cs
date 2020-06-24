using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data")]
public class AdventurerData : ScriptableObject
{
    public MeleeWeaponData MeleeWeapon;
    public RangeWeaponData RangeWeapon;
    public float GoldAmount;
    public int SmallPotion;
    public int MediumPotion;
    public int BigPotion;

    public List<Quest> Mission = new List<Quest>();
}
