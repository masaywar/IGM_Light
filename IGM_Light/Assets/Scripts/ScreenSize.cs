using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenSize
{
    public static float GetScreenToWorldHeight
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);

            float height = edgeVector.y * 2;
            return height;
        }
    }

    public static float GetScreenToWorldWidth
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner);

            float width = edgeVector.x*2;
            return width;
        }
    }
}
