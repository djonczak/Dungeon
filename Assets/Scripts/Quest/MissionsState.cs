using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MissionsState
{
    public Quest Quest { get; set; }
    public int targetID;
    public bool complete;
    public int requiredAmount;
    public int currentAmount;
    public string text;

    public void CheckQuest()
    {
        if(currentAmount >= requiredAmount)
        {
            Completed();
        }
    }

    public void GotTarget(int id)
    {
        currentAmount++;
        CheckQuest();
    }

    public void Completed()
    {
        complete = true;
    }
}


