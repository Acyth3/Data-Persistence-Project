using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerInputName;

    public string playerHSName;
    public int playerHSPoints;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    public void Exit()
    {

        SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    [System.Serializable]
    class SaveData
    {
        public string playerHSName;
        public int playerHSPoints;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerHSName = playerHSName;
        data.playerHSPoints = playerHSPoints;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerHSName = data.playerHSName;
            playerHSPoints = data.playerHSPoints;

            return;
        }

        playerHSName = "Player";
        playerHSPoints = 0;
    }
}
