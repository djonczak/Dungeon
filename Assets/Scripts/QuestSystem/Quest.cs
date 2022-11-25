using UnityEngine;

namespace QuestSystem
{
    [CreateAssetMenu]

    public class Quest : ScriptableObject
    {
        public bool IsUnlocked;
        [Range(0, 1)] public float UnlockAmount;

        public string Title;
        public string Description;
        public int GoldAmount;
        public MissionType MissionType;
        public Location Location;

        public MissionsState MissionState;

        public int GetReward()
        {
            return GoldAmount;
        }
    }

    public enum Location
    {
        Dungeon,
        Swamp,
        DustyRoad
    };

    public enum MissionType
    {
        Kill,
        Gather
    };
}
