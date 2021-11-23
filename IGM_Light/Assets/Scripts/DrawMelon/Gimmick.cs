using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gimmick : MonoBehaviour
{
  public bool Weakproperty(CustomTile onTile, int enterNum)  //weakTile
    {
        if(enterNum!=1)
           return false;
        var BrokeTile = Resources.Load<GameObject>("Prefabs/Gimmick/BrokeTile"); 
        var BrokeTileObject = Instantiate(BrokeTile, onTile.transform.position, Quaternion.identity, onTile.transform);
        return true;
    }

    public void Slide(CustomTile onTile,Anim anim)  //iceTile, iceTile 다음 타일로 계속 이동
    {
        anim.Sliding();
    }
}
