using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSelectScrollRect : MonoBehaviour
{
    private Transform _pivot;
    [SerializeField]private RectTransform[] _worlds;
    private Vector3[] _contentPositions;

    private Vector3 _center;

    private bool isInit = false;

}

  
