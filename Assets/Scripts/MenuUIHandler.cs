using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler: MonoBehaviour
{

    public TMP_InputField nameField;
    public Text highScoreText;
    string playerName;


    void Start()
    {
        UIManager.Instance.LoadRecord();

        string bestPlayer = UIManager.Instance.bestPlayer;
        int highScore = UIManager.Instance.HighScore;

        if (highScore != 0)
        {
            highScoreText.text = $"High Score: {bestPlayer}: { highScore} ";
        }
        else
        {
            highScoreText.text = "";
        }


    }

    public void SaveName()
    {
        playerName = nameField.text;
    }


    public void StartNew()
    {
        UIManager.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }

}
