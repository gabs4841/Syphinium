using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrCaverna : MonoBehaviour {

    private SpriteRenderer sprite;
    private Rigidbody2D corpo;
    public float eixoX, velocidadeMax;

    void Start () {
        corpo = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update () {
        eixoX = Input.GetAxis("Horizontal");

        if (sprite.isVisible)
        {
            corpo.velocity = new Vector2(eixoX * velocidadeMax, corpo.velocity.y);
        }
    }
}
