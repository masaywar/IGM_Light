using System.Runtime;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomTile))]
[CanEditMultipleObjects]
public class TileEditor : Editor {

    private CustomTile _tile;
    public ColorType _colorType;
    public Object spriteDatabase;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        _tile = (CustomTile)target;

        BoardManager manager = _tile.transform.parent.GetComponent<BoardManager>();

        EditorGUILayout.Space(16);
        
        EditorGUILayout.BeginHorizontal();
        _colorType = (ColorType)EditorGUILayout.EnumPopup(_colorType);

        if(GUILayout.Button("Mod Color"))
        {
            manager.SetTileColor(_tile, _colorType);
            //_tile.ModTileColor(manager.SpriteDatabase.Sprites[(int)_colorType], _colorType);
        }
        
        EditorGUILayout.EndHorizontal();

    }
}