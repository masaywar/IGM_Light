using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public partial class GameController : MonoBehaviour
{
    [System.Serializable]
    public class GivenColorBlockDictionary : SerializableDictionary<ColorType, List<CustomTile>>{}

    private BoardManager m_boardManager;
    private int _length;    

    [SerializeField, Range(3, 4)] private int _blockElements;
    [SerializeField] private GivenColorBlockDictionary _targetTable;

    private void Awake()
    {
        TryInitialize();
    }

    private void TryInitialize()
    {
        m_boardManager = GetComponent<BoardManager>();
        _length = m_boardManager.Length;
    }

    public List<CustomTile> GetTargetBlocks(ColorType colorType)
    {
        if(_targetTable.TryGetValue(colorType, out var tiles))
            return tiles;

        return null;
    }

    public bool TryGetTargetBlocks(ColorType colorType, out List<CustomTile> tiles)
    {
        tiles = GetTargetBlocks(colorType);
        return tiles != null;
    }

    public bool Match(ColorType colorType)
    {
        return false;
    }

    private void BFS()
    {

    }
}

