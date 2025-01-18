using System.IO;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    public static StorageManager Instance;
    public int highestLevel;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int level;
    }

    public void SaveLevelData(int level)
    {
        SaveData data = new SaveData();
        data.level = level;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/level.json", json);
    }

    public void LoadLevelData()
    {
        string path = Application.persistentDataPath + "/level.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highestLevel = data.level;
        }
    }
}
