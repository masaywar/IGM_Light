using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class WorldSelectScrollRect : MonoBehaviour
{
    private RectTransform _pivot;
    private RectTransform _content;

    public RectTransform[] WorldTransforms;
    [SerializeField]private Vector3[] _positions;

    [SerializeField] private float _distance = 0.00f;

    private void Awake()
    {   
        _pivot = transform.Find("Pivot") as RectTransform;
        _content = transform.Find("Content") as RectTransform;

        WorldTransforms = new RectTransform[GameManager.Instance.SpriteDatabase.WorldsSprites.Count];
        _positions = new Vector3[FixedValues.WORLDS];

        for(int k=0; k<GameManager.Instance.SpriteDatabase.WorldsSprites.Count; k++)
        {
            int index = k;

            WorldTransforms[k] = _content.GetChild(k) as RectTransform;
            WorldTransforms[k].GetComponent<Image>().sprite = GameManager.Instance.SpriteDatabase.WorldsSprites[k].sprites[UserDataInstance.Instance.WorldsLastClearData[k]];
            WorldTransforms[k].GetComponent<Button>().onClick.AddListener(()=>
            {
                UIManager.Instance.GetWindow<UIWorldSelect>("UIWorldSelect").OnSelectWorld(index+1);
            }
            );
            WorldTransforms[k].gameObject.SetActive(true);
        }
    }

    private void Update() 
    {
        for(int k=0; k<GameManager.Instance.SpriteDatabase.WorldsSprites.Count; k++)
        {
            _positions[k] = WorldTransforms[k].position;
        }

        _distance = Vector3.Distance(_positions[0], _positions[1]);

        #if UNITY_EDITOR
        if(Input.GetMouseButtonUp(0))
        {
            int minIdx = FixedValues.WORLDS+1;
            float min = Mathf.Infinity;

            for(int k=0; k<GameManager.Instance.SpriteDatabase.WorldsSprites.Count; k++)
            {
                float distance = Vector3.Distance(_pivot.position, _positions[k]);
                if (distance < min)
                {
                    min = distance;
                    minIdx = k;
                }
            }

            _content.position = new Vector3(-_distance*minIdx, _content.position.y, _content.position.z);
        }
        #endif

        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            print("touch");
            if(touch.phase == TouchPhase.Ended)
            {
                int minIdx = FixedValues.WORLDS+1;
                float min = Mathf.Infinity;

                for(int k=0; k<GameManager.Instance.SpriteDatabase.WorldsSprites.Count; k++)
                {
                    float distance = Vector3.Distance(_pivot.position, _positions[k]);
                    if (distance < min)
                    {
                        min = distance;
                        minIdx = k;
                    }
                }

                _content.position = new Vector3(-_distance*minIdx, _content.position.y, _content.position.z); 
            }
        }
        
    }
}

  
