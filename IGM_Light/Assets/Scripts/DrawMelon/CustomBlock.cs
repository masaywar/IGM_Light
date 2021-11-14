using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomBlock
{
    public BlockType BlockType;

    public ColorType ColorType;

    public GameObject ShowingBlock = null;

    public CustomBlock(BlockType blockType, ColorType colorType, GameObject obj)
    {
        BlockType = blockType;
        ColorType = colorType;
        ShowingBlock = obj;
    }

    public int Size
    {
        get
        {
            switch(BlockType)
            {
                case BlockType.THREE_S_1:
                case BlockType.THREE_S_2:
                case BlockType.THREE_S_3:
                case BlockType.THREE_S_4:
                case BlockType.THREE_I_1:
                case BlockType.THREE_I_2:
                    return 3;
                default:
                    return 4;
            }
        }
    }

    public Vector2Int[] Form
    {
        get => BlockFormation.Formations[(int)BlockType];
    }

    public void OnSolved()
    {
        if(ShowingBlock)
            ShowingBlock.SetActive(false);
    }
}
