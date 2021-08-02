using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class persistObj : MonoBehaviour
{
    public static persistObj Instance;

    public string nowPlayerName;
    public string bestPlayerName;
    public int bestScore = 0;

    private void Awake()
    {
        if(Instance!= null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        loadData();
    }

    public void newBestScore(int newScore)
    {
        if(newScore > bestScore)
        {
            bestScore = newScore;
            bestPlayerName = nowPlayerName;

            saveData();
        }
    }

    [System.Serializable]
    class bestData
    {
        public int bestScore;
        public string playerName;
    }

    public void saveData()
    {
        bestData bd = new bestData();
        bd.bestScore = bestScore;
        bd.playerName = bestPlayerName;

        string jsonStr = JsonUtility.ToJson(bd);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", jsonStr);
    }

    public void loadData()
    {
        string path = Application.persistentDataPath + "/saveData.json";
        if (File.Exists(path))
        {
            string jsonStr = File.ReadAllText(path);
            bestData bd = JsonUtility.FromJson<bestData>(jsonStr);
            bestPlayerName = bd.playerName;
            bestScore = bd.bestScore;
        }
    }
}
