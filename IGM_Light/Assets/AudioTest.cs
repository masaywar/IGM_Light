using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioClip slide;
    public AudioClip portal;
    public AudioClip filter;
    public AudioClip Obstacle;

    AudioSource source;

    void Awake()
    {
        this.source = GetComponent<AudioSource>();
    }

    public void PlaySound(string action)
    {
        switch (action)
        {
            case "slide":
                source.clip = slide;
                break;
            case "portal":
                source.clip = portal;
                break;
            case "filter":
                source.clip = filter;
                break;
            case "Obstacle":
                source.clip = Obstacle;
                break;
        }
        source.Play();
    }
}
