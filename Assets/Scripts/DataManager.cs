using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData
{
    /// <summary>
    /// 저장할 변수들을 나열
    /// Ex )
    /// public List<string> testDataA = new List<string>();
    /// public List<int> testDataB = new List<int>();
    /// public int gold;
    /// public int power;
    /// </summary>
}

public class DataManager : Singleton<DataManager>
{
    string path;

    void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");
        JsonLoad();
    }

    public void JsonLoad(string dataPath = "null")
    {
        if (dataPath != "null")
        {
            path = dataPath;
        }
        SaveData saveData = new SaveData();

        if (!File.Exists(path))
        {
            JsonSave();
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {
                // 불러올 데이터 대입
                // ex ) GameMgr.Instance.player.hp = saveData.hp;
            }
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();


        // 저장 할 데이터 대입
        // ex ) saveData.power = GameManager.instance.playerPower;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }
}