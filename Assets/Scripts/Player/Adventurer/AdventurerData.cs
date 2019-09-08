using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AdventurerData : ScriptableObject
{
    public Weapon meleeWeapon;
    public Weapon rangeWeapon;
    public float goldAmount;
    public float smallPotion;
    public float mediumPotion;
    public float BigPotion;

    public List<Quest> mission = new List<Quest>();
}
