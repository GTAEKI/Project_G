using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private QuestDataBase questData;
    [SerializeField]
    private GridData gridData;
    [SerializeField]
    private PlacementSystem placementSystem;
    [SerializeField]
    private TMP_Text questText;

    void Update()
    {
        UpdateQuestLog();
        CheckQuestClear();
    }

    void UpdateQuestLog()
    {
        questText.text = questData.quests[0].Name +
            " " + placementSystem.GetBuildingCount() + 
            " / " + questData.quests[0].ClearTargetNum;
    }

    void CheckQuestClear()
    {
        if (questData.quests[0].ClearTargetNum <= placementSystem.GetBuildingCount())
        {
            // 퀘스트 클리어 
        }
    }



}



