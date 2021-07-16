using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public void StartNew()
    {
        DataManager.Instance.playerInputName = GameObject.Find("Name").GetComponent<Text>().text;
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        DataManager.Instance.SaveHighScore();
        DataManager.Instance.Exit();
    }
}
