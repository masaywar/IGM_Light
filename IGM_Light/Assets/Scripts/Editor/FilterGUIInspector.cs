using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Filter))]
[CanEditMultipleObjects]
public class FilterGUIInspector : Editor
{
    public SpriteDatabaseLoader spriteDatabase;
    private ColorType _colorType;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        var filter = (Filter)target;

        EditorGUILayout.BeginHorizontal();
        _colorType = (ColorType)EditorGUILayout.EnumPopup(_colorType);

        if(GUILayout.Button("Mod Color"))
        {
            var targetSprite = spriteDatabase.FilterSprites[(int)_colorType];

            filter.GetComponent<SpriteRenderer>().sprite = targetSprite; 
            filter.color = _colorType;           
        }

        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Remove Filter"))
        {
            var tile = filter.transform.parent;
            DestroyImmediate(filter.gameObject);

            tile.GetComponent<CustomTile>().Filter = null;
        }
    }
}
