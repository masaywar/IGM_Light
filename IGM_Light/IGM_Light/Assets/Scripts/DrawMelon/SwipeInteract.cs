using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using System;

public class SwipeInteract : LeanFingerSwipe
{

    public int Threshold;
    private float _distance;
    private Coroutine _coroutine = null;
    [HideInInspector]public Player _player;

    int count = 0;
    protected override void Start()
    {
        base.Start();
    }

    public void OnSwipe(Vector3 swipe)
    {
        if(_coroutine == null)
            _coroutine = StartCoroutine(onSwipe(swipe));
    }

    private IEnumerator onSwipe(Vector3 swipe)
    {
        yield return new WaitForSeconds(0.02f);

        if (_distance < Threshold) 
        {
            yield return null;
        }
        else
        {
            Vector2Int direction;

            if (swipe.x>=0 && swipe.y>=0)
            {
                if(swipe.x >= swipe.y)
                    direction = new Vector2Int(0, 1);
                else 
                    direction = new Vector2Int(-1, 0);
            }

            else if (swipe.x < 0 && swipe.y >= 0)
            {
                if(-swipe.x >= swipe.y)
                    direction = new Vector2Int(0, -1);
                else 
                    direction = new Vector2Int(-1, 0);
            }

            else if (swipe.x >= 0 && swipe.y < 0)
            {
                if(-swipe.x >= -swipe.y)
                    direction = new Vector2Int(0, 1);
                else 
                    direction = new Vector2Int(1, 0);
            }
            else
            {
                if(-swipe.x >= -swipe.y)
                    direction = new Vector2Int(0, -1);
                else 
                    direction = new Vector2Int(1, 0);
            }

            _player.Move(direction);
        }
        _coroutine = null;
    }

    public void OnTouch(Single distance)
    {
        _distance = distance;
        if (distance < Threshold)
            _player.Draw();
    }
}
