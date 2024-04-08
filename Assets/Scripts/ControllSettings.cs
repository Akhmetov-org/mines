using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllSettings : MonoBehaviour
{
    public Sprite EnableStar;
    public Sprite DisableStar;
    public List<Button> allStar;

    public void starClick(int nomberClick)
    {
        for (int i = 0; i < 5; i++) allStar[i].GetComponent<Image>().sprite = DisableStar;
        for (int i = 0; i <= nomberClick; i++) allStar[i].GetComponent<Image>().sprite = EnableStar;
        StaticConfig.AchivmentsControll.upAchivka(3);
    }
}
