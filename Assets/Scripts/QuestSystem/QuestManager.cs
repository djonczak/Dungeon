using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem 
{
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager instance;

        public List<Quest> QuestList = new List<Quest>();
        public Adventurer.Player.AdventurerData Player;

        public void OnEnable()
        {
            DeathEvent.OnEnemyDeath += GotTarget;
            InteractEvent.OnInteract += GotTarget;
        }

        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            }

            foreach (Quest quest in Player.Mission)
            {
                QuestList.Add(quest);
            }

            DontDestroyOnLoad(this);
        }

        public void GotTarget(int id)
        {
            Debug.Log("Got target " + id);
            for (int i = 0; i < QuestList.Count; i++)
            {
                if (QuestList[i].MissionState.TargetID == id)
                {
                    QuestList[i].MissionState.GotTarget(id);
                    if (QuestList[i].MissionState.Complete == true)
                    {
                        QuestComplited(QuestList[i]);
                    }
                    return;
                }
            }
        }

        public void QuestComplited(Quest quest)
        {
            Player.GoldAmount += quest.GetReward();
        }

        private void OnDestroy()
        {
            DeathEvent.OnEnemyDeath -= GotTarget;
            InteractEvent.OnInteract -= GotTarget;
        }
    }
}
