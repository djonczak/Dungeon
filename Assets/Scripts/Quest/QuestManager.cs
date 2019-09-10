using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public List<Quest> questList = new List<Quest>();
    public AdventurerData player;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        DeathEvent.OnEnemyDeath += GotTarget;
        InteractEvent.OnInteract += GotTarget;

        foreach(Quest quest in player.mission)
        {
            questList.Add(quest);
        }

        DontDestroyOnLoad(this);
    }

    public void GotTarget(int id)
    {
        Debug.Log("Dostał sygnał " + id);
        for(int i = 0; i < questList.Count; i++)
        {
            if(questList[i].missionState.targetID == id)
            {
                questList[i].missionState.GotTarget(id);
                if(questList[i].missionState.complete == true)
                {
                    QuestComplited(questList[i]);
                }
                return;
            }
        }
    }
    
    public void QuestComplited(Quest quest)
    {
        player.goldAmount += quest.GetReward();
    }
}
