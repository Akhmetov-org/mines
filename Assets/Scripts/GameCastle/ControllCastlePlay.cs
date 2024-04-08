using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllCastlePlay : MonoBehaviour
{

//
    public static void blockAllbuttons()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int k = 0; k < 3; k++)
            {
                StaticConfig.allElemcastleList[k, i].interectble(false);
            }
        }
    }
    public static void clouseString(ElemScripts elemPanel)
    {
        for (int k = 0; k < 3; k++)
        {
            StaticConfig.allElemcastleList[k, StaticConfig.currentActiveStringCastlePlay - 1].currentButtonImage.sprite = StaticConfig.stateCastlePlayList[2];
        }
        elemPanel.currentButtonImage.sprite = StaticConfig.stateCastlePlayList[0];
        elemPanel.childrenImage.sprite = StaticConfig.SweetsCastlePlayList[UnityEngine.Random.Range(1, 13)];
        nextString();
    }
    public static void nextString()
    {
        if (StaticConfig.currentActiveStringCastlePlay > 5)
        {
            StaticConfig.nbWin = StaticConfig.currentStavka * StaticConfig.percentList[StaticConfig.currentActiveStringCastlePlay - 1];
            ControllReserses.youWinCastle();
            return;
        }
        blockAllbuttons();



        for (int k = 0; k < 3; k++)
        {
            StaticConfig.allElemcastleList[k, StaticConfig.currentActiveStringCastlePlay].interectble(true);
            StaticConfig.allElemcastleList[k, StaticConfig.currentActiveStringCastlePlay].currentButtonImage.sprite = StaticConfig.stateCastlePlayList[1];
        }

        if (StaticConfig.currentActiveStringCastlePlay > 0) 
        { 
            StaticConfig.GridCastleScript.collectNow.gameObject.SetActive(true); 
            StaticConfig.nbWin = StaticConfig.currentStavka * StaticConfig.percentList[StaticConfig.currentActiveStringCastlePlay - 1];
            ControllReserses.updateMbWin();
        }


    }
    public static void choiseSworm(ElemScripts elemPanel)
    {
        blockAllbuttons();
        for (int k = 0; k < 3; k++)
        {
            StaticConfig.allElemcastleList[k, StaticConfig.currentActiveStringCastlePlay].currentButtonImage.sprite = StaticConfig.stateCastlePlayList[2];
        }
        elemPanel.currentButtonImage.sprite = StaticConfig.stateCastlePlayList[0];
        StaticConfig.GridCastleScript.collectNow.gameObject.SetActive(false);
        StaticConfig.loseWindowCastle.SetActive(true);
    }
}
