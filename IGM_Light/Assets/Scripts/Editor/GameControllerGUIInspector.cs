﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(GameController))]
public class GameControllerGUIInspector : Editor
{
    GameController controller;
    int size = 3;
    ColorType colorType = ColorType.Basic;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        controller = target as GameController;
        
        var skin = GUI.skin;
        
        GUILayout.BeginHorizontal();

        int newSize = 0;

        if (size!=(newSize=EditorGUILayout.IntPopup(size, new string[2]{"3", "4"}, new int[2]{3, 4})))
        {
            if(EditorUtility.DisplayDialog("Warning","Your Blocks can be removed, Are you sure to change the value?", "Yes", "No" ))
            {
                size = newSize;
                controller.TargetTable = new GameController.CustomBlocks[8];
            }
        }

        colorType = (ColorType)EditorGUILayout.EnumPopup(colorType);
        GUILayout.EndHorizontal();

        if(size == 3)
        {
            
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("ㄴ",  GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.THREE_S);
            }
            if(GUILayout.Button("I",  GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.THREE_I);
            }
            GUILayout.EndHorizontal();
        }

        else
        {
            GUILayout.BeginHorizontal();
            if(GUILayout.Button("S", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_S);
            }
            
            if(GUILayout.Button("Z", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_Z);
            }
            
            if(GUILayout.Button("I", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_I);
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if(GUILayout.Button("L", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_L);
            }
            if(GUILayout.Button("J", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_J);
            }
            if(GUILayout.Button("T", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_T);
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Button("",  skin.label, GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
            if(GUILayout.Button("O", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_O);
            }
            GUILayout.Button("",  skin.label, GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f));
            GUILayout.EndHorizontal();
        }
    }

    private void CreateBlock(BlockType blockType)
    {
        if (controller.TargetTable[(int)colorType].Blocks == null)
                    controller.TargetTable[(int)colorType] = new GameController.CustomBlocks(new List<CustomBlock>());

        CustomBlock customBlock = new CustomBlock();
        customBlock.ColorType = colorType;
        customBlock.BlockType = blockType;
        controller.TargetTable[(int)colorType].Blocks.Add(customBlock);
    }
}
