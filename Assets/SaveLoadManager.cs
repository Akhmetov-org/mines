using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    string filePath;
    public static Save save;
    public GameObject TaskBG;

    private void OnEnable()
    {
        filePath = Application.persistentDataPath + "/save.gamesave";
        loadGame();
    }

    public void saveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();

        save.SaveAchievements(StaticConfig.achievements);
        save.coins = StaticConfig.coins;
        save.hearts = StaticConfig.hearts;

        save.lastLogin = StaticConfig.lastLogin;
        save.currentStreak = StaticConfig.currentStreak;
        save.isRewardGot = StaticConfig.isRewardGot;

        bf.Serialize(fs, save);
        fs.Close();
    }

    public void loadGame()
    {
        if (!File.Exists(filePath)) return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);


        save = (Save)bf.Deserialize(fs);
        fs.Close();

        StaticConfig.currentStreak = save.currentStreak;
        StaticConfig.isRewardGot = save.isRewardGot;
        StaticConfig.lastLogin = save.lastLogin;

        StaticConfig.coins = save.coins;
        StaticConfig.hearts = save.hearts;

        TaskBG.GetComponent<AchivmentsControll>().loadAchivka(save.achievements);
    }
}


[System.Serializable]
public class Save
{
    public AchievementStruct[] achievements = new AchievementStruct[4];

    public float coins;
    public float hearts;

    public string lastLogin;
    public int currentStreak;
    public bool isRewardGot;

    [System.Serializable]
    public struct AchievementStruct
    {
        public int valueSlider;
        public bool isUses;

        public AchievementStruct(int valueSlider, bool isUses)
        {
            this.valueSlider = valueSlider;
            this.isUses = isUses;
        }
    }

    public void SaveAchievements(AchivmentsControll.Achivka[] achievements)
    {
        for (int i = 0; i < achievements.Length; i++)
        {
            this.achievements[i] = new AchievementStruct(achievements[i].currnetValueSlider, achievements[i].isUses);
        }
    }
}