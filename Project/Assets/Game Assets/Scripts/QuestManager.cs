using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> quests;    
}

[System.Serializable]
public class Quest
{
    public string name;
    public int percentComplete;
}
