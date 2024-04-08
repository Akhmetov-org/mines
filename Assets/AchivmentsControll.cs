using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AchivmentsControll : MonoBehaviour
{
    public Achivka[] AchivkaList;

    [System.Serializable]
    public struct Achivka
    {
        //public int maxValueSlider;
        public int currnetValueSlider;
        public Slider Slider;
        public bool isUses;
        public int valueCoins;
        public Button butActive;

        public Text text;
    }


    public void Start()
    {
        StaticConfig.achievements = AchivkaList;
        updateUIAchivka();
    }

    public void loadAchivka(Save.AchievementStruct[] saveAchievments)
    {
        for (int i = 0; i < 4; i++)
        {
            AchivkaList[i].currnetValueSlider = saveAchievments[i].valueSlider;
            AchivkaList[i].isUses = saveAchievments[i].isUses;
        }
    }

    public void clickAhivka(int nomerAchivka)
    {
        AchivkaList[nomerAchivka].isUses = true;
        AchivkaList[nomerAchivka].butActive.gameObject.SetActive(false);
        ControllReserses.changeCoinsValue(AchivkaList[nomerAchivka].valueCoins);
        StaticConfig.SaveLoadManager.saveGame();
    }

    public void checkAchivkaTwo(bool isCastle, bool isOrder)
    {
        if (isCastle && isOrder) upAchivka(1);
    }

    public void upAchivka(int nomerAchivka)
    {
        AchivkaList[nomerAchivka].currnetValueSlider++;
        updateUIAchivka();
    }

    public void updateUIAchivka()
    {
        for (int i = 0; i < 4; i++)
        {
            AchivkaList[i].text.text = AchivkaList[i].currnetValueSlider + "/" + AchivkaList[i].Slider.maxValue;

            AchivkaList[i].Slider.value = AchivkaList[i].currnetValueSlider;
            if (AchivkaList[i].isUses)
                AchivkaList[i].butActive.gameObject.SetActive(false);
            if (AchivkaList[i].currnetValueSlider == AchivkaList[i].Slider.maxValue && !AchivkaList[i].isUses)
            {
                AchivkaList[i].butActive.interactable = true;
            }
        }

        StaticConfig.SaveLoadManager.saveGame();
    }
}