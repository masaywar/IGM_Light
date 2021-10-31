using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomBlock
{
    public BlockType BlockType;

    public ColorType ColorType;
    public int Size
    {
        get
        {
            if (BlockType == BlockType.THREE_S || BlockType == BlockType.THREE_I)
                return 3;

            return 4;
        }
    }

    public Vector2Int[][] Form
    {
        get
        {
            if (BlockType == BlockType.THREE_S)
                return BlockFormation.THREE_S;

            else if(BlockType == BlockType.THREE_I)
                return BlockFormation.THREE_I;

            else if(BlockType == BlockType.FOUR_I)
                return BlockFormation.FOUR_I;
            
            else if(BlockType == BlockType.FOUR_J)
                return BlockFormation.FOUR_J;
            
            else if(BlockType == BlockType.FOUR_S)
                return BlockFormation.FOUR_S;
            
            else if(BlockType == BlockType.FOUR_Z)
                return BlockFormation.FOUR_Z;
           
            else if(BlockType == BlockType.FOUR_I)
                return BlockFormation.FOUR_I;
            
            else if(BlockType == BlockType.FOUR_T)
                return BlockFormation.FOUR_T;
            
            else
                return BlockFormation.FOUR_O;
            
        }
    }
  
}
