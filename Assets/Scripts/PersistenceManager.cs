using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    public string savedHighScoreName;
    public int savedHighScore;
    public string cName;
    public int score;
   

    public float maxBallSpeed;
    public float custPaddleSpeed;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

      LoadHighScore();
      LoadSettings();
    }



    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }    

    class SettingsData
    {
        public float pSpeed;
        public float mBSpeed;
    }

    public void SaveSettings()
    {
        SettingsData data = new SettingsData();
        //data.pSpeed = valueinthetextbox;
        //data.mBSpeed = valueinotherbox;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", json);
    }

    public void LoadSettings()
    {
        string path = Application.persistentDataPath + "/gamesettings.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SettingsData data = JsonUtility.FromJson<SettingsData>(json);

            
        }
    }

    public void SaveHighScore(int newScore)
    {
        SaveData data = new SaveData();
        data.playerName = cName;
        data.highScore = newScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        savedHighScoreName = data.playerName;
        savedHighScore = data.highScore;
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            savedHighScoreName = data.playerName;
            savedHighScore = data.highScore;

        }

    }
}
