using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StaticManager : MonoBehaviour
{
    public static StaticManager Instance;

    public string PlayerName;
    public int HighScore;

    public string CurrentPlayerName;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        loadHighScore();
    }

    // Update is called once per frame
    class SaveData
    {
        public string PlayerName;

        public string CurrentPlayerName;
        public int HighScore;
    }

    public void loadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            PlayerName = data.PlayerName;
            HighScore = data.HighScore;
        }
    }

    public void saveHighScore()
    {
        SaveData data = new SaveData();
        data.PlayerName = CurrentPlayerName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);
    }
}
