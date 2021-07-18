using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TMP_InputField paddleSpeedBox;
    public TMP_InputField ballSpeedBox;

    public void Awake()
    {
        if (PersistenceManager.Instance.savedHighScoreName == "")
        {
            highScoreText.text = ""+PersistenceManager.Instance.savedHighScore;
        }
        else
        {
            highScoreText.text = PersistenceManager.Instance.savedHighScore + ", by " + PersistenceManager.Instance.savedHighScoreName;
        }//call persist man load, fill boxes
    }
    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void SaveSettings()
    {
        //persist man save
    }

    public void ResetHighScore()
    {
        PersistenceManager.Instance.cName = "ObSuVil";
        PersistenceManager.Instance.SaveHighScore(0);
        PersistenceManager.Instance.LoadHighScore();
        Awake();

    }
}
