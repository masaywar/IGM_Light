using UnityEngine;
using UnityEngine.UI;
using System;
using Lean.Touch;

public class UIWorldSelect : UIWindow
{
    [SerializeField]private Image[] _worldImages;
    private UIManager _uiManager;
    public SpriteDatabaseLoader SpriteDatabase;

    private float _distance;
    protected override void Awake()
    {
        base.Awake();

        _uiManager = UIManager.Instance;

        for(int k=0; k<SpriteDatabase.WorldsSprites.Count; k++)
        {
            _worldImages[k].sprite = SpriteDatabase.WorldsSprites[k].sprites[UserDataInstance.Instance.WorldsLastClearData[k]];
        }
    }

    public void OnSelectWorld(int index)
    {
        UserDataInstance.Instance.CurrentWorld = index;

        var uiStage = _uiManager.GetWindow<UIStageSelect>("UIStageSelect");
        uiStage.World = UserDataInstance.Instance.CurrentWorld;
        uiStage.Open(true);
    }
}
