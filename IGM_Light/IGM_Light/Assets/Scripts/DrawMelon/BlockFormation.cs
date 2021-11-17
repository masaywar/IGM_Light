using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BlockFormation
{
    public static Vector2Int[] THREE_S_1 = 
    {
        new Vector2Int(0,0), new Vector2Int(0,1), new Vector2Int(1,1),
    };

    public static Vector2Int[] THREE_S_2 = 
    {
        new Vector2Int(0,0), new Vector2Int(0,1), new Vector2Int(1,0),
    };

    public static Vector2Int[] THREE_S_3 = 
    {
        new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(1,1),
    };

    public static Vector2Int[] THREE_S_4 = 
    {
        new Vector2Int(0,1), new Vector2Int(1,1), new Vector2Int(1,0)
    };

    public static Vector2Int[] THREE_I_1 = 
    {
      new Vector2Int(0,0), new Vector2Int(0,1), new Vector2Int(0,2),
    };
    public static Vector2Int[] THREE_I_2 = 
    {
       new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(2,0)
    };
    
    public static Vector2Int[] FOUR_S_1 =
    {
        new Vector2Int(0,1), new Vector2Int(0,2), new Vector2Int(1,0), new Vector2Int(1,1)
    };

    public static Vector2Int[] FOUR_S_2 =
    {
        new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(1,1), new Vector2Int(2,1)
    };

    public static Vector2Int[] FOUR_Z_1 =
    {
        new Vector2Int(0,0), new Vector2Int(0,1), new Vector2Int(1,1), new Vector2Int(1,2)
    };

    public static Vector2Int[] FOUR_Z_2 =
    {
        new Vector2Int(0,1), new Vector2Int(1,0), new Vector2Int(1,1), new Vector2Int(2,0)
    };

    public static Vector2Int[] FOUR_J_1 =
    {
        new Vector2Int(0,1), new Vector2Int(1,1), new Vector2Int(2,0), new Vector2Int(2,1)
    };

    public static Vector2Int[] FOUR_J_2 =
    {
        new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(1,1), new Vector2Int(1,2)
    };

    public static Vector2Int[] FOUR_J_3 =
    {
        new Vector2Int(0,1), new Vector2Int(1,1), new Vector2Int(2,0), new Vector2Int(2,1)
    };
    public static Vector2Int[] FOUR_J_4 =
    {
        new Vector2Int(0,1), new Vector2Int(1,1), new Vector2Int(2,0), new Vector2Int(2,1)
    };

    public static Vector2Int[] FOUR_L_1 =
    {
        new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(2,0), new Vector2Int(2,1)
    };

    public static Vector2Int[] FOUR_L_2 =
    {
        new Vector2Int(1,0), new Vector2Int(1,1), new Vector2Int(1,2), new Vector2Int(0,2)
    };

    public static Vector2Int[] FOUR_L_3 =
    {
        new Vector2Int(0,0), new Vector2Int(0,1), new Vector2Int(1,1), new Vector2Int(2,1)
    };
    public static Vector2Int[] FOUR_L_4 =
    {
        new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(0,1), new Vector2Int(0,2)
    };


    public static Vector2Int[] FOUR_O =
    {
        new Vector2Int(0,0), new Vector2Int(0,1), new Vector2Int(1,0), new Vector2Int(1,1)
    };

    public static Vector2Int[] FOUR_T_1 =
    {
        new Vector2Int(0,0), new Vector2Int(0,1), new Vector2Int(0,2), new Vector2Int(1,1)
    };
    public static Vector2Int[] FOUR_T_2 =
    {
        new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(2,0), new Vector2Int(1,1)
    };
    public static Vector2Int[] FOUR_T_3 =
    {
        new Vector2Int(1,0), new Vector2Int(1,1), new Vector2Int(1,2), new Vector2Int(0,1)
    };
    public static Vector2Int[] FOUR_T_4 =
    {
        new Vector2Int(1,0), new Vector2Int(0,1), new Vector2Int(1,1), new Vector2Int(2,1)
    };

    public static Vector2Int[] FOUR_I_1 =
    {
        new Vector2Int(0,0), new Vector2Int(0,1), new Vector2Int(0,2), new Vector2Int(0,3)
    };

    public static Vector2Int[] FOUR_I_2 =
    { 
        new Vector2Int(0,0), new Vector2Int(1,0), new Vector2Int(2,0), new Vector2Int(3,0)
    };

    public static Vector2Int[][] Formations =
    {
        THREE_S_1, THREE_S_2, THREE_S_3, THREE_S_4,
        THREE_I_1, THREE_I_2,

        FOUR_S_1, FOUR_S_2,
        FOUR_Z_1, FOUR_Z_2,
        FOUR_J_1, FOUR_J_2, FOUR_J_3, FOUR_J_4,
        FOUR_L_1, FOUR_L_2, FOUR_L_3, FOUR_L_4,
        FOUR_O,
        FOUR_T_1, FOUR_T_2, FOUR_T_3, FOUR_T_4,
        FOUR_I_1, FOUR_I_2
    };
 
}
