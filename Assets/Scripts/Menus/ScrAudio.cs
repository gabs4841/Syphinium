using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrAudio : MonoBehaviour {

    public AudioSource[] audios;
    public float XD;
    public float volume;

    void Start(){
         volume = PlayerPrefs.GetFloat("volume");
        audios[0].volume = volume;
    }

    public void musica(float XD)
    {
        audios[0].volume = XD;
    }

    public void efeitos(float XD)
    {
        audios[1].volume = XD;
    }
}
