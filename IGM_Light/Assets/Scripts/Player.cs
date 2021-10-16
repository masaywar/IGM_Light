using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private BoardManager m_boardManager;

    public int row = 0;
    public int col = 0;
    public CustomTile goTile;  //will go 
    public CustomTile onTile;  //recent Tile
    string color = "gray";
   // public Sprite[] colortiles = new Sprite[9];
    private Vector2 nowPos, prePos;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(col, row + 1, out onTile))
        {
            Debug.Log("onTile" + onTile.transform.position);
            //this.transform.position = new Vector3(0,-1f,0);
        }
        //gameObject.SetActive(false);
        // GameObject up1 = transform.Find("up1").gameObject;
    }

// Update is called once per frame
void Update()
    {
        Move();
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
            TestMove(row, col-1);
            col--;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("down");
            Debug.Log("c:"+col+"r:"+row);
            row++;
            TestMove(row, col);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TestMove(row - 1, col);
            row--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TestMove(row + 1, col);
            row++;
        }

        //드래그시 무빙
        if (Input.touchCount == 1)
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
        }

    }

    private void TestMove(int p_row, int p_col)
    {
        Debug.Log("c:" + col + "r:" + row);
        if (m_boardManager.TryGetTile(p_col, p_row, out goTile))
        {
            //goTile = GameObject.Find("Board").GetComponent<BoardManager>().GetTile(row+1, col);
            this.transform.position = goTile.transform.position;
        }
    }

    void SetColor(string c)
    {
        color = c;
    }

   void Draw()  //캐릭터의 색과 같은 Tile 색 변경
    {
        /*if(GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(col, row, out onTile))
        {
            if(color == "red")
              onTile.GetComponent<SpriteRenderer>().sprite = colortiles[0];
            if (color == "orange")
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[1];
            if (color == "blue")
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[2];
            if (color == "cyan")
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[3];
            if (color == "green")
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[4];
            if (color == "mint")
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[5];
            if (color == "pink")
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[6];
            if (color == "purple")
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[7];
            if (color == "yellow")
                onTile.GetComponent<SpriteRenderer>().sprite = colortiles[8];
        }*/
    }
}
