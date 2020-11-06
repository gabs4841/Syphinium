using UnityEngine;

public class ScrMorcego : MonoBehaviour
{
    #region Mob
    public float velocidade = 15f;
    public bool destinoAleatorio;
    public Transform[] destinos;
    private Animator animacao;
    private SpriteRenderer spriteRenderer;
    private Vector3 destino;
    private int destinoAtual = 0;
#endregion 

    public float tempoinimigo = -1f;
    private bool TomeiDano = false, tomarDano = false, drop = false;
    public int vidaatual = 3, dados;
    public GameObject vida;
    
    #region Awake
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animacao = GetComponent<Animator>();
    }
    #endregion

    private void Update()
    {
        #region Sistema De Dano
        tempoinimigo -= Time.deltaTime;

        if(vidaatual <= 0)
        {
            dados = Random.Range(0, 3);
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

        #region Comportamento Do Mob 
        destino = destinos[destinoAtual].position;

        if (!TomeiDano)
        {
            transform.position = Vector2.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);
        }

        if (transform.position.x > destino.x) spriteRenderer.flipX = true;
        else spriteRenderer.flipX = false;

        if (transform.position == destino)
        {
            if (destinoAleatorio)
            {
                destino = destinos[Random.Range(0, destinos.Length)].position;
            }
            else
            {
                if (++destinoAtual >= destinos.Length) destinoAtual = 0;
                destino = destinos[destinoAtual].position;
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
        animacao.SetInteger("situacao", 0);
        TomeiDano = false;
    }
    #endregion
    #region Suicidio
    public void suicidio()
    {
        if (!drop && dados == 2){
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