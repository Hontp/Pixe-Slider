using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{

    public AudioMixer mixer;
    public Slider Vslider;
    public Slider SFXslider;

    // Start is called before the first frame update
    void Start()
    {
        Vslider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        SFXslider.value = PlayerPrefs.GetFloat("VFXVolume", 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevelMusic()
    {
        float sliderValue = Vslider.value;
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void SetLevelSFX()
    {
        float sliderValue1 = SFXslider.value;
        mixer.SetFloat("VFXVolume", Mathf.Log10(sliderValue1) * 20);
        PlayerPrefs.SetFloat("VFXVolume", sliderValue1);
    }
}
