using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public partial class GameController : MonoBehaviour
{
    private BoardManager m_boardManager;
    private int _length;    

    public SerializeDictionary<ColorType, List<CustomTile>> TargetTable = new SerializeDictionary<ColorType, List<CustomTile>>();

    private void Awake()
    {
        TryInitialize();
    }

    private void TryInitialize()
    {
        m_boardManager = GetComponent<BoardManager>();
        _length = m_boardManager.Length;

    }
}

