using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GotoStaticClass : MonoBehaviour
{
    public List<Sprite> stateCastlePlayList = new List<Sprite>();
    public List<Sprite> SweetsCastlePlayList = new List<Sprite>();
    public List<float> percentList = new List<float>();

    public float coins = 0;
    public float hearts = 0;

    public GameObject buyCoin;
    public GameObject buyHearth;
    public GameObject loseWindow;
    public GameObject winWindowOrder;
    public GameObject loseWindowOrder;
    public GameObject winWindowCastle;
    public GridCastleScript GridCastleScript;
    public Text[] mbWinTxt;
    public AchivmentsControll AchivmentsControll;

    public SaveLoadManager SaveLoadManager;
    public GameObject TaskBG;
    private void OnEnable()
    {
        StaticConfig.SaveLoadManager = SaveLoadManager;

        StaticConfig.stateCastlePlayList = stateCastlePlayList.ToArray();
        StaticConfig.SweetsCastlePlayList = SweetsCastlePlayList.ToArray();
        StaticConfig.percentList = percentList.ToArray();
        StaticConfig.currentOrderItem = null;
        StaticConfig.buyCoin = buyCoin;
        StaticConfig.buyHearth = buyHearth;
        StaticConfig.loseWindowCastle = loseWindow;
        StaticConfig.winWindowOrder = winWindowOrder;
        StaticConfig.winWindowCastle = winWindowCastle;
        StaticConfig.loseWindowOrder= loseWindowOrder;
        StaticConfig.GridCastleScript = GridCastleScript;

        StaticConfig.mbWinTxt = mbWinTxt;
        StaticConfig.AchivmentsControll = AchivmentsControll;

        StaticConfig.achievements = TaskBG.GetComponent<AchivmentsControll>().AchivkaList;





        //coins = SaveLoadManager.saveStatic.coins;
        //hearts = SaveLoadManager.saveStatic.hearth;
        
    }
    public void Start()
    {
        // StaticConfig.a1v = SaveLoadManager.save.a1v;
        // StaticConfig.a2v = SaveLoadManager.save.a2v;
        // StaticConfig.a3v = SaveLoadManager.save.a3v;
        // StaticConfig.a4v = SaveLoadManager.save.a4v;
        //
        //
        // StaticConfig.a1bool = SaveLoadManager.save.a1bool;
        // StaticConfig.a2bool = SaveLoadManager.save.a2bool;
        // StaticConfig.a3bool = SaveLoadManager.save.a3bool;
        // StaticConfig.a4bool = SaveLoadManager.save.a4bool;
    }
}
