using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class left : MonoBehaviour//, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        //Debug.Log("left");
        player.transform.position += new Vector3(-3.0f, 0, 0);
    }
}

