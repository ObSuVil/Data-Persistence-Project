using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI nameBox;
    public TextMeshProUGUI scoreBox;

    private void Start()
    {
        scoreBox.text = "Reigning Champion: " + PersistenceManager.Instance.savedHighScoreName + "\n Score: " + PersistenceManager.Instance.savedHighScore;
    }

    public void StartGame()
    {
        PersistenceManager.Instance.score = 0;
        PersistenceManager.Instance.cName = nameBox.text;
        SceneManager.LoadScene(1, LoadSceneMode.Single);

    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

}
