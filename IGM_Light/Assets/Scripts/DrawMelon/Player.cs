using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField]
    [SerializeField]private BoardManager m_boardManager;

    public int row = 0;
    public int col = 0;
    public CustomTile goTile;  //will go 
    public CustomTile onTile;  //recent Tile
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
        if (GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(col, row , out onTile))  //row,col은 시작위치
        {
            Debug.Log("onTile" + onTile.transform.position);  //0,0
        }
        
        _length = m_boardManager.Length;
    }

// Update is called once per frame
void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Space Down");
            Draw();
        }
    }
    
    void Move()
    {
        //방향키 상하좌우 이동
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

        //드래그시 무빙
        /*if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                //Debug("nowPos"+nowPos); 
            }
        }*/

    }

    private bool TryMove(int p_row, int p_col)
    {
        if (m_boardManager.TryGetTile(p_row, p_col, out onTile))  //onTile에는 현재위치
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

   void UnMovable(bool move)
    {
        if (!move)
        {
            row = onTile.Row;
            col = onTile.Column;
        }
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
        if (GameObject.Find("Board").GetComponent<BoardManager>().TryGetTileSprite(_color, out T_sprite))
        {
            onTile.ModTileColor(T_sprite, _color);
            if(m_boardManager.GetComponent<GameController>().TryMakeBlock(row, col))
                m_boardManager.GetComponent<GameController>().Match(_color);
        }
        //if(GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(col, row, out onTile))
        //{

    }
}
