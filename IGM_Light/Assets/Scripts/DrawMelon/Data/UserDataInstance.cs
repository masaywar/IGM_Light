using UnityEngine;
using System.IO;

public class UserDataInstance : Singleton<UserDataInstance> 
{

    public UserData UserData;

    public int CurrentWorld;
    public int CurrentStage;

    public int LastClearStage;

    public int[] WorldsLastClearData = new int[FixedValues.WORLDS];


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
        LoadData();
        SaveData();

        for (int k=0; k<FixedValues.WORLDS; k++)
        {
            WorldsLastClearData[k] = 0;
            for(int j=0; j<FixedValues.STAGES; j++)
            {
                if(UserData.UserClearData[k].userClearData[j])
                    WorldsLastClearData[k] = WorldsLastClearData[k] < FixedValues.STAGES ? WorldsLastClearData[k]+1 : WorldsLastClearData[k];
            }
        }
    }

    public T LoadData<T>(string fileName)
    {
        try
        {
            #if UNITY_EDITOR
            string path = Application.dataPath + "/Data/" + fileName;
            #else
            string path = Application.persistentDataPath + "/" + fileName;
            #endif

        
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                T t = JsonUtility.FromJson<T>(json);      
                return json != "" ? t : default;
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
        }
        return default;
    }

    public void LoadData()
    {
        UserData = LoadData<UserData>("userdata.json");

        if(UserData == default)
        {
            ClearData[] temp =  new ClearData[FixedValues.WORLDS];
                ScoreData[] tempi = new ScoreData[FixedValues.WORLDS];

                for(int k=0; k<temp.Length; k++)
                {
                    temp[k] = new ClearData();
                    tempi[k] = new ScoreData();
                }

                UserData = new UserData(
                    1, 
                    0, 
                    temp,
                    tempi
                );
        }
    }

    public void SaveData()
    {
        SaveData<UserData>(UserData, "userdata.json");
    }

    public void SaveData<T>(T data, string fileName)
    {
        try
        {
            string json = JsonUtility.ToJson(data, true);

            if (json.Equals("{}"))
            {
                return;
            }

            #if UNITY_EDITOR
            string path = Application.dataPath+ "/Data/" + fileName;
            #else
            string path = Application.persistentDataPath + "/" + fileName;
            #endif
            
            File.WriteAllText(path, json);
        }
        catch (FileNotFoundException e)
        {
            Debug.Log("The file was not found:" + e.Message);
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log("The directory was not found: " + e.Message);
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be opened:" + e.Message);
        }
    }

    public int GetLastClearStageOfWorld(int world)
    {
        return WorldsLastClearData[world];
    }

    public void UpdateUserData(int? score=null)
    {
        if(score != null)
        {
            int lastScore = UserData.UserScoreData[CurrentWorld-1].userScoreData[CurrentStage-1];

            UserData.UserScoreData[CurrentWorld-1].userScoreData[CurrentStage-1]
                = Mathf.Max(score.Value, lastScore);
        }

        if(UserData.UserClearData[CurrentWorld-1].userClearData[CurrentStage-1])
            return;

        UserData.UserClearData[CurrentWorld-1].userClearData[CurrentStage-1] = true;

        if(score != null)
        {
            int lastScore = UserData.UserScoreData[CurrentWorld-1].userScoreData[CurrentStage-1];

            UserData.UserScoreData[CurrentWorld-1].userScoreData[CurrentStage-1]
                = Mathf.Max(score.Value, lastScore);
        }

        for(int k=0; k<FixedValues.WORLDS; k++)
        {
            bool breakFlag = false;

            for(int j=0; j<FixedValues.STAGES; j++)
            {
                if(!UserData.UserClearData[k].userClearData[j])
                {
                    UserData.Worlds = k+1;
                    UserData.Stages = j;
                    breakFlag = true;
                    break;
                }
            }        
            if(breakFlag) break;
        }

        SaveData();
        LoadData();

        WorldsLastClearData[CurrentWorld-1] 
        = WorldsLastClearData[CurrentWorld-1] < FixedValues.STAGES && WorldsLastClearData[CurrentWorld-1] < CurrentStage? 
            WorldsLastClearData[CurrentWorld-1]+1 :WorldsLastClearData[CurrentWorld-1];
    }
}