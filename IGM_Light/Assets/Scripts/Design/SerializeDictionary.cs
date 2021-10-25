using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SerializeDictionary<T, TValue>
{
    public struct Value
    {
        TValue value;
    }

    [Serializable]
    public struct Key
    {
        public T key;
        public List<Value> values;
    }

    public Dictionary<T, Key> SerializedDictionary = new Dictionary<T, Key>();

    public List<Key> keys;

    // public void Add(TKey key, TValue value)
    // {
    //     if (!SerializedDictionary.ContainsKey(key))
    //     {
            
    //     }
    // }
}
