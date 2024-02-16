using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EffectSound_Slider_SC : MonoBehaviour
{
    public AudioMixer effectSoundmixer;

    public void EffectSoundSetLevel(float sliderVal)
    {
        effectSoundmixer.SetFloat("EffectSoundParams", Mathf.Log10(sliderVal) * 20);
    }
}
