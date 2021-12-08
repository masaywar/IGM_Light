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
    public Sprite brokeTile;
    public bool broke = false;
    //private Text moving;

    public ColorType PlayerColorType;

    private int _originRow;
    private int _originCol;
    public Vector2Int direc;
    private int r;
    private int c;
    // public ColorType standard;

    private Animator _animator;

    public bool canInteract = true;

    private Queue<CustomTile> AnimationQueue = new Queue<CustomTile>();

    // Start is called before the first frame update
    void Start()
    {
        //moving = GameObject.Find("Steps").GetComponent<Text>();
        _animator = GetComponent<Animator>();

        _boardManager = transform.parent.GetComponent<BoardManager>();
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
            anim.Moving();
            Row = TryMove(Row-1, Column) ? Row-1 : Row;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //anim.Directioning((int)States.down);
            anim.Moving();
            Row = TryMove(Row+1, Column) ? Row+1 : Row;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //anim.Directioning((int)States.left);
            anim.Moving();
            Column = TryMove(Row, Column-1) ? Column-1 : Column;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //anim.Directioning((int)States.right);
            //Debug.Log("black Row: " + Row + "Col: " + Column);
            anim.Moving();
            Column = TryMove(Row, Column+1) ? Column+1 : Column;
        }
#else

#endif
    }

    public void Move(Vector2Int direction)
    {
        if(_gameController.IsSolved) return;

        if (!canInteract) return;
        anim.Moving();

        if (TryMove(Row + direction.x, Column + direction.y))
        {
            Row = Row + direction.x;
            Column = Column + direction.y;
        }
    }

    public bool TryMove(int row, int col)
    {
#if UNITY_EDITOR
        if(!canInteract) return false;
#endif
        if (_boardManager.TryGetTile(row, col, out var onTile))  //onTile에는 갈 위치
        {
            if (onTile.HasObstacle)
            {
                return false;
            }
            if (onTile.HasWeakTile)
            {
                if (!onTile.wt.Weakproperty(onTile))
                    return false;
                onTile.enterNum++;
            }
            if (onTile.HasWhitePortal)
            {
                Portal(onTile,row,col, true);
                return false;
            }
            if (onTile.HasBlackPortal)
            {
                Portal(onTile, row, col, false);
                return false;
            }
            if (onTile.HasIceTile)
            {
                direc.y = row - Row;
                direc.x = Column - col;
                int dir = anim.Direction(direc);

                r = Row;
                c = Column;
                switch (dir)
                {
                    case 1:  //up
                        Row--;
                        if (Row > 0)
                            r = Row - 1;
                        else
                        {
                            Row++;
                            Transfer(onTile);
                            return true;
                        }
                        break;
                    case 2:   //down
                        Row++;
                        if (Row < _boardManager.Length - 1)
                            r = Row + 1;
                        else
                        {
                            Row--;
                            Transfer(onTile);
                            return true;
                        }
                        break;
                    case 3:   //left
                        Column--;
                        if (Column > 0)
                            c = Column - 1;
                        else
                        {
                            Column++;
                            Transfer(onTile);
                            return true;
                        }
                        break;
                    case 4:   //right
                        Column++;
                        if (Column < _boardManager.Length - 1)
                            c = Column + 1;
                        else
                        {
                            Column--;
                            Transfer(onTile);
                            return true;
                        }
                        break;
                }
                anim.Sliding();
                //Debug.Log("r:" + r + "c:" + c);
                return TryMove(r, c);
            }

            if (onTile.HasFilter)
                PlayerColorType = onTile.Filter.color;

            direc.y = row - Row;
            direc.x = Column - col;
            anim.Direction(direc);

            transform
            .DOMove(onTile.transform.position, 0.5f)
            .OnComplete(() => {
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
    private void Transfer(CustomTile onTile)
    {
        transform
        .DOMove(onTile.transform.position, 0.5f)
        .OnComplete(() => {
              Step++;
          if (onTile.HasFilter)
          {
             onTile.Filter.gameObject.SetActive(false);
             ChangeColor(PlayerColorType);
          }
        });
    }
    private void Portal(CustomTile onTile,int row,int col, bool white)
    {
        int index = onTile.index;

        //Debug.Log("w_index" + index);

        direc.y = row - Row;
        direc.x = Column - col;
        anim.Direction(direc);

        canInteract = false;

        transform
        .DOMove(onTile.transform.position, 0.5f)
        .OnComplete(() =>
        {
            Step++;
            if (white)
            {
                if(index%2==0)
                    gameObject.transform.position = _boardManager.w_poslist[index+1];
                else
                    gameObject.transform.position = _boardManager.w_poslist[index-1];
            }
            else
            {
                if (index % 2 == 0)
                    gameObject.transform.position = _boardManager.b_poslist[index + 1];
                else
                    gameObject.transform.position = _boardManager.b_poslist[index - 1];
            }
            canInteract = true;
            if (onTile.HasFilter)
            {
                onTile.Filter.gameObject.SetActive(false);
                ChangeColor(PlayerColorType);
            }
        });
        if (white)
        {
            {
                if (index % 2 == 0)
                {
                    Row = Math.Abs((int)_boardManager.w_poslist[index+1].y);
                    Column = Math.Abs((int)_boardManager.w_poslist[index+1].x);
                }
                else
                {
                    Row = Math.Abs((int)_boardManager.w_poslist[index -1].y);
                    Column = Math.Abs((int)_boardManager.w_poslist[index - 1].x);
                }
            }
        }
        else
        {
            {
                if (index % 2 == 0)
                {
                    Row = Math.Abs((int)_boardManager.b_poslist[index + 1].y);
                    Column = Math.Abs((int)_boardManager.b_poslist[index + 1].x);
                }
                else
                {
                    Row = Math.Abs((int)_boardManager.b_poslist[index - 1].y);
                    Column = Math.Abs((int)_boardManager.b_poslist[index - 1].x);
                }
            }
        }
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

        if (_boardManager.TryGetTile(Row, Column, out var tile))
            if (!tile.IsInteractable)
                return;

        if (_boardManager.TryGetTileSprite(PlayerColorType, out var sprite))
        {
            _boardManager.GetTile(Row, Column).ModTileColor(sprite, PlayerColorType);
            _gameController.Match(PlayerColorType);
        }
    }

    public void ResetPlayer()
    {
        Step = 0;
        Row = _originRow;
        Column = _originCol;

        PlayerColorType = ColorType.Basic;

        if (_boardManager.TryGetTile(Row, Column, out var tile))
        {
            transform.position = tile.transform.position;
            _animator.SetInteger("color", (int)PlayerColorType);
        }
    }
}
