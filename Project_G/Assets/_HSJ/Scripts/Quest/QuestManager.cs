using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private QuestDataBase questData;
    [SerializeField]
    private GridData gridData;

    public QuestManager()
    {
        InitializeQuest();
    }

    public int QuestCount { get; private set; }

    public void InitializeQuest()
    {
        //quests = questData.quests;
        //QuestCount = quests.Count;        
    }
    


}



