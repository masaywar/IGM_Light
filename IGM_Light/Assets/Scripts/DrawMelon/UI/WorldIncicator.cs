using UnityEngine;
using UnityEngine.UI;

public class WorldIncicator : MonoBehaviour 
{
    public Image[] knobs;

    public Sprite activeKnob;
    public Sprite deactiveKnob;

    private void Awake()
    {
        foreach(var knob in knobs)
            knob.sprite = deactiveKnob;

        knobs[0].sprite = activeKnob;
    }

    public void OnChangeScrollPivot(int pivot)
    {
        foreach(var knob in knobs)
            knob.sprite = deactiveKnob;

        knobs[pivot].sprite = activeKnob;
    }   
}