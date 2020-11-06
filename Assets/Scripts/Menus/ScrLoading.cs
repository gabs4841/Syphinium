using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrLoading : MonoBehaviour
{
    public GameObject telaCarregamento;
    public Slider barraProgresso;
    public Text lblProgresso;
    public int inventario, vida = 7, ativa = -1, mapa = 0;

    public void CarregarCena(int indiceCena)
    {
        StartCoroutine(carregando(indiceCena));
        if(indiceCena == 1 || indiceCena == 7)
        {
        PlayerPrefs.SetInt("inventario", inventario);
        PlayerPrefs.SetInt("quest", ativa);
        PlayerPrefs.SetInt("mapa", mapa);
        PlayerPrefs.SetInt("vidaatual", vida);
        }
    }

    IEnumerator carregando(int indiceCena)
    {
        AsyncOperation operacao = SceneManager.LoadSceneAsync(indiceCena);
        telaCarregamento.SetActive(true);

        while (!operacao.isDone)
        {
            float progresso = Mathf.Round(operacao.progress);
            if (progresso == .9f) { progresso = 1f; }
            barraProgresso.value = progresso;
            lblProgresso.text = (progresso * 100f) + "%";
            yield return null;
        }

    }


}