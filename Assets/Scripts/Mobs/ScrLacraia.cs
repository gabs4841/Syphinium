using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrLacraia : MonoBehaviour {

    public Animator animacao;
    public ScrPlayer Jogador;

    void Start () {
        animacao = GetComponent<Animator>();
    }
	
	void Update () {
    }

    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "Player")
        {
            Invoke("Atacar", 0.15f);
            Invoke("Dano", 0.15f);
            Invoke("Relaxar", 0.25f);
        }
    }

    void OnTriggerExit2D(Collider2D quem)
    {
        CancelInvoke("Dano");
    }

    public void Atacar()
    {
        animacao.SetBool("ToPuto", true);
    }

    public void Relaxar()
    {
        animacao.SetBool("ToPuto", false);
    }

    public void Dano()
    {
        Jogador.vidaperdida = 1;
        Jogador.tomarDano = true;
    }
}
