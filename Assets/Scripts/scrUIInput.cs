using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;


public class scrUIInput : MonoBehaviour
{
    public TMP_InputField NameInput;
    public TMP_Text BestScoreText;
    public TMP_Text WarningText;

    // Start is called before the first frame update
    void Start()
    {
        SetBestScore();
    }

    public void SetNewPlayer()
    {
        
    }

    private void SetBestScore()
    {
        var bestScore = scrManager.Instance.GetBestScore();
        if(bestScore == null)
            return;
        BestScoreText.text = "Best Score: " + bestScore.PlayerName + " : " + bestScore.Score.ToString(); 
    }

    public void StartGame()
    {
        if (NameInput.text == "")
        {
            WarningText.text = "Insert a name";
            return;
        }
        scrManager.Instance.PlayersName = NameInput.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
