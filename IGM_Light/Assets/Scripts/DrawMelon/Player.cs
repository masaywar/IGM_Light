using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField]
    [SerializeField] private BoardManager m_boardManager;

    public int row = 0;
    public int col = 0;

    private int _originRow;
    private int _originCol;

    public ColorType _color;
    public int mov = 0;
    // public ColorType standard;

    private int _length;
    // Start is called before the first frame update
    void Start()
    {
        m_boardManager = transform.parent.GetComponent<BoardManager>();

        _originRow = row;
        _originCol = col;

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

    bool isAnim = false;

    public void Move(Vector2 direction)
    {
        int animDirect = 0;

        if (direction.x == -1)
        {
            row = TryMove(row-1, col) ? row-1 : row;
            animDirect = 1;
        }
        else if (direction.x == 1)
        {
            row = TryMove(row+1, col) ? row+1 : row;
            animDirect = 2;
        }
        else if (direction.y == -1)
        {
            col = TryMove(row, col-1) ? col-1 : col;
            animDirect = 3;
        }
        else if (direction.y == 1)
        {
            col = TryMove(row, col+1) ? col+1 : col;
            animDirect = 3;
        }

        print(animDirect);

        var animator = GetComponent<Animator>();
        animator.SetInteger("Move", animDirect);
    }

    public bool TryMove(int p_row, int p_col)
    {
        if (m_boardManager.TryGetTile(p_row, p_col, out var onTile))  //onTile에는 현재위치
        {
            if (onTile.HasObstacle)
                return false;

            mov++;
            this.transform.position = onTile.transform.position;

            if (onTile.HasFilter)
            {
                onTile.Filter.gameObject.SetActive(false);
                ChangeColor(onTile.Filter.color);
            }

            isAnim = true;
            return true;
        }

        return false;
    }

    void ChangeColor(ColorType color)
    {
        if (m_boardManager.TryGetCharacterSprite(color, 6, out var sprite)) //6은 stand
        {
            _color = color;
            SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();
            spriteR.sprite = sprite;
        }

    }
    public void Draw()  //필터의 색과 같은 Tile 색,캐릭터 색 변경
    {
        if (_color == ColorType.Basic)
            return;

        if (m_boardManager.GetComponent<BoardManager>().TryGetTileSprite(_color, out var sprite))
        {
            m_boardManager.GetTile(row, col).ModTileColor(sprite, _color);
            if (m_boardManager.GetComponent<GameController>().TryMakeBlock(row, col))
                m_boardManager.GetComponent<GameController>().Match(_color);
        }
        //if(GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(col, row, out onTile))
        //{

    }

    public void ResetPlayer()
    {
        transform.position = m_boardManager.GetTile(_originRow, _originCol).transform.position;
        
        row = _originRow;
        col = _originCol;
        mov = 0;

        ChangeColor(ColorType.Basic);
    }
}
