using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class BaseGenerator : Editor
{
    public string[] paths;

    public abstract void Generate();
}
