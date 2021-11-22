using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
    [System.Serializable] private class PoolPrefab
    {
        public string path;
        public int poolNum;

        public PoolPrefab(string path, int poolNum) 
        {
            this.path = path;
            this.poolNum = poolNum;
        }
    }

    [Header("Path and Quantity for spawned objects")]
    [SerializeField] private string _resourcesPath;
    [SerializeField] private List<PoolPrefab> prefabPath;

    [Space(4)]
    public List<Transform> childrenTransform = new List<Transform>();
    
    private bool isLoaded = false;


    private Dictionary<string, List<BaseObject>> m_allObjectDict;
    private Dictionary<string, List<BaseObject>> m_despawnedObjDict;
    private Dictionary<string, List<BaseObject>> m_spawnedObjDict;

    public Dictionary<string, List<BaseObject>> allObjectDict
    {
        get
        {
            if (m_allObjectDict == null)
            {
                m_allObjectDict = new Dictionary<string, List<BaseObject>>();
            }
            return m_allObjectDict;
        }
    }

    public Dictionary<string, List<BaseObject>> spawnedObjDict
    {
        get
        {
            if (m_spawnedObjDict == null)
            {
                m_spawnedObjDict = new Dictionary<string, List<BaseObject>>();
            }

            return m_spawnedObjDict;
        }
    }

    public Dictionary<string, List<BaseObject>> despawnedObjDict
    {
        get
        {
            if (m_despawnedObjDict == null)
            {
                m_despawnedObjDict = new Dictionary<string, List<BaseObject>>();
            }
            return m_despawnedObjDict;
        }
    }
    
    public void Initialize()
    {
        prefabPath = new List<PoolPrefab> {};

        DontDestroyOnLoad(this);
        StartCoroutine(LoadPrefabs());
    }

    public IEnumerator LoadPrefabs()
    {
        foreach (var prefab in prefabPath)
        {
            GameObject parentGo = new GameObject();
            BaseObject go = Resources.Load<BaseObject>(_resourcesPath + prefab.path);

            go.name = prefab.path.Split('/').GetTop();
            go.prefabName = go.name;

            parentGo.name = go.name;

            spawnedObjDict[go.name] = new List<BaseObject>();
            despawnedObjDict[go.name] = new List<BaseObject>();

            for (int k = 0; k < prefab.poolNum; k++)
            {
                BaseObject obj = Instantiate(go);
                InitSpawnedObject(obj, parentGo.transform);
            }

            parentGo.transform.SetParent(transform);
            childrenTransform.Add(parentGo.transform);

            yield return null;
        }

        isLoaded = true;
        yield return null;
    }

    public bool IsLoaded() 
    {
        return isLoaded;
    }

    private void InitSpawnedObject(BaseObject spawned, Transform parentGo) 
    {
        spawned.transform.SetParent(parentGo);
        Despawn<BaseObject>(spawned);
    }

    public T Find<T>(BaseObject obj) where T : BaseObject
    {
        string name = obj.prefabName;
        if (!m_allObjectDict.TryGetValue(name, out var value))
        {
            foreach (var e in value)
            {
                if (e.Equals(obj))
                {
                    return (T)e;
                }
            }
        }

        Debug.Log(string.Format("{0} is not found", obj.name));
        return default(T);
    }

    public T FindByName<T>(string name, GameObject go) where T : BaseObject
    {
        if (!m_allObjectDict.TryGetValue(name, out var value))
        {
            foreach (var e in value)
            {
                if (e.Equals(go))
                {
                    return (T)e;
                }
            }
        }
        return default(T);
    }

    private void SetTransform(Transform spawnedTransform, Vector3 position, Quaternion rotation, Transform parent)
    {
        if (spawnedTransform == null)
            return;

        spawnedTransform.position = position;
        spawnedTransform.rotation = rotation;

        if (parent != null)
            spawnedTransform.SetParent(parent);
    }

    public T Spawn<T>(string type, Vector3 position, Quaternion rotation, Transform parent) where T : BaseObject
    {
        if (!despawnedObjDict.TryGetValue(type, out var value))
        {
            return default(T);
        }

        T spawnedObject = (T)value.Top();

        value.Remove(spawnedObject);
        spawnedObjDict[type].Add(spawnedObject);

        SetTransform(spawnedObject.transform, position, rotation, parent);
        spawnedObject.gameObject.SetActive(true);

        return spawnedObject;
    }

    public T Spawn<T>(string type) where T : BaseObject
    {
        return Spawn<T>(type, Vector3.zero, Quaternion.identity, null);
    }

    public T Spawn<T>(string type, Transform parent) where T : BaseObject
    {
        return Spawn<T>(type, Vector3.zero, Quaternion.identity, parent);
    }
    public T Spawn<T>(string type, Vector3 position) where T : BaseObject
    {
        return Spawn<T>(type, position, Quaternion.identity, null);
    }

    public T Spawn<T>(string type, Vector3 position, Transform parent) where T : BaseObject
    {
        return Spawn<T>(type, position, Quaternion.identity, parent);
    }

    public T Spawn<T>(string type, Vector3 position, Quaternion rotation) where T : BaseObject
    {
        return Spawn<T>(type, position, rotation, null);
    }

    public void Despawn<T> (BaseObject obj) where T : BaseObject
    {
        string prefabName = obj.prefabName;
        if (spawnedObjDict.TryGetValue(prefabName, out var value))
        {
            value.Remove(obj);
            despawnedObjDict[prefabName].Add(obj);
        }
     
        obj.gameObject.SetActive(false);
    }

    public void DespawnAllWithName<T>(string key) where T : BaseObject
    {
        if (spawnedObjDict.TryGetValue(key, out var value))
        {
            List <BaseObject> despawnList = new List <BaseObject>();

            value.ForEach(obj =>
            {
                despawnList.Add(obj);
            });

            despawnList.ForEach(obj => Despawn <BaseObject>(obj));
        }
    }

    public void DespawnAll()
    {
        foreach (var key in spawnedObjDict.Keys) 
        {
            if (spawnedObjDict.TryGetValue(key, out var value))
            {
                List <BaseObject> despawnList = new List <BaseObject>();

                value.ForEach(obj =>
                {
                    despawnList.Add(obj);
                });

                despawnList.ForEach(obj => Despawn <BaseObject>(obj));
            }
        }
    }
}