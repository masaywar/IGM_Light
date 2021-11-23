using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Player))]
public class CharacterInspector : Editor
{
    Player _player;
    public ColorType _colorType;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        _player = (Player)target;

        BoardManager manager = _player.transform.parent.GetComponent<BoardManager>();

        EditorGUILayout.Space(16);
        
        EditorGUILayout.BeginHorizontal();
        _colorType = (ColorType)EditorGUILayout.EnumPopup(_colorType);

        if(GUILayout.Button("Mod Color"))
        {
            _player.GetComponent<SpriteRenderer>().sprite = 
                manager.GetCharacterSprite(_colorType, 6);
        }
        
        EditorGUILayout.EndHorizontal();
    }
}
