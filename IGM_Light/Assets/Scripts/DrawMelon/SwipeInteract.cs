using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using System;

public class SwipeInteract : LeanFingerSwipe
{
    public Player Player;
    public int Threshold;
    
    private float _distance;

    private Coroutine _coroutine = null;

    int count = 0;
    protected override void Start()
    {
        base.Start();
        Player = GameObject.FindWithTag("Player").GetComponent<Player>();
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
            Vector2 direction;

            if (swipe.x>=0 && swipe.y>=0)
            {
                if(swipe.x >= swipe.y)
                    direction = new Vector2(0, 1);
                else 
                    direction = new Vector2(-1, 0);
            }

            else if (swipe.x < 0 && swipe.y >= 0)
            {
                if(-swipe.x >= swipe.y)
                    direction = new Vector2(0, -1);
                else 
                    direction = new Vector2(-1, 0);
            }

            else if (swipe.x >= 0 && swipe.y < 0)
            {
                if(-swipe.x >= -swipe.y)
                    direction = new Vector2(0, 1);
                else 
                    direction = new Vector2(1, 0);
            }
            else
            {
                if(-swipe.x >= -swipe.y)
                    direction = new Vector2(0, -1);
                else 
                    direction = new Vector2(1, 0);
            }

            Player.Move(direction);
        }
        _coroutine = null;
    }

    public void OnTouch(Single distance)
    {
        _distance = distance;
        print(_distance);
        if (distance < Threshold)
        {
            Player.Draw();
        }
    }

    
}
