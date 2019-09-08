using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Quest : ScriptableObject
{
    public bool isUnlocked;
    [Range(0, 1)] public float unlockAmount;

    public string title;
    public string description;
    public int goldAmount;
    public MissionType missionType;
    public Location location;

    public MissionsState missionState;

    public int GetReward()
    {
        return goldAmount;
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
