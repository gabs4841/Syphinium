using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrUrsinho : MonoBehaviour {

    private Animator animacao;
    private SpriteRenderer spriteRenderer;
    public float tempoinimigo = -1f;
    public bool acordei = false;
    private bool TomeiDano = false, tomarDano = false, drop = false;
    public int vidaatual = 3, dados;
    public GameObject vida, coiso;
    public Transform pontofinal;
    public float Velocidade;

    #region Awake
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animacao = GetComponent<Animator>();
    }
    #endregion

	void Start () {
		
	}
	
	void Update ()
    {   
        #region Sistema De Dano
        tempoinimigo -= Time.deltaTime;

        if (vidaatual <= 0)
        {
            dados = Random.Range(0, 99);
            acordei = false;
            animacao.SetInteger("situacao", 3);
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

        #region Comportamento Do Mob
        if (acordei)
        {
            animacao.SetInteger("situacao", 1);
            coiso.transform.position = Vector3.MoveTowards(coiso.transform.position, pontofinal.position, Velocidade * Time.deltaTime);

             if (coiso.transform.position == pontofinal.position){
                 acordei = false;
                 animacao.SetInteger("situacao", 0);   
            }
        }
        #endregion
    }

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
        animacao.SetInteger("situacao", 2);
        Invoke("DesarmeDano", 0.4f);
        tomarDano = false;
        TomeiDano = true;
    }
    #endregion
    #region DesarmeDano
    public void DesarmeDano()
    {
        animacao.SetInteger("situacao", 1);
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
            acordei = true;
        }
    }
    #endregion
}
