using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeEffect : MonoBehaviour
{
    private float time;
    private float _fadeTime = 1f;
    public bool fade_in;
    public bool fade_out;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fade_in)
        {
            if (time < 3f)
            {
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, time / 3);  //알파는 계속 증가
            }
            else
            {
                time = 0;
                this.gameObject.SetActive(false);
            }
            time += Time.deltaTime;
        }
        if (fade_out)
        {
            if (time < _fadeTime)
            {
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f - time / _fadeTime);
            }
            else
            {
                time = 0;
                this.gameObject.SetActive(false);
            }
            time += Time.deltaTime;
        }
    }
}
