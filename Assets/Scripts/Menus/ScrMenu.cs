using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class ScrMenu : MonoBehaviour
{
    #region Variaveis
    public Button BotaoNovoJogo, BotaoCarregarJogo, BotaoVoltarPlay;
    public Button BotaoJogar, BotaoOpcoes, BotaoSair, BotaoCreditos;
    public Button BotaoVoltar, BotaoSalvarPref, BotaoInvisivel, BotaoInvisivel2;
    public ScrAudio GerenteDeSons;
    public Slider BarraVolume, BarraEfeitos;
    public Toggle CaixaModoJanela;
    public GameObject control, logotipo, bgsliders;
    private float volume, efeitos;
    private int modoJanelaAtivo;
    public ScrLoading carregar;
    public int continuar;
    #endregion
    #region Awake
    void Awake()
    {
        continuar = PlayerPrefs.GetInt("continue");
        volume = PlayerPrefs.GetFloat("volume");
        efeitos = PlayerPrefs.GetFloat("efeitos");

        modoJanelaAtivo = PlayerPrefs.GetInt("modoJanela");
        
        BarraVolume.value = volume;
        GerenteDeSons.audios[0].volume = volume;

        BarraEfeitos.value = efeitos;
        GerenteDeSons.audios[1].volume = efeitos;

        if (modoJanelaAtivo == 1)
        {
            Screen.fullScreen = false;
            CaixaModoJanela.isOn = true;
        }
        else
        {
            Screen.fullScreen = true;
            CaixaModoJanela.isOn = false;
        }
    }
    #endregion
    #region Visibilidade Dos Botões
    public void Opcoes(bool ativarOP)
    {
        GerenteDeSons.audios[1].Play();
        BotaoJogar.gameObject.SetActive(!ativarOP);
        BotaoOpcoes.gameObject.SetActive(!ativarOP);
        BotaoSair.gameObject.SetActive(!ativarOP);
        BotaoCreditos.gameObject.SetActive(!ativarOP);
        BotaoInvisivel.gameObject.SetActive(ativarOP);
        BarraVolume.gameObject.SetActive(ativarOP);
        CaixaModoJanela.gameObject.SetActive(ativarOP);
        BotaoVoltar.gameObject.SetActive(ativarOP);
        BotaoSalvarPref.gameObject.SetActive(ativarOP);
        BarraEfeitos.gameObject.SetActive(ativarOP);
        BotaoInvisivel2.gameObject.SetActive(ativarOP);
        control.SetActive(ativarOP);
        bgsliders.SetActive(ativarOP);
    }

    public void Play(bool ativarXP)
    {
        GerenteDeSons.audios[1].Play();
        BotaoJogar.gameObject.SetActive(!ativarXP);
        BotaoCreditos.gameObject.SetActive(!ativarXP);
        BotaoOpcoes.gameObject.SetActive(!ativarXP);
        BotaoSair.gameObject.SetActive(!ativarXP);
        BotaoInvisivel.gameObject.SetActive(ativarXP);
        BotaoNovoJogo.gameObject.SetActive(ativarXP);
        BotaoCarregarJogo.gameObject.SetActive(ativarXP);
        BotaoVoltarPlay.gameObject.SetActive(ativarXP);
    }
    #endregion
    #region Salvar
    public void SalvarPreferencias()
    {
        GerenteDeSons.audios[1].Play();
        if (CaixaModoJanela.isOn == true)
        {
            modoJanelaAtivo = 1;
        }
        else
        {
            modoJanelaAtivo = 0;
        }

        PlayerPrefs.SetFloat("volume", BarraVolume.value);
        PlayerPrefs.SetFloat("efeitos", BarraEfeitos.value);
        PlayerPrefs.SetInt("modoJanela", modoJanelaAtivo);
        Opcoes(false);
    }
    #endregion
    #region Sair
    public void Sair()
    {
        GerenteDeSons.audios[1].Play();
        Application.Quit();
    }
    #endregion
    #region Crédito
    public void Creditos()
    {
        GerenteDeSons.audios[1].Play();
        SceneManager.LoadScene("Creditos");
    }
    #endregion
    #region CarregarJogo
    public void carregarjogo()
    {
        carregar.CarregarCena(continuar);
    }
    #endregion
}