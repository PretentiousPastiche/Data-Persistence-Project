using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class scrManager : MonoBehaviour
{
    public static scrManager Instance;

    public string PlayersName {get; set;}
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    string path => Application.persistentDataPath + "/score.json";

    [System.Serializable]
    public class BestScore
    {
        public string PlayerName;
        public int Score;
    }

    public BestScore GetBestScore()
    {   
        if(!File.Exists(path))
            return null;
        string json = File.ReadAllText(path);
        BestScore data = JsonUtility.FromJson<BestScore>(json);
        return data;
    }

    private string GetJSonToSave(int score) 
    {
        BestScore newScore = new BestScore();
        newScore.PlayerName = PlayersName;
        newScore.Score = score;
        return JsonUtility.ToJson(newScore);
    } 

    public void SaveBestScore(int score)
    {
        if(GetBestScore().Score > score)
            return;
        File.WriteAllText(path, GetJSonToSave(score));
    } 
    
}
