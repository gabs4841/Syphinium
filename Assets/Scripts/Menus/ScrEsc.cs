using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class ScrEsc : MonoBehaviour
{
    #region Variaveis
    public Button Salvar, Sair;
  //  public Slider Musica, Ef\ eitos;
  //  public Button VoltarOp, SalvarOp, Controles;
    public GameObject secundario;
    #endregion
    #region Start
    void Start () {
     //   OpcoesXD(false);

        #region Setando Botoes
        Salvar.onClick = new Button.ButtonClickedEvent();
     //   Opcoes.onClick = new Button.ButtonClickedEvent();
        Sair.onClick = new Button.ButtonClickedEvent();

        Salvar.onClick.AddListener(() => SalvarXD());
    //    Opcoes.onClick.AddListener(() => OpcoesXD(true));
        Sair.onClick.AddListener(() => SairXD());
    //    VoltarOp.onClick.AddListener(() => OpcoesXD(false));
        #endregion
    }
    #endregion
    #region Update
    void Update () {
       Secundario();
	}
    #endregion
    #region Menu Esc
    void Secundario()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !secundario.activeInHierarchy)
        {
            secundario.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && secundario.activeInHierarchy)
        {
            secundario.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    #endregion
    #region Resumo
    private void SalvarXD()
    {
        secundario.SetActive(false);
        Time.timeScale = 1f;
    }
    #endregion
    #region OpçõesXD
    //private void OpcoesXD(bool ativarOP)
    //{
    //    Salvar.gameObject.SetActive(!ativarOP);
    //    Opcoes.gameObject.SetActive(!ativarOP);
    //    Sair.gameObject.SetActive(!ativarOP);
    //    Musica.gameObject.SetActive(ativarOP);
    //    Efeitos.gameObject.SetActive(ativarOP);
    //    VoltarOp.gameObject.SetActive(ativarOP);
    //    SalvarOp.gameObject.SetActive(ativarOP);
    //    Controles.gameObject.SetActive(ativarOP);
    //}
    #endregion
    #region Sair/Menu Inicial
    private void SairXD()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    #endregion
}
