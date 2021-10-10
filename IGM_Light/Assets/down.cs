using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class down : MonoBehaviour//, IDragHandler, IPointerDownHandler, IPointerUpHandler
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
        //Debug.Log("down");
        player.transform.position += new Vector3(0, -3.0f, 0);
    }
}
