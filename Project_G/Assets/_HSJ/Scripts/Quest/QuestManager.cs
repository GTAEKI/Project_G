using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private QuestDataBase questData;
    [SerializeField]
    private GameObject questRoot;
    [SerializeField]
    private Mission[] missions;
    private int[] curNums;

    // if quests count and missions count are different, it occurs error. Refactoring needed 
    void Start()
    {
        missions = questRoot.GetComponentsInChildren<Mission>();
        SetMissionId();

        curNums = new int[questData.quests.Count];
        for(int i = 0; i < questData.quests.Count; i++)
        {
            curNums[i] = questData.quests[i].CurNum;
            missions[i].SetProgressText(questData.quests[i].CurNum, questData.quests[i].ClearNum);
        }
        CheckSavedData();
    }

    void SetMissionId()
    {
        int questLength = questData.quests.Count;
        for(int i = 0; i < questLength; i++)
        {
            missions[i].SetQuestID(questData.quests[i].ID);
        }
    }

    void CheckSavedData()
    {
        List<int> tempIDs = Managers.BaseMap.GetSavedObejctID();
        CountQuestNum(tempIDs);
    }

    // Need Refactoring 
    void CountQuestNum(List<int> tempIDs)
    {
        
        int length = tempIDs.Count;

        for (int i = 0; i < length; i++)
        {
            switch (tempIDs[i])
            {                
                case 2:
                    curNums[0]++;
                    missions[0].SetProgressText(curNums[0], questData.quests[0].ClearNum);
                    break;
                case 3:
                    curNums[1]++;
                    missions[1].SetProgressText(curNums[1], questData.quests[1].ClearNum);
                    break;
                case 4:
                    curNums[2]++;
                    missions[2].SetProgressText(curNums[2], questData.quests[2].ClearNum);
                    break;
                case 5:
                    curNums[3]++;
                    missions[3].SetProgressText(curNums[3], questData.quests[3].ClearNum);
                    break;
            }
        }
    }

    //void UpdateQuestLog()
    //{
    //    questText.text =
    //        $"{placementSystem.GetBuildingCount()} / { questData.quests[0].ClearNum}";
    //}

    //void CheckQuestClear()
    //{
    //    if (questData.quests[0].ClearNum <= placementSystem.GetBuildingCount())
    //    {
    //        // 퀘스트 클리어 

    //    }
    //}



}




