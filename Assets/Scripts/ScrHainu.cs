using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrHainu : MonoBehaviour {

    private float eixoX, eixoY;
    public float velocidade;
    private Rigidbody2D corpo;

	void Start () {
        corpo = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        corpo.velocity = new Vector2(eixoX * velocidade, eixoY * velocidade);
    }
    void Update () {
        eixoX = Input.GetAxis("Horizontal");
        eixoY = Input.GetAxis("Vertical");
    }
}
