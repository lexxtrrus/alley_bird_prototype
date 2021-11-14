using System;
using UnityEngine;

public static class Profile 
{
    
    [Serializable]
    private class ScoreData
    {
        public int previousScore = 0;
        public int bestScore = 0;
    }

    [Serializable]
    private class PlayerData
    {
        public int coins = 0;
    }

    private static ScoreData scoreData;
    private static PlayerData playerData;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void CheckData()
    {
        CheckScoreData();
        CheckPlayerData();
    }

    private static void CheckScoreData()
    {
        if(scoreData != null) return;

        scoreData = GetData<ScoreData>("ScoreData");
    }

    private static void CheckPlayerData()
    {
        if(playerData != null) return;

        playerData = GetData<PlayerData>("PlayerData");
    }

    private static T GetData<T>(string key) where T: new()
    {
        if(PlayerPrefs.HasKey(key))
        {
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
        }

        var data = new T();
        PlayerPrefs.SetString(key, JsonUtility.ToJson(data));
        return data; 
    }

    public static void Save(bool score = false, bool player = false)
    {
        if (score)
        {
            PlayerPrefs.SetString("ScoreData", JsonUtility.ToJson(scoreData));                
        }

        if(player)
        {
            PlayerPrefs.SetString("PlayerData", JsonUtility.ToJson(playerData));  
        }
    }

    public static void DeleteAll()
    {
        PlayerPrefs.DeleteKey("ScoreData");
        PlayerPrefs.DeleteKey("PlayerData");
    }

    public static int BestScore
    {
        get => scoreData.bestScore;
        set
        {
            scoreData.bestScore = value;
            Save(score: true);
        } 
    }
        
    public static int PreviousScore
    {
        get => scoreData.previousScore;
        set
        {
            scoreData.previousScore = value;
            Save(score: true);
        }  
    }

    public static int Coins
    {
        get => playerData.coins;
        set
        {
            playerData.coins = value;
            Save(player: true);
        }  
    }
}
