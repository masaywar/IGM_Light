using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class background : UIWindow
{
    // Start is called before the first frame update
    void Start()
    {
        
        //transform.GetComponent<Image>().color = new Color(1, 1, 1, 0f);
        //StartCoroutine(ShowReady());
       
    }

/*IEnumerator ShowReady()
{
    int count = 0;
    while (true)
    {
            //gameObject.SetActive(true);
            transform.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
            yield return new WaitForSeconds(1f);
            transform.GetComponent<Image>().color = new Color(1, 1, 1, 0f);
            yield return new WaitForSeconds(1f);
   
    }
}*/
void Update()
    {
        Invoke("Off", 2f);
    }

    void ON()
    {
        Open();
    }

    void Off()
    {
        Close();
        Invoke("ON", 2f);
    }
}
