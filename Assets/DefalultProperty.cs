using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefalultProperty : MonoBehaviour
{
    // Start is called before the first frame update

    public  int a1v = 0;
    public  int a2v = 0;
    public  int a3v = 0;
    public  int a4v = 0;
    //public  


    public  bool a1bool = false;
    public  bool a2bool = false;
    public  bool a3bool = false;
    public  bool a4bool = false;


    public  bool isAchivments_1 = false;
    public  bool isAchivments_2 = false;
    public  bool isAchivments_3 = false;
    public  bool isAchivments_4 = false;

    public  float coins = 10000;
    public  float hearts = 5;
    void Start()
    {

    }
    public void def() 
    {
        StaticConfig.coins = coins;
        StaticConfig.hearts = hearts;
        // StaticConfig.a1v = a1v;
        // StaticConfig.a2v = a2v;
        // StaticConfig.a3v = a3v;
        // StaticConfig.a4v = a4v;
        // StaticConfig.a1bool = a1bool;
        // StaticConfig.a2bool = a2bool;
        // StaticConfig.a3bool = a3bool;
        // StaticConfig.a4bool = a4bool;


        StaticConfig.SaveLoadManager.saveGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
