using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable] 
public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver 
{
    [SerializeField] private List<TKey> keys = new List<TKey>(); 
    [SerializeField] private List<TValue> values = new List<TValue>();
     // save the dictionary to lists 

    public Dictionary<TKey, TValue> target;
    public Dictionary<TKey, TValue> ToDictionary() {return target;}

    public SerializableDictionary(Dictionary<TKey, TValue> target)
    {
        this.target = target;
    }

    public void OnBeforeSerialize() 
    { 
        keys = new List<TKey>(target.Keys);
        values = new List<TValue>(target.Values);
    }
    public void OnAfterDeserialize() 
    { 
        var count = Math.Min(keys.Count, values.Count);
        target = new Dictionary<TKey, TValue>(count);
        for (int i=0; i< count; i++)
            target.Add(keys[i], values[i]);
    } 
}

//https://202psj.tistory.com/1261