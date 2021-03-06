using UnityEngine;
using UnityEditor;

public abstract class DatabaseLoader : ScriptableObject 
{
    public string path;
    public abstract void Load();
}