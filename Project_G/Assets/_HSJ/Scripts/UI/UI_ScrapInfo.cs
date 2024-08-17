using UnityEngine;
using TMPro;

public class UI_ScrapInfo : UI_Base
{
    [SerializeField]
    private TMP_Text scrapText;

    void Awake()
    {
        scrapText = GetComponentInChildren<TMP_Text>();
    }

    void Start()
    {
        scrapText.text = Managers.Scrap.GetCurrentScrapText();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Managers.Scrap.RemoveScrap(100,this);
        }
    }
    public override bool Init()
    {
        if(base.Init() == false) { return false; }
        Register();
        return true;
    }

    protected override void Register()
    {
        Managers.UI.Register(this);
    }

    private void OnDestroy()
    {
        Managers.UI.Remove<UI_ScrapInfo>();
    }

}
