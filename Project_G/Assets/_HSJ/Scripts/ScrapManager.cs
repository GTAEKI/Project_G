using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapManager
{
    public int Scrap { get; private set; }
    public string ScrapTxt { get; private set; }

    public ScrapManager()
    {
        Scrap = 0;
        ScrapTxt = Scrap.ToString();
    }

    public int GetCurrentScrap()
    {
        return Scrap;
    }

    public void AddScrap(int scrap)
    {
        Scrap += scrap;
        ChangeScrapText(Scrap);
    }

    public void RemoveScrap(int scrap)
    {
        if (Scrap >= scrap)
        {
            Scrap -= scrap;
        }
        else
        {
            // 실제 UI로 띄워줌
            Debug.LogError("보유 스크랩이 부족합니다.");
        }
        ChangeScrapText(Scrap);
    }
    
    public string GetCurrentScrapText()
    {
        return ScrapTxt;
    }

    private void ChangeScrapText(int curScrap)
    {
        ScrapTxt = curScrap.ToString();
    }
    

}
