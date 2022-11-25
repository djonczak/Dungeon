namespace QuestSystem
{
    [System.Serializable]
    public class MissionsState
    {
        public Quest Quest { get; set; }
        public int TargetID;
        public bool Complete;
        public int RequiredAmount;
        public int CurrentAmount;
        public string Text;

        public void CheckQuest()
        {
            if (CurrentAmount >= RequiredAmount)
            {
                Completed();
            }
        }

        public void GotTarget(int id)
        {
            CurrentAmount++;
            CheckQuest();
        }

        public void Completed()
        {
            Complete = true;
        }
    }
}


