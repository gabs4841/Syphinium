using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrIntro : MonoBehaviour {

    public GameObject Canvas, Controles, Preto, Pause;
    public ScrAudio Audio;
    public AudioSource audios;
    public float volume;
    private bool javi = false;

    void Start () {
        volume = PlayerPrefs.GetFloat("volume");
        audios.volume = volume;
        Pause.SetActive(false);
        Invoke("terminei", 29f);
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) || javi || Input.GetKeyDown(KeyCode.Space))
        {
            Pause.SetActive(true);
            Preto.SetActive(false);
            Controles.SetActive(true);
            Audio.audios[0].Play();
            Canvas.SetActive(false);
        }
	}

    void terminei()
    {
        javi = true;
    }
}
