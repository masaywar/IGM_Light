using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    //[SerializeField]
    [SerializeField] private BoardManager m_boardManager;

    public int row = 0;
    public int col = 0;
    public ColorType _color;
    public int mov = 0;
    // public ColorType standard;

    private int _length;
    public bool IsUp;

    public Animator animator;

    enum States{
        up = 1,
        down = 2,
        left = 3,
        right = 4,
        idle = 0
    }

    enum Colors
    {
        Basic = 0,
        Red = 1,
        Blue = 2,
        Cyan = 3,
        Yellow = 6,
        Pink = 7,
        Purple = 8,
        Green = 9
    }
    // Start is called before the first frame update
    void Start()
    {
        m_boardManager = transform.parent.GetComponent<BoardManager>();

        _length = m_boardManager.Length;

        GetComponent<Animator>().SetInteger("color", (int)Colors.Basic);
        //GetComponent<Animator>().SetInteger("direction",1);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Draw();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)&&Input.GetAxis("Vertical")>0)
        {
            GetComponent<Animator>().SetInteger("direction", (int)States.up);
            row = TryMove(row-1, col) ? row-1 : row;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)&&Input.GetAxis("Vertical")<0)
        {
           GetComponent<Animator>().SetInteger("direction", (int)States.down);
            row = TryMove(row+1, col) ? row+1 : row;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
           GetComponent<Animator>().SetInteger("direction", (int)States.left);
            col = TryMove(row, col-1) ? col-1 : col;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
           GetComponent<Animator>().SetInteger("direction", (int)States.right);
            col = TryMove(row, col+1) ? col+1 : col;
        }
        /*else if(onTile!=null){
           if (this.transform.position == onTile.transform.position)  //move 확인
            {
                //Debug.Log("arrive");
                GetComponent<Animator>().SetInteger("direction", (int)States.idle);
            }
         }*/
#else

#endif
    }

    public void Move(Vector2 direction)
    {

        if (direction.x == -1)
        {
            GetComponent<Animator>().SetInteger("direction", (int)States.up);
            //GetComponent<Animator>().SetFloat("direction_x", direction.x);
            row = TryMove(row-1, col) ? row-1 : row;  //up
        }
        else if (direction.x == 1)
        {
            GetComponent<Animator>().SetInteger("direction", (int)States.down);
            row = TryMove(row+1, col) ? row+1 : row;  //down
        }
        else if (direction.y == -1)
        {
            GetComponent<Animator>().SetInteger("direction", (int)States.left);
            col = TryMove(row, col-1) ? col-1 : col;  //left
        }
        else if (direction.y == 1)
        {
            GetComponent<Animator>().SetInteger("direction", (int)States.right);
            col = TryMove(row, col+1) ? col+1 : col;  //right
        }
    }

    public bool TryMove(int p_row, int p_col)
    {
        if (m_boardManager.TryGetTile(p_row, p_col, out var onTile))  //onTile에는 갈 위치
        {
            if (onTile.HasObstacle)
                return false;

            mov++;
            this.transform.DOMove(onTile.transform.position,2); //애니메이션
            Invoke("stand", 2f);

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

    void stand()
    {
        GetComponent<Animator>().SetInteger("direction", (int)States.idle);
    }

    void ChangeColor(ColorType color)
    {
        switch (color)
        {
            case ColorType.Basic:
                GetComponent<Animator>().SetInteger("color", (int)Colors.Basic);
                break;
            case ColorType.Red:
                GetComponent<Animator>().SetInteger("color", (int)Colors.Red);
                break;
            case ColorType.Blue:
                GetComponent<Animator>().SetInteger("color", (int)Colors.Blue);
                break;
            case ColorType.Cyan:
                GetComponent<Animator>().SetInteger("color", (int)Colors.Cyan);
                break;
            case ColorType.Green:
                GetComponent<Animator>().SetInteger("color", (int)Colors.Green);
                break;
            case ColorType.Pink:
                GetComponent<Animator>().SetInteger("color", (int)Colors.Pink);
                break;
            case ColorType.Purple:
                GetComponent<Animator>().SetInteger("color", (int)Colors.Purple);
                break;
            case ColorType.Yellow:
                GetComponent<Animator>().SetInteger("color", (int)Colors.Yellow);
                break;
        }
        /*if (m_boardManager.TryGetCharacterSprite(color, 6, out var sprite)) //6은 stand
        {
            SpriteRenderer spriteR = gameObject.GetComponent<SpriteRenderer>();
            spriteR.sprite = sprite;
        }*/

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
        else
        {
            Debug.Log("?");
        }
        //if(GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(col, row, out onTile))
        //{

    }
}
