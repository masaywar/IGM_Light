using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField]
    [SerializeField]private BoardManager m_boardManager;

    public int row = 0;
    public int col = 0;
    public Sprite T_sprite;
    public Sprite m_sprite;
    public ColorType _color;
    public int mov = 0;
   // public ColorType standard;

    public Sprite[] colortiles = new Sprite[9];
    public Sprite[] colorPlayer = new Sprite[9];
    private Vector2 nowPos, prePos;
    private int _length;
    // Start is called before the first frame update
    void Start()
    {
        m_boardManager = transform.parent.GetComponent<BoardManager>();
        
        _length = m_boardManager.Length;
    }

// Update is called once per frame
void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Draw();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            row = TryMove(row-1, col) ? row-1 : row;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            row = TryMove(row+1, col) ? row+1 : row;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            col = TryMove(row, col-1) ? col-1 : col;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            col = TryMove(row, col+1) ? col+1 : col;
        }
        #endif
    }
    
    private bool TryMove(int p_row, int p_col)
    {
        if (m_boardManager.TryGetTile(p_row, p_col, out var onTile))  //onTile에는 현재위치
        {
            if(onTile.HasObstacle)
                return false;

            mov++;
            this.transform.position = onTile.transform.position;

            if (onTile.HasFilter)
            {
                _color = onTile.Filter.color;
                onTile.Filter.gameObject.SetActive(false);
                ChangeColor(_color);
            }

            return true;
        }

        return false;
    }

   void ChangeColor(ColorType color)
    {

        if (m_boardManager.TryGetCharacterSprite(color, 6, out m_sprite)) //6은 stand
        {
            SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();
            spriteR.sprite = m_sprite;
        }
 
    } 
   void Draw()  //필터의 색과 같은 Tile 색,캐릭터 색 변경
    {
        if (_color == ColorType.Basic)
            return; 

        if (m_boardManager.GetComponent<BoardManager>().TryGetTileSprite(_color, out T_sprite))
        {
            m_boardManager.GetTile(row, col).ModTileColor(T_sprite, _color);
            if(m_boardManager.GetComponent<GameController>().TryMakeBlock(row, col))
                m_boardManager.GetComponent<GameController>().Match(_color);
        }
        //if(GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(col, row, out onTile))
        //{

    }
}
