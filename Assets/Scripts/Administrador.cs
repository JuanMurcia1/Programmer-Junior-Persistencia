using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Administrador : MonoBehaviour
{

    public static Administrador Instance;

    public string textIngresado;
    public int score1;
    public string bestPlayer;

    

    
    

    private void  Awake() {
        if (Instance != null)
        {
            
            Destroy(gameObject);
            
            
        }else{
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
        }

        LoadBestPlayer();

    }


[System.Serializable]
class SaveData
{
    public string bestPlayer;
    public int score1;
}

public void SaveBestPlayer()
{
    SaveData data = new SaveData();
    data.bestPlayer = bestPlayer;
    data.score1= score1;

    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
}

public void LoadBestPlayer()
{
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        bestPlayer =  data.bestPlayer;
        score1= data.score1;
    }
}

}
   

