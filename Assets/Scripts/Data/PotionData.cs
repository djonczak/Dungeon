using UnityEngine;

namespace Shop
{
    [CreateAssetMenu(menuName = "Item/Potion Data")]
    public class PotionData : Item
    {
        public enum Type
        {
            Health,
            Stamina,
        }

        public Type PotionType;
        public float EffectAmount;
    }
}
