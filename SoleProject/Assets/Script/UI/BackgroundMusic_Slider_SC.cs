using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BackgroundMusic_Slider_SC : MonoBehaviour
{

    public AudioMixer backgroundMusicmixer;

    public void BackgroundSetLevel(float sliderVal)
    {
        backgroundMusicmixer.SetFloat("BackgroundMusicParams", Mathf.Log10(sliderVal) * 20);
    }
}
