using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(GameController))]
public class GameControllerGUIInspector : Editor
{
    GameController controller;
    BlcokDatabaseLoader blcokDatabaseLoader;
    ScrollRect _scrollView;

    ColorType colorType = ColorType.Basic;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        controller = target as GameController;
        _scrollView = FindObjectOfType<ScrollRect>();

        var skin = GUI.skin;
        
        GUILayout.Space(32);
        GUILayout.Label("Choos Size of blocks and Put the block with pushing a button");
        GUILayout.BeginHorizontal();
    
        int newSize = 0;
        int size = controller.Size;

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
            if (GUILayout.Button("ㄱ",  GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.THREE_S_1);
            }
            if (GUILayout.Button("┌",  GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.THREE_S_2);
            }
            if(GUILayout.Button("ㄴ",  GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.THREE_S_3);
            }
            if(GUILayout.Button("┘",  GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.THREE_S_4);
            }
            if(GUILayout.Button("ㅡ",  GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.THREE_I_1);
            }
            if(GUILayout.Button("I",  GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.THREE_I_2);
            }
            GUILayout.EndHorizontal();
        }

        else
        {
            GUILayout.BeginHorizontal();
            if(GUILayout.Button("S_1", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_S_1);
            }

            if(GUILayout.Button("S_2", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_S_2);
            }
            
            if(GUILayout.Button("Z_1", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_Z_1);
            }

            if(GUILayout.Button("Z_2", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_Z_2);
            }
            
            if(GUILayout.Button("L_1", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_L_1);
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if(GUILayout.Button("L_2", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_L_2);
            }

            if(GUILayout.Button("L_3", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_L_3);
            }

            if(GUILayout.Button("L_4", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_L_4);
            }

            if(GUILayout.Button("J_1", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_J_1);
            }

            if(GUILayout.Button("J_2", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_J_2);
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if(GUILayout.Button("J_3", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_J_3);
            }
            if(GUILayout.Button("J_4", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_J_4);
            }

            if(GUILayout.Button("T_1", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_T_1);
            }
            if(GUILayout.Button("T_2", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_T_2);
            }
            if(GUILayout.Button("T_3", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_T_3);
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if(GUILayout.Button("T_4", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_T_4);
            }

            if(GUILayout.Button("I_1", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_I_1);
            }

            if(GUILayout.Button("I_2", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_I_2);
            }
            if(GUILayout.Button("O", GUILayout.ExpandWidth(false),GUILayout.MaxHeight(50f), GUILayout.MaxWidth(50f)))
            {
                CreateBlock(BlockType.FOUR_O);
            }
            GUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Clear"))
        {
            controller.TargetTable.ForEach(
                blocks => blocks.Blocks.Clear()
            );
        }

        controller.Size = size;

    }

    private void CreateBlock(BlockType blockType)
    {
        if(colorType == ColorType.Basic)
            return;

        if (controller.TargetTable[(int)colorType].Blocks == null)
        {
            controller.TargetTable[(int)colorType] = new GameController.CustomBlocks(new List<CustomBlock>());
        }

        CustomBlock customBlock = new CustomBlock(blockType, colorType, null);

        controller.TargetTable[(int)colorType].Blocks.Add(customBlock);
        
        //Instantiate(blcokDatabaseLoader.Blocks[(int)colorType].Blocks[(int)blockType], _scrollView.content);
    }
}