using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrControles : MonoBehaviour {

    public GameObject canvas;
    public ScrPlayer jogador;
    public int continuar = 1;

    void Start () {
        jogador.possoandar = false;
        jogador.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.SetInt("continue", continuar);
            jogador.possoandar = true;
            jogador.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            jogador.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            canvas.SetActive(false);
        }
    }
}
