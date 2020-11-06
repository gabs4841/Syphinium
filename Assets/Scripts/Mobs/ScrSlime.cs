using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrSlime : MonoBehaviour
{
    public float tempoinimigo = -1f;
    private bool TomeiDano = false, tomarDano = false, drop = false;
    public int vidaatual = 3, dados;
    public GameObject vida;

    #region Mob
    public GameObject coiso;
    public float Velocidade = 0f, forcapulo, tempo;
    public Transform[] paraondeir;
    public int contador = 0;
    private Rigidbody2D corpo;
    public bool tonoar = false;
    private Animator animacao;
    public CircleCollider2D colider;
    #endregion

    void Start()
    {
        animacao = GetComponent<Animator>();
        corpo = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        #region Sistema De Dano
        tempoinimigo -= Time.deltaTime;

        if (vidaatual <= 0)
        {
            dados = Random.Range(0, 3);
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

        #region Comportamento Mob
        tempo += Time.deltaTime;

        if (vidaatual == 0)
        {
            animacao.SetInteger("situacao", 3);
        }
        if (tonoar)
        {
            colider.isTrigger = true;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            if (vidaatual > 0)
            {
                animacao.SetInteger("situacao", 2);
            }
            coiso.transform.position = Vector3.MoveTowards(coiso.transform.position, paraondeir[contador].position, Velocidade * Time.deltaTime);
        }
        else
        {
            colider.isTrigger = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            if (vidaatual > 0)
            {
                animacao.SetInteger("situacao", 1);
            }
        }

        if (tempo >= 1)
        {
            tonoar = false;
            Invoke("Pula", 1f);
            tempo = -1;
        }

        if (coiso.transform.position == paraondeir[contador].position)
        {
            contador++;
            coiso.transform.localScale = new Vector3(coiso.transform.localScale.x * -1, coiso.transform.localScale.y, coiso.transform.localScale.z);
            if (contador == 2)
            {
                contador = 0;
            }
        }
        #endregion
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
        if (!drop && dados == 2)
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
    #region Pula
    public void Pula()
    {
        tonoar = true;
        corpo.AddForce(new Vector2(0f, forcapulo), ForceMode2D.Impulse);
    }
    #endregion
}
