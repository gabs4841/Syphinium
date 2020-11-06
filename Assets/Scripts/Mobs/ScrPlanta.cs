using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlanta : MonoBehaviour {

    public Animator animacao;
    public Collider2D ColliderPlanta;
    public ScrPlayer Jogador;
    public int continuar = 4;


	void Start () {
        animacao = GetComponent<Animator>();
        ColliderPlanta = GetComponent<Collider2D>();
        PlayerPrefs.SetInt("continue", continuar);
	}
	
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D ela)
    {
        if (ela.gameObject.tag == "Player")
        {
            Invoke("Fechar", 1f);
            Invoke("Dano", 1f);
            Invoke("Abrir", 2f);
        }
    }

    void OnCollisionExit2D(Collision2D ela)
    {
        CancelInvoke("Dano");
    }

    public void Fechar()
    {
        animacao.SetBool("ToAberta", false);
        ColliderPlanta.isTrigger = true;
    }

    public void Abrir()
    {
        animacao.SetBool("ToAberta", true);
        ColliderPlanta.isTrigger = false;
    }

    public void Dano()
    {
        Jogador.vidaperdida = 2;
        Jogador.tomarDano = true;
    }
}
