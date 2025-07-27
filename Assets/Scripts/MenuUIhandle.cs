using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIhandle : MonoBehaviour
{
    public TMP_InputField inputName;
    public TMP_Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        inputName = GameObject.Find("Name").GetComponent<TMP_InputField>();
        inputName.onEndEdit.AddListener(TextChange);
        highScoreText = GameObject.Find("Best Score").GetComponent<TMP_Text>();
        if(StaticManager.Instance.PlayerName != "")
        {
            highScoreText.text = "Best Score: " + StaticManager.Instance.PlayerName + " : " + StaticManager.Instance.HighScore;
        }else
        {
            highScoreText.text = "Best Score: No Score Yet";
        }
    }



    public void TextChange(string name)
    {
        StaticManager.Instance.CurrentPlayerName = name;
    }

    public void quitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void StartNew()
    {
        SceneManager.LoadScene("main");
    }
}
