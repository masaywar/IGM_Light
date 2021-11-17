using System.Threading;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class UserDataInstance : MonoBehaviour 
{
    private static UserDataInstance instance = null;

    public static UserDataInstance Instance
    {
        get
        {
            if(instance == null)
                return null;

            return instance;
        }
    }


    public UserData UserData;

    public int CurrentWorld;
    public int CurrentStage;

    public Dictionary<int, Dictionary<int, Tuple<int, bool>>> UserSavedData;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
        
        UserData =
        LoadData<UserData>("userdata.json");
        SaveData<UserData>(UserData, "userdata.json");

        UserSavedData = new Dictionary<int, Dictionary<int, Tuple<int, bool>>>();

        for (int k=0; k<=FixedValues.WORLDS; k++)
        {
            UserSavedData.Add(k, new Dictionary<int, Tuple<int, bool>>());
            for(int j=0; j<=FixedValues.STAGES; j++)
                UserSavedData[k].Add(j, new Tuple<int, bool>( UserData.UserScoreData[j], UserData.UserClearData[k]));
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

            print(path);
        
            if (File.Exists(path))
            {
                print("a");
                string json = File.ReadAllText(path);
                T t = JsonUtility.FromJson<T>(json);      
                return t;
            }

            else
            {
                bool[] temp =  new bool[FixedValues.WORLDS * FixedValues.STAGES];
                int [] tempi = new int[FixedValues.WORLDS * FixedValues.STAGES];

                UserData = new UserData(
                    1, 
                    0, 
                    temp,
                    tempi
                );
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
                Debug.Log("json null");
                return;
            }

            #if UNITY_EDITOR
            string path = Application.dataPath+ "/Data/" + fileName;
            #else
            string path = Application.persistentDataPath + "/" + fileName;
            #endif
            
            File.WriteAllText(path, json);

            Debug.Log(json);
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
}