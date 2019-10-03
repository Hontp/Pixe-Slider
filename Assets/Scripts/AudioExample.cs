using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioExample : MonoBehaviour
{

    public AudioMixer myMixer;
    // Start is called before the first frame update
    void Start()
    {
        myMixer.SetFloat("MusicVolume", -80.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
