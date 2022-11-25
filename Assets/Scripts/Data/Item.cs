using JetBrains.Annotations;
using UnityEngine;

namespace Shop
{
    public class Item : ScriptableObject
    {
        public string ItemName;
        public UnityEngine.UI.Image ItemIcon;
        public ItemType ItemOption;
        public string Description;
        public int GoldCost;

        public enum ItemType
        {
            Weapon,
            Potion
        }
    }
}
