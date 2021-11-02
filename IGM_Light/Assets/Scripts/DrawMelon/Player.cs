using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //[SerializeField]
    [SerializeField]
    private BoardManager m_boardManager;

    [SerializeField]
    private GameController controller;

    public int row = 0;
    public int col = 0;
    public CustomTile goTile;  //will go 
    public CustomTile onTile;  //recent Tile
    public Sprite T_sprite;
    public Sprite m_sprite;
    public ColorType _color;
    public int mov = 0;
    public int maxMov = 4;
    private Text moving;
    private int length;
        // public ColorType standard;

    public Sprite[] colortiles = new Sprite[9];
    public Sprite[] colorPlayer = new Sprite[9];
    private Vector2 nowPos, prePos;
    private GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        length = m_boardManager.Length;
        panel = GameObject.Find("Panel");
        //panel.SetActive(false);
        SetFirstPos(1, 0);
        //Debug.Log("r:" + row + "c:" + col);
        if (m_boardManager.TryGetTile(row, col , out onTile))  //row,col은 시작위치
        {
            Debug.Log("onTile" + onTile.transform.position);  //0,0
            //this.transform.position = new Vector3(0,-1f,0);
        }
        moving = GameObject.Find("move").GetComponent<Text>();
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
    
    void SetFirstPos(int r, int c)
    {
        row = r;
        col = c;
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
            if (m_boardManager.TryGetTile(row-1, col, out goTile))
            {
                if (!goTile.HasObstacle)
                {
                    if (row > 0)
                    {
                        row--;
                    }
                    TestMove(row, col);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (m_boardManager.TryGetTile(row+1, col, out goTile))
            {
                if (!goTile.HasObstacle)
                {

                    if (row < length-1)
                    {
                        row++;
                    }
                    TestMove(row, col);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (m_boardManager.TryGetTile(row, col-1, out goTile))
            {
                if (!goTile.HasObstacle)
                {
                    if (col > 0)
                    {
                        col--;
                    }
                    TestMove(row, col);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (m_boardManager.TryGetTile(row, col+1, out goTile))
            {
                if (!goTile.HasObstacle)
                {
                    if (col < length-1)
                        col++;
                    TestMove(row, col);
                }
            }
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
        moving.text = mov.ToString() + "/" + maxMov.ToString();
        if (m_boardManager.TryGetTile(p_row, p_col, out goTile))
        {
            //goTile = GameObject.Find("Board").GetComponent<BoardManager>().GetTile(row+1, col);
                this.transform.position = goTile.transform.position;
        }
        if (m_boardManager.TryGetTile(row, col, out onTile))  //onTile에는 현재위치
        {
            if (onTile.HasFilter == true)
            {
                _color = onTile.Filter.color;
                onTile.Filter.gameObject.SetActive(false);
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

        if (m_boardManager.TryGetCharacterSprite(color, 6, out m_sprite)) //6은 stand
        {
            SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();
            //gameObject.
            spriteR.sprite = m_sprite;
        }
 
    } 
   void Draw()  //필터의 색과 같은 Tile 색,캐릭터 색 변경,조건블록 만족했는지 check
    {
        if (m_boardManager.TryGetTileSprite(_color, out T_sprite))
        {
            onTile.ModTileColor(T_sprite, _color);
            if (controller.TryMakeBlock(row, col))
                if (controller.GetComponent<GameController>().Match(_color))
                {
                    Debug.Log(" ㄴ Match");
                    //panel.SetActive(true);
                };
        }

        //if(GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(col, row, out onTile))
        //{

    }
}