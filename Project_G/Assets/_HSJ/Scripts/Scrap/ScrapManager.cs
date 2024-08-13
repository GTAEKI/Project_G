using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapManager
{
    public int Scrap { get; private set; }
    public string ScrapTxt { get; private set; }
    public EventHandler addScrapEvent;

    private bool scrapUIActive;
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

    public void RemoveScrap(int scrap, MonoBehaviour mono)
    {
        if (Scrap >= scrap)
        {
            Scrap -= scrap;
        }
        else
        {
            //mono.StartCoroutine(InfoTimer());
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
    
    IEnumerator InfoTimer()
    {
        float time = 0;
        Managers.UI.Get<UI_ScrapInfo>().gameObject.SetActive(true);

        while (time <= 2)
        {
            time += Time.deltaTime;
            
        }
        Managers.UI.Get<UI_ScrapInfo>().gameObject.SetActive(false);

        yield return null;
    }

}
