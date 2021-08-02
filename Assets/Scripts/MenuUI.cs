using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public InputField nameField;
    public Text bestMessage;

    void Start()
    {
        if (nameField != null)
        {
            nameField.onValueChanged.AddListener(delegate { nameChanged(); });
        }

        updateBestMessage();
    }

    private void updateBestMessage()
    {
        if (bestMessage != null)
        {
            bestMessage.text = "Best Score : " + persistObj.Instance.bestPlayerName + " : " + persistObj.Instance.bestScore;
        }
    }

    public void nameChanged()
    {
        Debug.Log("Name changed.");

        persistObj.Instance.nowPlayerName = nameField.text;

        updateBestMessage();
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void exitApp()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
