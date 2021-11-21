using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI paddleSpeedBox;
    public TextMeshProUGUI ballSpeedBox;


    public void Awake()
    {

    }

    private void Start()
    {
        if (PersistenceManager.Instance.savedHighScoreName == "")
        {
            highScoreText.text = "" + PersistenceManager.Instance.savedHighScore;
        }
        else
        {
            highScoreText.text = PersistenceManager.Instance.savedHighScore + ", by " + PersistenceManager.Instance.savedHighScoreName;
        }

       updateCustBoxTexts();

    }

    void updateCustBoxTexts()
    {
        paddleSpeedBox.text = "" + PersistenceManager.Instance.custPaddleSpeed;
        ballSpeedBox.text = "" + PersistenceManager.Instance.custBallSpeed;
        highScoreText.text = "Champ: " + PersistenceManager.Instance.savedHighScoreName + ", Score: " + PersistenceManager.Instance.savedHighScore;
    }
    
    public void IncreasePSpeed()
    {
        PersistenceManager.Instance.custPaddleSpeed += 10;
        updateCustBoxTexts();
    }

    public void DecreasePSpeed()
    {
        PersistenceManager.Instance.custPaddleSpeed -= 10;
        updateCustBoxTexts();
    }
    public void DefaultPSpeed()
    {
        PersistenceManager.Instance.custPaddleSpeed = 0;
        updateCustBoxTexts();
    }



    public void IncreaseBSpeed()
    {
        PersistenceManager.Instance.custBallSpeed += 10;
        updateCustBoxTexts();
    }

    public void DecreaseBSpeed()
    {
        PersistenceManager.Instance.custBallSpeed -= 10;
        updateCustBoxTexts();
    }
    public void DefaultBSpeed()
    {
        PersistenceManager.Instance.custBallSpeed = 0;
        updateCustBoxTexts();
    }

    public void ReturnToTitleScreen()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void SaveSettings()
    {
        PersistenceManager.Instance.SaveSettings();
    }

    public void ResetHighScore()
    {
        PersistenceManager.Instance.cName = "ObSuVil";
        PersistenceManager.Instance.SaveHighScore(0);
        PersistenceManager.Instance.LoadHighScore();
        updateCustBoxTexts();

    }
}
