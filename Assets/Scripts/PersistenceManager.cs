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
    public TextMeshProUGUI nameBox;

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
        GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>().text = "Reigning Champion: " + savedHighScoreName + "\n Score: " + savedHighScore;

    }

    public void StartGame()
    {
        score = 0;
        cName = nameBox.text;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
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
