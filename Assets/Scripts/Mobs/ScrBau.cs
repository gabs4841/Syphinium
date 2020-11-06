using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBau : MonoBehaviour
{

    public float velocidade = 20f;
    public bool acordei = false, HUE;
    public Transform[] destinos;

    private Animator animacao;
    private SpriteRenderer spriteRenderer;
    private Vector3 destino;
    private int destinoAtual = 0;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animacao = GetComponent<Animator>();
    }

    void Update()
    {
        destino = destinos[destinoAtual].position;

        if (acordei)
        {
            animacao.SetInteger("situacao",1);
            Invoke("toputo", 0.4f);
            if(HUE){
             transform.position = Vector2.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);
            }
            if (transform.position.x > destino.x) spriteRenderer.flipX = true;
            else spriteRenderer.flipX = false;
        }

        if (transform.position == destino)
        {
            if (++destinoAtual >= destinos.Length) destinoAtual = 0;
            destino = destinos[destinoAtual].position;
        }
    }

    public void toputo()
    {
        animacao.SetInteger("situacao", 2);
        HUE = true;
    }
}
