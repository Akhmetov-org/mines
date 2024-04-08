using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllReserses : MonoBehaviour
{

    public Text mainWindowCoins;
    public Text mainWindowHearts;
    public static bool changeCoinsValue(float valuechange, float multiplier = 1)
    {
        if ((StaticConfig.coins + (valuechange * multiplier)) < 0)
        {
            StaticConfig.buyCoin.SetActive(true);
            return false;
        }

        StaticConfig.coins += valuechange * multiplier;
        //PlayerPrefs.SetFloat("ValueCoin", StaticConfig.coins);
        StaticConfig.SaveLoadManager.saveGame();
        updateValueResurses();
        return true;
    }

    public static bool changeHeartsValue(float valuechange)
    {
        if ((StaticConfig.hearts + valuechange) < 0)
        {
            StaticConfig.buyHearth.SetActive(true);
            return false;
        }
        StaticConfig.hearts += valuechange;
        //PlayerPrefs.SetFloat("ValueHearth", StaticConfig.hearts);
        StaticConfig.SaveLoadManager.saveGame();
        updateValueResurses();
        return true;
    }

    public static void updateValueResurses()
    {
        StaticConfig.mainWindowCoins.text = StaticConfig.coins.ToString();
        StaticConfig.mainWindowHearts.text = StaticConfig.hearts.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {

        StaticConfig.mainWindowCoins = mainWindowCoins;
        StaticConfig.mainWindowHearts = mainWindowHearts;
        updateValueResurses();
    }

    public void LoseCoin(int valueLoseuCoin)
    {
        changeCoinsValue(valueLoseuCoin);

    }
    public void BuyCoin(int valueByuCoin)
    {
        StaticConfig.AchivmentsControll.upAchivka(2);
        changeCoinsValue(valueByuCoin);
    }
    public void BuyHearth(int valueByuHearth)
    {
        changeHeartsValue(valueByuHearth);
    }

    public static void youWinOrdern()
    {
        updateMbWin();
        StaticConfig.winWindowOrder.SetActive(true);
        if (StaticConfig.isWinOrder)
        {
            ControllReserses.changeCoinsValue(StaticConfig.nbWin); // ADD TO NIKITA
        };
        StaticConfig.isWinOrder = true;
        StaticConfig.AchivmentsControll.checkAchivkaTwo(StaticConfig.winWindowCastle, StaticConfig.isWinOrder);
        StaticConfig.AchivmentsControll.upAchivka(1);
    }

    public static void youLostOrdern()
    {
        StaticConfig.loseWindowOrder.SetActive(true);
    }
    public static void youWinCastle()
    {

        updateMbWin();
        StaticConfig.winWindowCastle.SetActive(true);
        if (StaticConfig.isWinCastle) return;
        StaticConfig.isWinCastle = true;
        StaticConfig.AchivmentsControll.upAchivka(1);

    }
    public static void updateMbWin()
    {
        foreach (Text elem in StaticConfig.mbWinTxt)
        {
            elem.text = StaticConfig.nbWin.ToString();
        }
    }


}
