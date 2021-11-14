using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public string playerName;
    public string bestPlayer;
    int highScore;

    public int HighScore { get => highScore; private set => highScore = value; }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName = "";
        public int highScore = 0;
    }

    public void SaveRecord(int score)
    {
        HighScore = score;
        SaveData saveData = new SaveData();
        saveData.playerName = playerName;
        saveData.highScore = HighScore;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/saveData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighScore = data.highScore;
            bestPlayer = data.playerName;
        }
    }
}