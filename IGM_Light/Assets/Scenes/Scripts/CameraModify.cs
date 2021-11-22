using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraModify : MonoBehaviour
{
    public BoardManager boardManager;
    public void SetCameraPositionAndSize(int length)
    {
        float targetRatio = 9f / 16f;

        float width = Camera.main.pixelWidth;
        float height = Camera.main.pixelHeight;
        
        float aspectRatio = width / height;
        float scalar = targetRatio / aspectRatio;

        Camera.main.orthographicSize = length*scalar;
        Vector3 demandedCameraPosition;
        if (length == 3)
        {
            demandedCameraPosition = new Vector3(1, 0, 0);
        }
        else if (length == 4)
        {
            demandedCameraPosition = new Vector3(1.5f, 0f, 0);
        }
        else
        {
            demandedCameraPosition = new Vector3(2f, 0f, 0);
        }
        Camera.main.transform.position = demandedCameraPosition;
    }
}
