using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestDataBase : ScriptableObject
{
    public List<Quest> quests;
}

[Serializable]
public class Quest
{
    [field: SerializeField]
    public string Name { get; private set; }
    [field: SerializeField]
    public int ID { get; private set; }
    [field: SerializeField]
    public int ClearTargetNum { get; private set; }
    [field: SerializeField]
    public int CurClearNum { get; private set; }
    [field: SerializeField]
    public bool IsClear { get; private set; }
}
