using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrUrsao : MonoBehaviour {

    private Animator animacao;
    private SpriteRenderer spriteRenderer;

    public float tempoinimigo = -1f;
    private bool TomeiDano = false, tomarDano = false, drop = false;
    public int vidaatual = 3, dados;
    public GameObject vida;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animacao = GetComponent<Animator>();
    }

    void Start () {
		
	}

	void Update () {
        #region Sistema De Dano
        tempoinimigo -= Time.deltaTime;

        if (vidaatual <= 0)
        {
            dados = Random.Range(0, 99);
            animacao.SetInteger("situacao", 2);
            Invoke("suicidio", 0.3f);
        }

        if (tempoinimigo >= 0.1f)
        {
            tomarDano = false;
        }

        if (tomarDano && tempoinimigo <= 0)
        {
            TomarDano();
        }
        VerificaDano();
        #endregion

        if (!TomeiDano)
        {
            animacao.SetInteger("situacao", 0);
        }
    }

    #region Sistema De Dano
    #region VerificaDano
    public void VerificaDano()
    {
        if (TomeiDano && tempoinimigo <= 0)
        {
            tempoinimigo = 0.5f;
        }
    }
    #endregion
    #region TomarDano
    public void TomarDano()
    {
        vidaatual--;
        animacao.SetInteger("situacao", 1);
        Invoke("DesarmeDano", 0.4f);
        tomarDano = false;
        TomeiDano = true;
    }
    #endregion
    #region DesarmeDano
    public void DesarmeDano()
    {
        TomeiDano = false;
    }
    #endregion
    #region Suicidio
    public void suicidio()
    {
        if (!drop && dados != 2)
        {
            Instantiate(vida, transform.position, Quaternion.identity);
            drop = true;
        }
        this.gameObject.SetActive(false);
    }
    #endregion
    #region OnTrigger - Enter
    void OnTriggerEnter2D(Collider2D quem)
    {
        if (quem.gameObject.tag == "slash")
        {
            tomarDano = true;
        }
    }
    #endregion
    #endregion
}
