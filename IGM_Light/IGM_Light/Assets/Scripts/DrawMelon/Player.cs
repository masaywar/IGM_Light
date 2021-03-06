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
    [SerializeField] private Anim anim;

    private WaitForSeconds[] _waits;

    public int Row = 0;
    public int Column = 0;
    public int Step = 0;
    //private Text moving;

    public ColorType PlayerColorType;

    private int _originRow;
    private int _originCol;
    public Vector2Int direc;

    // public ColorType standard;

    private Animator _animator;

    private Queue<CustomTile> AnimationQueue = new Queue<CustomTile>();

    // Start is called before the first frame update
    void Start()
    {
        //moving = GameObject.Find("Steps").GetComponent<Text>();
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

        _animator.SetInteger("color", (int)PlayerColorType);

        anim = FindObjectOfType<Anim>();
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
            //anim.Directioning((int)States.up);
            Row = TryMove(Row-1, Column) ? Row-1 : Row;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //anim.Directioning((int)States.down);
            Row = TryMove(Row+1, Column) ? Row+1 : Row;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //anim.Directioning((int)States.left);
            Column = TryMove(Row, Column-1) ? Column-1 : Column;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //anim.Directioning((int)States.right);
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

    public bool TryMove(int row, int col)
    {
        if (_boardManager.TryGetTile(row, col, out var onTile))  //onTile?????? ??? ??????
        {
            if (onTile.HasObstacle)
                return false;

            if (onTile.HasFilter)
                PlayerColorType = onTile.Filter.color;

            direc.y = row - Row;
            direc.x = Column - col;
            anim.Direction(direc);

             transform
            .DOMove(onTile.transform.position, 0.5f)
            .OnComplete(()=>{
                Step++;
                if (onTile.HasFilter)
                {
                    onTile.Filter.gameObject.SetActive(false);
                    ChangeColor(PlayerColorType);
                }
            });



            return true;
        }

        var animState = anim.animator.GetCurrentAnimatorStateInfo(0);
        return false;
    }

    private void CheckTile(CustomTile tile)
    {
        if (tile.HasFilter)
        {
            PlayerColorType = tile.Filter.color;
            
        }
    }

    void Stand()
    {
        _animator.SetInteger("direction", 0);
    }

    void ChangeColor(ColorType color)
    {
        _animator.SetInteger("color", (int)color);
    }
    
    public void Draw() 
    {
        if (PlayerColorType == ColorType.Basic)
            return;

        if(_boardManager.TryGetTile(Row, Column, out var tile))
            if(!tile.IsInteractable)
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
            _animator.SetInteger("color", (int)PlayerColorType);
        }
    }
}
