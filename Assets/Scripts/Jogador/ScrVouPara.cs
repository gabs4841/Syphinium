using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScrVouPara : MonoBehaviour
{

    public bool escadabool = false, cordabool = false, alca1bool = false, alca2bool = false, porta1bool = false, porta2bool = false, saidabool = false, portabool = false, interativobool = false, presentebool = false, kozabool = false, voltabool = false, vasobool = false, saida2bool = false, mapabool = false, baubool = false, finalbool = false, final2bool = false, placabool = false, placa2bool = false;
    public string ParaOndeVou;
    public GameObject presente, mapa, esc, cgfinal, preto, placa, placa2;
    public int valorinventario = 1;
    public ScrPlayer jogador;
    public ScrQuest quest;
    public ScrBau bau;
    public ScrLoading loading;
    public ScrAudio som;
    public AudioSource final;
    public float volume;

    #region Inventario
    public GameObject inventario;
    private Animator caixa;
    #endregion

    void Start()
    {
        caixa = inventario.GetComponent<Animator>();
        volume = PlayerPrefs.GetFloat("volume");
    }

    void Update()
    {
        if (placabool && Input.GetKeyDown(KeyCode.E)){
            placa.SetActive(true);
        }

        if (!placabool)
        {
            placa.SetActive(false);
        }

        if (placa2bool && Input.GetKeyDown(KeyCode.E))
        {
            placa2.SetActive(true);
            quest.ativa = 7;
        }

        if (!placa2bool)
        {
            placa2.SetActive(false);
        }

        if (finalbool && Input.GetKeyDown(KeyCode.E))
        {
            preto.SetActive(true);
            cgfinal.SetActive(true);
            Invoke("floresta2", 37.7f);
            som.audios[0].Stop();
            final.volume = volume;
        }

        if (final2bool)
        {
            preto.SetActive(true);
            cgfinal.SetActive(true);
            Invoke("creditos", 10.7f);
            som.audios[0].Stop();
            final.volume = volume;
        }

        if (baubool && Input.GetKeyDown(KeyCode.E))
        {
            bau.acordei = true;
        }

        if (interativobool && Input.GetKeyDown(KeyCode.E))
        {
            caixa.SetInteger("conteudo", valorinventario);
            PlayerPrefs.SetInt("inventario", valorinventario);
            presentebool = true;
            quest.ativa = 1;
            Destroy(presente);
        }

        if (vasobool && Input.GetKeyDown(KeyCode.E))
        {
            mapabool = true;
            valorinventario = 3;
            caixa.SetInteger("conteudo", valorinventario);
            PlayerPrefs.SetInt("inventario", valorinventario);
            quest.ativa = 3;
            jogador.iconeInteracao[0].SetActive(false);
            jogador.pode = false;
            vasobool = false;
        }

        if (escadabool && Input.GetKeyDown(KeyCode.E))
        {
            ParaOndeVou = "sotao";
        }

        if (porta1bool && Input.GetKeyDown(KeyCode.E))
        {
            ParaOndeVou = "cozinha";
        }

        if (porta2bool && Input.GetKeyDown(KeyCode.E))
        {
            ParaOndeVou = "sotao";
        }

        if (alca1bool && Input.GetKeyDown(KeyCode.E))
        {
            ParaOndeVou = "entrada";
        }

        if (alca2bool && Input.GetKeyDown(KeyCode.E))
        {
            ParaOndeVou = "porao";
        }
        if (cordabool && Input.GetKeyDown(KeyCode.E))
        {
            ParaOndeVou = "entrada";
            if (!jogador.pode)
            {
                Invoke("mensagem", 1.2f);
            }
        }

        if (voltabool && Input.GetKeyDown(KeyCode.E))
        {
            ParaOndeVou = "volta";
        }
        if (saidabool && Input.GetKeyDown(KeyCode.E) && !presentebool)
        {
            quest.ativa = 0;
        }

        if (saidabool && Input.GetKeyDown(KeyCode.E) && presentebool)
        {
            ParaOndeVou = "saida";
        }

        if (saida2bool && Input.GetKeyDown(KeyCode.E) && mapabool)
        {
            ParaOndeVou = "saida";
        }

        if (mapa.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
            esc.SetActive(false);
            Time.timeScale = 1f;
            mapa.SetActive(false);
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            jogador.possoandar = true;
        }

        if (kozabool && Input.GetKeyDown(KeyCode.E))
        {
            if (mapa.activeInHierarchy)
            {
                mapa.SetActive(false);
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                jogador.possoandar = true;
            }
            else if (!mapa.activeInHierarchy)
            {
                mapa.SetActive(true);
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                jogador.possoandar = false;
            }
        }

        if (!kozabool)
        {
            mapa.SetActive(false);
        }
    }

    void mensagem (){
        quest.ativa = 4;
    }

    void creditos()
    {
        loading.CarregarCena(6);
    }

    void floresta2()
    {
        loading.CarregarCena(8);
    }
}
