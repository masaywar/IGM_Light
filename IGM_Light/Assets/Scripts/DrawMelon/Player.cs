using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    //[SerializeField]
    [SerializeField] private BoardManager _boardManager;
    [SerializeField] private GameController _gameController;
    
    private WaitForSeconds[] _waits;

    public int row = 0;
    public int col = 0;
    public ColorType _color;
    public int mov = 0;

    private int _originRow;
    private int _originCol;

    // public ColorType standard;

    private Animator animator;

    private Queue<CustomTile> AnimationQueue = new Queue<CustomTile>();

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
        _boardManager = transform.parent.GetComponent<BoardManager>();
        _gameController = transform.parent.GetComponent<GameController>();
        /*_waits = new WaitForSeconds[]{
            new WaitForSeconds(0.05f),
            new WaitForSeconds(0.25f),
            new WaitForSeconds(0.5f),
        };*/

        animator = GetComponent<Animator>();

        _originCol = col;
        _originRow = row;

        GetComponent<Animator>().SetInteger("color", (int)Colors.Basic);

        //StartCoroutine(AnimMove());
        //GetComponent<Animator>().SetInteger("direction",0);
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
            GetComponent<Animator>().SetInteger("direction", (int)States.up);
            row = TryMove(row-1, col) ? row-1 : row;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
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
        //if (Input.touchCount == 1)
        //    Draw();
        if (direction.x == -1)
        {
            GetComponent<Animator>().SetInteger("direction", (int)States.up);
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

        if (_boardManager.TryGetTile(p_row, p_col, out var onTile))
        {
            if (onTile.HasObstacle)
            {
                Debug.Log("obstacle");
                return false;
            }
            //goTile = GameObject.Find("Board").GetComponent<BoardManager>().GetTile(row+1, col);
            //this.transform.position = goTile.transform.position;
            if (onTile.HasFilter)
            {
                _color = onTile.Filter.color;
                onTile.Filter.gameObject.SetActive(false);
                Debug.Log(_color);
                ChangeColor(_color);
            }

            transform.DOMove(onTile.transform.position, 2f);
            Invoke("Stand", 2f);

            //AnimationQueue.Enqueue(onTile);
            // print(AnimationQueue.Count);
        }
       return true;
    }

   
    private void CheckTile(CustomTile tile)
    {
        if (tile.HasFilter)
        {
            _color = tile.Filter.color;
            tile.Filter.gameObject.SetActive(false);
            ChangeColor(_color);
        }
    }

    void Stand()
    {
        animator.SetInteger("direction", (int)States.idle);
    }

    void ChangeColor(ColorType color)
    {
        switch (color)
        {
            case ColorType.Red:
                animator.SetInteger("color", (int)Colors.Red);
                break;
            case ColorType.Basic:
                animator.SetInteger("color", (int)Colors.Basic);
                break;
            case ColorType.Blue:
                animator.SetInteger("color", (int)Colors.Blue);
                break;
            case ColorType.Green:
                animator.SetInteger("color", (int)Colors.Green);
                break;
            case ColorType.Cyan:
                animator.SetInteger("color", (int)Colors.Cyan);
                break;
            case ColorType.Purple:
                animator.SetInteger("color", (int)Colors.Purple);
                break;
            case ColorType.Pink:
                animator.SetInteger("color", (int)Colors.Pink);
                break;
            case ColorType.Yellow:
                animator.SetInteger("color", (int)Colors.Yellow);
                break;

        }
    }

    public void Draw()  //필터의 색과 같은 Tile 색,캐릭터 색 변경
    {
        if (_color == ColorType.Basic)
            return;

        if (_boardManager.TryGetTileSprite(_color, out var sprite))
        {
            _boardManager.GetTile(row, col).ModTileColor(sprite, _color);
            if (_gameController.TryMakeBlock(row, col))
                _gameController.Match(_color);
        }
        else
        {
            Debug.Log("?");
        }
        //if(GameObject.Find("Board").GetComponent<BoardManager>().TryGetTile(col, row, out onTile))
        //{

    }

    public void ResetPlayer()
    {
        row = _originRow;
        col = _originCol;

        if(_boardManager.TryGetTile(row, col, out var tile))
        {
            transform.position = tile.transform.position;
            animator.SetInteger("color", (int)Colors.Basic);
        }
    }

    private IEnumerator AnimMove()
    {
        while(true)
        {
            if (AnimationQueue.Count <= 0)
            {
                yield return _waits[0];
                continue;
            }

            var tile = AnimationQueue.Dequeue();
            mov++;
            row = tile.Row;
            col = tile.Column;
            transform
            .DOMove(tile.transform.position, 0.5f)
            .OnStepComplete(()=>{
                CheckTile(tile);
                Stand();    
            });

            yield return _waits[0];
            //yield return new WaitForSeconds(1f);
        }
    }
}
