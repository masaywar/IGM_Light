using UnityEngine;
using System;
using System.Collections;

public class AnimationManager : Singleton<AnimationManager> 
{
    public Animator[] Animators;
    
    public void PlayAnimation(ColorType color, string animationName)
    {
        Animators[(int)color].Play(animationName);
    }

    public void PlayAnimation(ColorType color, string animationName, Action action, float wait)
    {
        Animators[(int)color].Play(animationName);
        StartCoroutine(WaitForMoments(new WaitForSeconds(wait), action));
    }

    private IEnumerator WaitForMoments(WaitForSeconds wait, Action action)
    {
        yield return wait;
        action();
    }
}