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

    public int Row = 0;
    public int Column = 0;
    public int Step = 0;

    public ColorType PlayerColorType;

    private int _originRow;
    private int _originCol;

    // public ColorType standard;

    private Animator _animator;

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
        _animator = GetComponent<Animator>();

        _boardManager   = transform.parent.GetComponent<BoardManager>();
        _gameController = transform.parent.GetComponent<GameController>();

        _waits = new WaitForSeconds[]{
            new WaitForSeconds(0.05f),
            new WaitForSeconds(0.25f),
            new WaitForSeconds(0.5f),
        };


        _originCol = Column;
        _originRow = Row;

        _animator.SetInteger("color", (int)Colors.Basic);

        StartCoroutine(AnimMove());
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
            Row = TryMove(Row-1, Column) ? Row-1 : Row;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Row = TryMove(Row+1, Column) ? Row+1 : Row;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Column = TryMove(Row, Column-1) ? Column-1 : Column;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Column = TryMove(Row, Column+1) ? Column+1 : Column;
        }
#else

#endif
    }

    public void Move(Vector2Int direction)
    {
        if (TryMove(Row+direction.x, Column+direction.y))
        {
            Row = Row + direction.x;
            Column = Column + direction.y;
        }
    }

    public bool TryMove(int p_row, int p_col)
    {
        if (_boardManager.TryGetTile(p_row, p_col, out var onTile))  //onTile에는 갈 위치
        {
            if (onTile.HasObstacle)
                return false;

            AnimationQueue.Enqueue(onTile);
            return true;
        }

        return false;
    }

    private void CheckTile(CustomTile tile)
    {
        if (tile.HasFilter)
        {
            PlayerColorType = tile.Filter.color;
            tile.Filter.gameObject.SetActive(false);
            ChangeColor(PlayerColorType);
        }
    }

    void Stand()
    {
        _animator.SetInteger("direction", (int)States.idle);
    }

    void ChangeColor(ColorType color)
    {
        _animator.SetInteger("color", (int)color);
    }
    public void Draw() 
    {
        if (PlayerColorType == ColorType.Basic)
            return;

        if (_boardManager.TryGetTileSprite(PlayerColorType, out var sprite))
        {
            _boardManager.GetTile(Row, Column).ModTileColor(sprite, PlayerColorType);
            _gameController.Match(PlayerColorType);
        }
    }

    public void ResetPlayer()
    {
        Row = _originRow;
        Column = _originCol;

        PlayerColorType = ColorType.Basic;

        if(_boardManager.TryGetTile(Row, Column, out var tile))
        {
            transform.position = tile.transform.position;
            _animator.SetInteger("color", (int)Colors.Basic);
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

            CustomTile tile = AnimationQueue.Dequeue();

            Row = tile.Row;
            Column = tile.Column;

            transform
            .DOMove(tile.transform.position, 0.5f)
            .OnStepComplete(()=>{
                Step++;
                CheckTile(tile);
                Stand();    
            });

            yield return _waits[0];
        }
    }
}
