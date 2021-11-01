using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BlockFormation
{
    public static Vector2Int[][] THREE_S = 
    {
        new Vector2Int[]{new Vector2Int(0,0), new Vector2Int(0,1), new Vector2Int(1,1)},
        new Vector2Int[]{new Vector2Int(0,0), new Vector2Int(0,1), new Vector2Int(1,0)},
        new Vector2Int[]{new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(1,1)},
        new Vector2Int[]{new Vector2Int(0,1), new Vector2Int(1,1), new Vector2Int(1,0)}
    };

    public static Vector2Int[][] THREE_I = 
    {
       new Vector2Int[]{new Vector2Int(0,0), new Vector2Int(0,1), new Vector2Int(0,2)},
       new Vector2Int[]{new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(2,0)}
    };
    
    public static Vector2Int[][] FOUR_S =
    {

    };

    public static Vector2Int[][] FOUR_Z =
    {

    };

    public static Vector2Int[][] FOUR_L =
    {

    };

    public static Vector2Int[][] FOUR_J =
    {

    };

    public static Vector2Int[][] FOUR_O =
    {

    };

    public static Vector2Int[][] FOUR_T =
    {
        
    };

    public static Vector2Int[][] FOUR_I =
    {
        new Vector2Int[]{new Vector2Int(0,0), new Vector2Int(0,1), new Vector2Int(0,2), new Vector2Int(0,3)},
        new Vector2Int[]{new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(2,0), new Vector2Int(3,0)}
    };
}
