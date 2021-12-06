using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISetting : UIWindow
{
    private SwipeInteract _swipe;

    protected override void Awake()
    {
        _swipe = FindObjectOfType<SwipeInteract>();
        base.Awake();
        Close();
    }

    public override void Open()
    {
        base.Open();
        _swipe.enabled = false;
    }

    public override void Close()
    {
        _swipe.enabled = true;
        base.Close();
    }
}
