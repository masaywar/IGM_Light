using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drawbutton : MonoBehaviour//, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public SpriteRenderer character;
    public SpriteRenderer tile;
    public GameObject p;
    public Color pColor;
    public player script;
    private GameObject[,] m_TilesArray = new GameObject[3, 3];
    private int k=0;
    // Start is called before the first frame update

    void Start()
    {
        p = GameObject.Find("Player");
       // script     = p.GetComponent<player>();
        character = p.GetComponent<SpriteRenderer>();//GameObject.Find("Player");
        for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                k++;
                m_TilesArray[i,j] = GameObject.Find("Tile"+k);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        pColor = character.color;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (m_TilesArray[i,j].transform.position == p.transform.position)
                {
                    tile = m_TilesArray[i,j].GetComponent<SpriteRenderer>();
                    tile.color = pColor;
                }
            }
        }
    }

}
