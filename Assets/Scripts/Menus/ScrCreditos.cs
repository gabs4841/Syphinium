using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrCreditos : MonoBehaviour {
    public float volume;
    public AudioSource audios;

    private void Start()
    {
        volume = PlayerPrefs.GetFloat("volume");
        audios.volume = volume;
        Invoke("creditos", 90f);
    }

    public void creditos(){
        SceneManager.LoadScene("Menu");
    }
}
