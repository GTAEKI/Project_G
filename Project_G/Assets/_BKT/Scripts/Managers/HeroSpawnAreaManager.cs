using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class HeroSpawnAreaManager
{
    private Dictionary<string, bool> heroSpawnAreas  = new Dictionary<string, bool>();

    public HeroSpawnAreaManager()
    {
        for (int i = 0; i < (int)EHeroSpawnAreaName.End; i++) 
        {
            heroSpawnAreas.Add(((EHeroSpawnAreaName)i).ToString(), true);
        }
    }

    public bool IsSpawnAreaActive(GameObject spawnArea) 
    {
        if (heroSpawnAreas[spawnArea.name] == true)
            return true;

        return false;
    }

    public bool[] GetAliveHeroSpawnAreas(GameObject[] spawnAreas)
    {
        bool[] result = new bool [spawnAreas.Length];

        for (int i = 0; i < spawnAreas.Length; i++)
        {
            if (heroSpawnAreas[spawnAreas[i].name] == true)
            {
                result[i] = true;
            }
            else 
            {
                result[i] = false;
            }
        }

        return result;
    }

    public void SetUsedSpawnArea(GameObject UsedspawnArea) 
    {
        heroSpawnAreas[UsedspawnArea.name] = false;
    }
}
