using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrPlayer : MonoBehaviour
{
    #region Variaveis
    #region Referencias Internas
    public GameObject[] iconeInteracao;
    private Rigidbody2D corpo;
    private Animator animacao;
    private SpriteRenderer sprite;
    #endregion
    #region Movimentação
    public int direcao = 1;
    public float velocidadeMax = 15f;
    public float eixoX;
    #endregion
    #region Pulo
    public LayerMask camadachao;
    public Transform objpe;
    public bool nochao = true;
    private float raiope = .3f;
    public float forcapulo = 25f;
    #endregion
    #region Hainu
    public GameObject hainu;
    private Animator hainuanim;
    #endregion
    #region Koza/Tp
    private ScrVouPara irei;
    public ScrKoza kozaa;
    #endregion
    #region Dano
    private bool TomeiDano = false;
    public bool tomarDano = false, piscando = false;
    public int Hainu2 = 0, vidaatual = 7, vidaperdida;
    public Animator vida;
    #endregion
    #region Mobs
    public ScrMinhoca Mobminhoca;
    public ScrLobo lobo;
    public float tempoinimigo = -2f;
    #endregion
    public bool possoandar = true, entregue = false, pode = true;
    public ScrLoading carregar;
    public Transform respawnpoint;
    public ScrQuest quest;
    public GameObject slash, particulas;
    public ParticleSystem[] particulasMorte;
    #endregion
    #region Awake
    public void Awake()
    {
        Hainu2 = PlayerPrefs.GetInt("hainu");
        vidaatual = PlayerPrefs.GetInt("vidaatual");
        if (vidaatual <= 0)
        {
            vidaatual = 7;
        }
        vida.SetInteger("vida", vidaatual);
    }
    #endregion
    #region Start
    void Start (){
        hainuanim = hainu.GetComponent<Animator>();
        corpo = GetComponent<Rigidbody2D>();
        animacao = GetComponent<Animator>();
        irei = GetComponent<ScrVouPara>();
        sprite = GetComponent<SpriteRenderer>();
        tempoinimigo = -2f;
        if (Hainu2 == 1)
        {
            corpo.transform.position = new Vector3(-13f, -6f, 0f);
            Hainu2 = 0;
            PlayerPrefs.SetInt("hainu", Hainu2);
            entregue = true;
        }
	}
    #endregion 
    #region FixedUpdate
    void FixedUpdate(){
        if (!TomeiDano){
            corpo.velocity = new Vector2(eixoX * velocidadeMax, corpo.velocity.y);
        }
    }
    #endregion 
    #region Update
    void Update()
    {
        tempoinimigo -= Time.deltaTime;
        
        if (eixoX == 0 || !nochao)
        {
            particulas.SetActive(false);
        }

        if (vidaatual <= 0)
        {
            if (possoandar)
            {
                for (int i = 0; i < particulasMorte.Length; i++)
                {
                    particulasMorte[i].gameObject.SetActive(true);
                    particulasMorte[i].Stop();
                    particulasMorte[i].Play();
                }
            }
            possoandar = false;
            animacao.SetInteger("situacao", 5);
            Invoke("suicidio", 0.3f);
            Invoke("respawn", 3.3f);
        }
        if (tempoinimigo >= 0.1f)
        {
            tomarDano = false;
        }

        #region Piscando
        if (tempoinimigo >= 0.1)
        {
            piscando = true;
        }
        else if (tempoinimigo <= 0)
        {
            piscando = false;
        }
        #endregion
        #region Bloqueando Movimentos (Se Estiver Pausado)
        if (Time.timeScale > 0){
            nochao = Physics2D.OverlapCircle(objpe.position, raiope, camadachao);
            Andar();
            Pulo();
            Animação();
            Flip();
            if (tomarDano && tempoinimigo <= 0)
            {
                TomarDano();
            }
            VerificaDano();

        }
        #endregion
    }
    #endregion
    #region Pulo
    void Pulo(){
        if (Input.GetButtonDown("Jump") && nochao)
        {
            corpo.AddForce(new Vector2(0f, forcapulo), ForceMode2D.Impulse);
        }
    }
#endregion
    #region Animação
    void Animação(){
        if (possoandar)
        {
            if (nochao)
            {
                if (Input.GetKeyDown(KeyCode.F) && !piscando)
                {
                    CancelInvoke("DesligaCorte");
                    animacao.SetInteger("situacao", 3);
                    slash.SetActive(true);
                    Invoke("DesligaCorte", 0.3f);
                }
                else if (Input.GetKeyDown(KeyCode.F) && piscando)
                {
                    CancelInvoke("DesligaCorte");
                    animacao.SetInteger("situacao", 8);
                    slash.SetActive(true);
                    Invoke("DesligaCorte", 0.3f);
                }
                else
                {
                    if (eixoX == 0 && !piscando)
                        animacao.SetInteger("situacao", 0);
                    else if (eixoX == 0 && piscando)
                        animacao.SetInteger("situacao", 6);
                    if (Mathf.Abs(eixoX) != 0 && !piscando)
                        animacao.SetInteger("situacao", 1);
                    else if (Mathf.Abs(eixoX) != 0 && piscando)
                        animacao.SetInteger("situacao", 9);
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F) && !piscando)
                {
                    CancelInvoke("DesligaCorte");
                    animacao.SetInteger("situacao", 3);
                    slash.SetActive(true);
                    Invoke("DesligaCorte", 0.3f);
                }
                else if (Input.GetKeyDown(KeyCode.F) && piscando)
                {
                    CancelInvoke("DesligaCorte");
                    animacao.SetInteger("situacao", 8);
                    slash.SetActive(true);
                    Invoke("DesligaCorte", 0.3f);
                }

                else if (!piscando)
                {
                    animacao.SetInteger("situacao", 2);
                }
                else if (piscando)
                {
                    animacao.SetInteger("situacao", 7);
                }
            }
        }
    }
        #endregion
    #region Flip
    void Flip(){
        if (possoandar)
        {
            if (eixoX > 0)
            {
                sprite.flipX = false;
                if (nochao)
                {
                    particulas.SetActive(true);
                }
            }
            else if (eixoX < 0)
            {
                sprite.flipX = true;
                if (nochao)
                {
                    particulas.SetActive(true);
                }
            }
            transform.localScale = new Vector3(direcao, 1, 0);
        }
    }
        #endregion
    #region Movimento
    void Andar (){
    eixoX = Input.GetAxis("Horizontal");
    }
    #endregion
    #region VerificaDano
    public void VerificaDano(){
        if(TomeiDano && tempoinimigo <= 0){
            animacao.SetInteger("situacao", 4);
            tempoinimigo = 1.5f;
        }
    }
    #endregion
    #region TomarDano
    public void TomarDano()
    {
        if (!sprite.flipX)
        {
            corpo.AddForce(new Vector2(-5f, 10f), ForceMode2D.Impulse);
        }
        else if (sprite.flipX)
        {
            corpo.AddForce(new Vector2(5f, 10f), ForceMode2D.Impulse);
        }

        vidaatual -= vidaperdida;
        vida.SetInteger("vida", vidaatual);
        PlayerPrefs.SetInt("vidaatual", vidaatual);
        vidaperdida = 0;
        Invoke("DesarmeDano", 0.4f);
        tomarDano = false;
        TomeiDano = true;
    }
    #endregion
    #region Suicidio
    public void suicidio()
    {
       this.gameObject.SetActive(false);
    }
    #endregion
    #region Respawn
    public void respawn()
    {
        vidaatual = 7;
        vida.SetInteger("vida", vidaatual);
        transform.position = respawnpoint.transform.position;
        this.gameObject.SetActive(true);
        possoandar = true;
    }
    #endregion
    #region DesarmeDano
    public void DesarmeDano(){
        TomeiDano = false;
    }
    #endregion
    #region DesligaCorte
    public void DesligaCorte()
    {
        slash.SetActive(false);
    }
    #endregion
    #region OnTrigger - Enter
    void OnTriggerEnter2D(Collider2D quem)
    {
        #region Casa
        if (quem.gameObject.tag == "escada")
        {
            iconeInteracao[1].SetActive(true);
            irei.escadabool = true;
        }

        if (quem.gameObject.tag == "saida")
        {
            iconeInteracao[0].SetActive(true);
            irei.saidabool = true;
        }

        if (quem.gameObject.tag == "saida2")
        {
            iconeInteracao[0].SetActive(true);
            irei.saida2bool = true;
        }

        if (quem.gameObject.tag == "corda")
        {
            iconeInteracao[1].SetActive(true);
            irei.cordabool = true;
        }

        if (quem.gameObject.tag == "alca1")
        {
            iconeInteracao[2].SetActive(true);
            irei.alca1bool = true;
        }

        if (quem.gameObject.tag == "alca2")
        {
            iconeInteracao[2].SetActive(true);
            irei.alca2bool = true;
        }

        if (quem.gameObject.tag == "porta1")
        {
            iconeInteracao[0].SetActive(true);
            irei.porta1bool = true;
        }

        if (quem.gameObject.tag == "porta2")
        {
            iconeInteracao[0].SetActive(true);
            irei.porta2bool = true;
        }
        if (quem.gameObject.tag == "interativo")
        {
            irei.interativobool = true;
            iconeInteracao[0].SetActive(true);
        }

        if (quem.gameObject.tag == "volta" && entregue)
        {
            iconeInteracao[0].SetActive(true);
            irei.voltabool = true;
        }

        if (quem.gameObject.tag == "vaso" && pode)
        {
            irei.vasobool = true;
            iconeInteracao[0].SetActive(true);
        }
        #endregion

        #region Hainu
        if (quem.gameObject.tag == "hainu")
        {
            irei.kozabool = true;
            hainuanim.SetBool("feliz", true);
            iconeInteracao[0].SetActive(true);
        }
        #endregion

        #region Placas
        if (quem.gameObject.tag == "vila1")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.estatuabool = true;
        }

        if (quem.gameObject.tag == "vila2")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.estatua2bool = true;
        }

        if (quem.gameObject.tag == "vila3")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.estatua3bool = true;
        }

        if (quem.gameObject.tag == "vila4")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.estatua4bool = true;
        }
        #endregion

        #region NPC
        if (quem.gameObject.tag == "NPCCintia")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.npc[0] = true;
        }

        if (quem.gameObject.tag == "NPCLadino")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.npc[1] = true;
        }

        if (quem.gameObject.tag == "NPCLian")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.npc[2] = true;
        }

        if (quem.gameObject.tag == "NPCLoey")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.npc[3] = true;
        }

        if (quem.gameObject.tag == "NPCLulu")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.npc[4] = true;
        }

        if (quem.gameObject.tag == "NPCMarquinhos")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.npc[5] = true;
        }

        if (quem.gameObject.tag == "NPCOliver")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.npc[6] = true;
        }

        if (quem.gameObject.tag == "NPCRapha")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.npc[7] = true;
        }

        if (quem.gameObject.tag == "NPCSergio")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.npc[8] = true;
        }

        if (quem.gameObject.tag == "NPCVolver")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.npc[9] = true;
        }

        if (quem.gameObject.tag == "NPCEntregador")
        {
            iconeInteracao[0].SetActive(true);
            kozaa.entregador = true;
            Hainu2 = 1;
            PlayerPrefs.SetInt("hainu", Hainu2);
        }
        #endregion

        #region Mobs
        if (quem.gameObject.tag == "minhoca")
        {
            Mobminhoca.minhoca = true;
        }

        if (quem.gameObject.tag == "acordalobo")
        {
            lobo.RUNBITCHRUN = true;
        }

        if (quem.gameObject.tag == "lobo")
        {
            vidaperdida = 2;
            tomarDano = true;
        }

        if (quem.gameObject.tag == "morcego")
        {
            vidaperdida = 1;
            tomarDano = true;
        }

        if (quem.gameObject.tag == "slime")
        {
            vidaperdida = 1;
            tomarDano = true;
        }

        if (quem.gameObject.tag == "bipede")
        {
            vidaperdida = 1;
            tomarDano = true;
        }
        #endregion

        #region Espinhos
        if (quem.gameObject.tag == "espinhos")
        {
            tempoinimigo = 0;
            vidaperdida = vidaatual;
            tomarDano = true;
        }
        #endregion

        #region Floresta

        if (quem.gameObject.tag == "placalagarta")
        {
            iconeInteracao[0].SetActive(true);
            irei.placabool = true;
        }

        if (quem.gameObject.tag == "placacaverna")
        {
            iconeInteracao[0].SetActive(true);
            irei.placa2bool = true;
        }

        if (quem.gameObject.tag == "caverna")
        {
            carregar.CarregarCena(5);
            irei.ParaOndeVou = "caverna";
        }

        if (quem.gameObject.tag == "pantera")
        {
            vidaperdida = 2;
            tomarDano = true;
        }
        #endregion

        #region Caverna
        if (quem.gameObject.tag == "tatu")
        {
            vidaperdida = 2;
            tomarDano = true;
        }

        if (quem.gameObject.tag == "bau")
        {
            iconeInteracao[0].SetActive(true);
            irei.baubool = true;
        }

        if (quem.gameObject.tag == "final")
        {
            iconeInteracao[0].SetActive(true);
            irei.finalbool = true;
        }

        if (quem.gameObject.tag == "fim")
        {
            iconeInteracao[0].SetActive(true);
            irei.final2bool = true;
        }

        if (quem.gameObject.tag == "vida")
        {
            Destroy(quem.gameObject);
            vidaatual++;
            vida.SetInteger("vida", vidaatual);
        }
        #endregion
    }
    #endregion
    #region OnTrigger - Exit
    void OnTriggerExit2D(Collider2D quem)
    {
        #region Casa
        if (quem.gameObject.tag == "escada")
        {
            iconeInteracao[1].SetActive(false);
            irei.escadabool = false;
        }

        if (quem.gameObject.tag == "saida")
        {
            iconeInteracao[0].SetActive(false);
            irei.saidabool = false;
        }


        if (quem.gameObject.tag == "saida2")
        {
            iconeInteracao[0].SetActive(false);
            irei.saida2bool = false;
        }

        if (quem.gameObject.tag == "corda")
        {
            iconeInteracao[1].SetActive(false);
            irei.cordabool = false;
        }

        if (quem.gameObject.tag == "alca1")
        {
            iconeInteracao[2].SetActive(false);
            irei.alca1bool = false;
        }

        if (quem.gameObject.tag == "alca2")
        {
            iconeInteracao[2].SetActive(false);
            irei.alca2bool = false;
        }

        if (quem.gameObject.tag == "porta1")
        {
            iconeInteracao[0].SetActive(false);
            irei.porta1bool = false;
        }

        if (quem.gameObject.tag == "porta2")
        {
            iconeInteracao[0].SetActive(false);
            irei.porta2bool = false;
        }
        if (quem.gameObject.tag == "interativo")
        {
            irei.interativobool = false;
            iconeInteracao[0].SetActive(false);
        }

        if (quem.gameObject.tag == "vaso" && pode)
        {
            irei.vasobool = false;
            iconeInteracao[0].SetActive(false);
        }

        if (quem.gameObject.tag == "volta" && entregue)
        {
            iconeInteracao[0].SetActive(false);
            irei.voltabool = false;
        }
        #endregion

        #region Hainu
        if (quem.gameObject.tag == "hainu")
        {
            irei.kozabool = false;
            hainuanim.SetBool("feliz", false);
            iconeInteracao[0].SetActive(false);
        }
        #endregion

        #region Placas 
        if (quem.gameObject.tag == "vila1")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.estatuabool = false;
        }

        if (quem.gameObject.tag == "vila2")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.estatua2bool = false;
        }

        if (quem.gameObject.tag == "vila3")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.estatua3bool = false;
        }

        if (quem.gameObject.tag == "vila4")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.estatua4bool = false;
        }
        #endregion

        #region NPC
        if (quem.gameObject.tag == "NPCCintia")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.npc[0] = false;
        }

        if (quem.gameObject.tag == "NPCLadino")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.npc[1] = false;
        }

        if (quem.gameObject.tag == "NPCLian")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.npc[2] = false;
        }

        if (quem.gameObject.tag == "NPCLoey")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.npc[3] = false;
        }

        if (quem.gameObject.tag == "NPCLulu")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.npc[4] = false;
        }

        if (quem.gameObject.tag == "NPCMarquinhos")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.npc[5] = false;
        }

        if (quem.gameObject.tag == "NPCOliver")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.npc[6] = false;
        }

        if (quem.gameObject.tag == "NPCRapha")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.npc[7] = false;
        }

        if (quem.gameObject.tag == "NPCSergio")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.npc[8] = false;
        }

        if (quem.gameObject.tag == "NPCVolver")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.npc[9] = false;
        }

        if (quem.gameObject.tag == "NPCEntregador")
        {
            iconeInteracao[0].SetActive(false);
            kozaa.entregador = false;
        }
        #endregion

        #region Mobs
        if (quem.gameObject.tag == "minhoca")
        {
            Mobminhoca.minhoca = false;
            Mobminhoca.CancelInvoke("pula");
            Mobminhoca.CancelInvoke("acorda");
            Mobminhoca.CancelInvoke("dorme");
        }

        if (quem.gameObject.tag == "inimigo" || quem.gameObject.tag == "lobo")
        {
            TomeiDano = false;
        }
        #endregion

        #region Floresta 
        if (quem.gameObject.tag == "placalagarta")
        {
            iconeInteracao[0].SetActive(false);
            irei.placabool = false;
        }

        if (quem.gameObject.tag == "placacaverna")
        {
            iconeInteracao[0].SetActive(false);
            irei.placa2bool = false;
        }
        #endregion

        #region Caverna
        if (quem.gameObject.tag == "bau")
        {
            iconeInteracao[0].SetActive(false);
            irei.baubool = false;
        }

        if (quem.gameObject.tag == "final")
        {
            iconeInteracao[0].SetActive(false);
            irei.finalbool = false;
        }
        #endregion
    }
    #endregion
    #region OnCollision - Enter
    void OnCollisionEnter2D(Collision2D ela)
    {
        if (ela.gameObject.tag == "passaro" && nochao)
        {
            transform.parent = ela.transform;
        }

        if (ela.gameObject.tag == "inimigo")
        {
            vidaperdida = 1;
            tomarDano = true;
        }
    }
    #endregion
    #region OnColission - Exit
    void OnCollisionExit2D(Collision2D ela)
    {
        if (ela.gameObject.tag == "passaro")
        {
            corpo.transform.parent = null;
        }
    }
    #endregion
}