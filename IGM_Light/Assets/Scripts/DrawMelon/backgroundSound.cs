﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundSound : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource backmusic;

    public void BackGroundMusicOffButton() //배경음악 키고 끄는 버튼
    {
        BackgroundMusic = GameObject.Find("Main Camera");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); //배경음악 저장해둠
        if (backmusic.isPlaying) backmusic.Pause();
        else backmusic.Play();
    }
}