using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    TextMeshProUGUI resourceText;
    private int resource;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        resourceText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        resource = player.Step;
        resourceText.text = resource.ToString();
    }

    public int GetResource()
    {
        return resource;
    }

    public void AddResource(int addition)
    {
        resource += addition;
    }

}
