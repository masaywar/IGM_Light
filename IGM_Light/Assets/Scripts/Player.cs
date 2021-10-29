using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField]
    private BoardManager m_boardManager;

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

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(col, row , out onTile))  //row,col은 시작위치
        {
            Debug.Log("onTile" + onTile.transform.position);  //0,0
            //this.transform.position = new Vector3(0,-1f,0);
        }
        //gameObject.SetActive(false);
        // GameObject up1 = transform.Find("up1").gameObject;
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
        int speed = 10;

        /*float xMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //x축으로 이동할 양
        float yMove = Input.GetAxis("Vertical") * speed * Time.deltaTime; //y축으로 이동할양
        this.transform.Translate(new Vector3(xMove, yMove, 0));  //이동*/

        //방향키 상하좌우 이동
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //Debug.Log("up");
            row--;
            TestMove(row, col);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //Debug.Log("down");
            //Debug.Log("c:"+col+"r:"+row);
            row++;
            TestMove(row, col);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Debug.Log("left");
            col--;
            TestMove(row, col);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Debug.Log("right");
            col++;
            TestMove(row, col);
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

    private void TestMove(int p_row, int p_col)
    {
        mov++;
        //Debug.Log("c:" + p_col + "r:" + p_row);
        if (GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(p_col, p_row, out goTile))
        {
            //goTile = GameObject.Find("Board").GetComponent<BoardManager>().GetTile(row+1, col);
            this.transform.position = goTile.transform.position;
        }
        if (GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(col, row, out onTile))  //onTile에는 현재위치
        {
            if (onTile.HasItem == true)
            {
                _color = onTile.Filter.color;
                Debug.Log(_color);
                ChangeColor(_color);
            }
        }
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
        if (GameObject.Find("Board").GetComponent<BoardManager>().TryGetCharacterSprite(color, 6, out m_sprite)) //6은 stand
        {
            SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();
            //gameObject.
            spriteR.sprite = m_sprite;
        }
        /*if (color == ColorType.Red)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = colorPlayer[0];
        }
        if (color == ColorType.Orange)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = colorPlayer[1];
        }
        if (color == ColorType.Yellow)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = colorPlayer[2];
        }
        if (color == ColorType.Green)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = colorPlayer[3];
        }
        if (color == ColorType.Mint)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = colorPlayer[4];
        }
        if (color == ColorType.Cyan)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = colorPlayer[5];
        }
        if (color == ColorType.Blue)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = colorPlayer[6];
        }
        if (color == ColorType.Purple)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = colorPlayer[7];
        }
        if (color == ColorType.Pink)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = colorPlayer[8];
        }*/
    } 
   void Draw()  //필터의 색과 같은 Tile 색,캐릭터 색 변경
    {
        Debug.Log("Draw");
        
        if (GameObject.Find("Board").GetComponent<BoardManager>().TryGetTileSprite(_color, out T_sprite))
        {
            onTile.ModTileColor(T_sprite, _color);
        }
        //if(GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(col, row, out onTile))
        //{
           /* if(_color == ColorType.Red)
            {
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[0];
            }
            if (_color == ColorType.Orange)
            {
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[1];
            }
            if (_color == ColorType.Yellow)
            {
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[2];
            }
            if (_color == ColorType.Green)
            {
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[3];
            }
            if (_color == ColorType.Mint)
            {
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[4];
            }
            if (_color == ColorType.Cyan)
            {
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[5];
            }
            if (_color == ColorType.Blue)
            {
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[6];
            }
            if (_color == ColorType.Purple)
            {
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[7];
            }
            if (_color == ColorType.Pink)
            {
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[8];
            }
        //}*/
    }
}
