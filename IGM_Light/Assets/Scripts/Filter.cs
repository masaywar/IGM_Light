using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filter : MonoBehaviour
{
    //public Sprite[] colorFilters = new Sprite[9];

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D o)
    {
        Debug.Log("boom");
        if (o.gameObject.tag.Equals("Player"))
        //부딪힌 객체의 태그를 비교해서 적인지 판단합니다.
        {
            Destroy(this.gameObject);
        }
    }

}
