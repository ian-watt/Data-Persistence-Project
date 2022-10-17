using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public string highScoreName;
    public int attemptScore;
    public int highScore;
    public string playerName;
    public bool isNameSet = false;

    [ContextMenu("Print Name")]
    public void printName()
    {
        Debug.Log(playerName);
    }

    [System.Serializable]
    class SaveData
    {
        public string highScoreName;
        public int attemptScore;
        public int highScore;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.attemptScore = Instance.attemptScore;
        if(Instance.attemptScore > highScore)
        {
            data.highScoreName = Instance.playerName;
            data.highScore = Instance.attemptScore;
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Instance.highScoreName = data.highScoreName;
            Instance.highScore = data.highScore;
        }
    }
}
