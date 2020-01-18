using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AdventurerData : ScriptableObject
{
    public MeleeWeaponData meleeWeapon;
    public RangeWeaponData rangeWeapon;
    public float goldAmount;
    public int smallPotion;
    public int mediumPotion;
    public int bigPotion;

    public List<Quest> mission = new List<Quest>();
}
