using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GridCastleScript : MonoBehaviour
{

    public Button butStartGame;
    public Button collectNow;
    public Button plusStavka;
    public Button minusStavka;
    [SerializeField] private Button elemGrid;
    [SerializeField] private GameObject grid;
    private Button currentElemGrid;
    private int typeElemGrid;


    //[SerializeField] private int StaticConfig.currentStavka = 100;
    [SerializeField] private Text StavkaTxt;
    //[SerializeField] private List<ElemScripts> listStingElem = new List<ElemScripts>();
    [SerializeField] private ElemScripts[,] allElemList_1 = new ElemScripts[3, 6];
    private void OnEnable()
    {
        updateStavka();
    }
    public void startGame(bool isMenu = false)
    {
        if (!isMenu)
        {
            if (StaticConfig.coins - StaticConfig.currentStavka < 0)
            {
                StaticConfig.buyCoin.SetActive(true);
                return;
            }
            else if (StaticConfig.hearts - 1 < 0)
            {
                StaticConfig.buyHearth.SetActive(true);
                return;
            }

            ControllReserses.changeCoinsValue(-StaticConfig.currentStavka);
            ControllReserses.changeHeartsValue(-1);

        }
        print("!!!!!!");
        newCastleGame();



        collectNow.gameObject.SetActive(false);

        StaticConfig.loseWindowCastle.SetActive(false);
        StaticConfig.winWindowCastle.SetActive(false);





        for (int i = 0; i < 6; i++)
        {

            for (int k = 0; k < 3; k++)
            {
                currentElemGrid = Instantiate(elemGrid, grid.transform);
                currentElemGrid.GetComponent<ElemScripts>().nomberElem = new Vector2Int(k, i);
                allElemList_1[k, i] = currentElemGrid.GetComponent<ElemScripts>();
                allElemList_1[k, i].getType(1);
                allElemList_1[k, i].currentPercent.text = "x" + StaticConfig.percentList[i];
            }
            typeElemGrid = Random.Range(0, 3);
            allElemList_1[typeElemGrid, i].getType(0);
        }
        StaticConfig.allElemcastleList = allElemList_1;
        ControllCastlePlay.nextString();
    }

    public void newCastleGame()
    {
        StaticConfig.nbWin = StaticConfig.currentStavka;
        ControllReserses.updateMbWin();
        butStartGame.gameObject.SetActive(false);
        plusStavka.gameObject.SetActive(false);
        minusStavka.gameObject.SetActive(false);
        StaticConfig.allElemcastleList = null;
        StaticConfig.currentActiveStringCastlePlay = 0;
        while (grid.transform.childCount > 0)
        {
            DestroyImmediate(grid.transform.GetChild(0).gameObject);
        }
    }

    public void castleInMenu()

    {


    }
    public void EndGame()
    {
        ControllReserses.changeCoinsValue(StaticConfig.nbWin);
        StaticConfig.currentStavka = 0;
        updateStavka();
        butStartGame.gameObject.SetActive(true);
        plusStavka.gameObject.SetActive(true);
        minusStavka.gameObject.SetActive(true);
        while (grid.transform.childCount > 0)
        {
            DestroyImmediate(grid.transform.GetChild(0).gameObject);
        }
        ControllReserses.youWinCastle();
        ///newCastleGame(); ///????
    }
    public void changeStavka(int valueStavka)
    {
        if (valueStavka < 0 && StaticConfig.currentStavka < Mathf.Abs(valueStavka))
        {
            return;
        }
        StaticConfig.currentStavka += valueStavka;
        updateStavka();
    }
    public void updateStavka()
    {
        StavkaTxt.text = StaticConfig.currentStavka.ToString();
    }




}
