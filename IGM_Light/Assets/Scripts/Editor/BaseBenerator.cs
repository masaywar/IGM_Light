using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class BaseGenerator : Editor
{
    public abstract void Generate();
}
