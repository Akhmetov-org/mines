// ADD TO NIKITA
using System;
using UnityEngine;
using UnityEngine.UI;

public class DailyLoginRewards : MonoBehaviour
{
    public Text currentStreakText;
    public Text currentStreakTextBG;
    public Text currentStreakTextBGAll;
    public GameObject currentStreakSlider;
    public GameObject takeButton;
    public GameObject viewButton;
    public Text rewardText;

    private void OnEnable()
    {
        LoadLoginDate();
        CheckDailyLogin();
        UpdateLayout();
    }

    private void LoadLoginDate()
    {
        // Загрузка последней даты входа и текущей последовательности из PlayerPrefs
        if (string.IsNullOrEmpty(StaticConfig.lastLogin))
        {
            ResetStreak();
            StaticConfig.lastLogin = DateTime.Now.ToString();
        }
    }

    private void UpdateLayout()
    {
        currentStreakSlider.GetComponent<Slider>().value = StaticConfig.currentStreak % 7;
        currentStreakText.text = "Day " + StaticConfig.currentStreak % 7 + "/7";
        currentStreakTextBG.text = StaticConfig.currentStreak % 7 + "/7";

        currentStreakTextBGAll.text = StaticConfig.currentStreak + " days";
    }

    private void CheckDailyLogin()
    {
        DateTime currentLoginDate = DateTime.Now;
        DateTime lastLoginDate = DateTime.Parse(StaticConfig.lastLogin);

        TimeSpan timeDifference = currentLoginDate.Subtract(lastLoginDate);

        // print("last" + StaticConfig.lastLogin);
        // print("current " + currentLoginDate);
        // print("timeDiff" + timeDifference);

        if (timeDifference.Days == 0)
        {
            // Игрок уже заходил в игру сегодня
            StaticConfig.isRewardGot = true;
            ChangeButton();
            return;
        }
        else if (timeDifference.Days == 1)
        {
            // Игрок заходит в игру на следующий день, увеличиваем стик
            print("streak ++");
            StaticConfig.isRewardGot = false;
            StaticConfig.currentStreak++;
        }
        else
        {
            // Прошло больше одного дня, сбрасываем стик
            StaticConfig.isRewardGot = false;
            ResetStreak();
        }

        // Сохраняем дату последнего входа и текущую последовательность
        StaticConfig.lastLogin = currentLoginDate.ToString();
    }

    private void ResetStreak()
    {
        StaticConfig.currentStreak = 1;
    }

    private void ChangeButton()
    {
        takeButton.SetActive(false);
        viewButton.SetActive(true);
        rewardText.text = "Recieved";
    }

    public void GiveReward()
    {
        print("reward" + StaticConfig.isRewardGot);
        if (!StaticConfig.isRewardGot)
        {
            int rewardAmount = 50;
            ControllReserses.changeCoinsValue(rewardAmount);
            StaticConfig.isRewardGot = true;
            ChangeButton();
        }
    }
}
