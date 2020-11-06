using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrCameraMan : MonoBehaviour {
    
    #region Variaveis
    #region Tp
    public ScrVouPara jogador;
    public GameObject corpo;
    #endregion
    #region Fade
    public Image preto;
    public Animator fade;
    #endregion
    #region Cama
    public ScrPlayer player;
    public EdgeCollider2D cama;
    #endregion
    #endregion

    void Start () {
	}
	
	void Update () {
        
        if (!player.nochao)
        {
            Invoke("Vaicama", 0.3f);
        }
        else
        {
            cama.isTrigger = true;
        }

        if (jogador.ParaOndeVou == "sotao"){
            StartCoroutine("Fading");
            if (preto.color.a == 1){
                this.transform.position = new Vector3(0f, 20f, -10f);
                corpo.transform.position = new Vector3(1f, 17f, -1f);
                jogador.ParaOndeVou = "num sei";
            }
        }

        else if (jogador.ParaOndeVou == "entrada"){
            StartCoroutine("Fading");
            if (preto.color.a == 1){
                this.transform.position = new Vector3(0f, 0f, -10f);
                corpo.transform.position = new Vector3(3f, -3f, -1f);
                jogador.ParaOndeVou = "num sei";
            }
        }

        else if (jogador.ParaOndeVou == "casa")
        {
            StartCoroutine("Fading");
            if (preto.color.a == 1)
            {
                SceneManager.LoadScene("Casa");
                jogador.ParaOndeVou = "num sei";
            }
        }

        else if (jogador.ParaOndeVou == "porao"){
            StartCoroutine("Fading");
            if (preto.color.a == 1){
                this.transform.position = new Vector3(0f, -21f, -10f);
                corpo.transform.position = new Vector3(2f, -24f, -1f);
                jogador.ParaOndeVou = "num sei";
            }
        }

        else if (jogador.ParaOndeVou == "cozinha"){
            StartCoroutine("Fading");
            if (preto.color.a == 1){
                this.transform.position = new Vector3(48f, 20f, -10f);
                corpo.transform.position = new Vector3(47f, 17f, -1f);
                jogador.ParaOndeVou = "num sei";
            }
        }

        else if (jogador.ParaOndeVou == "saida"){
            StartCoroutine("Fading");
            if (preto.color.a == 1){
                SceneManager.LoadScene("HainuArvore");
                jogador.ParaOndeVou = "num sei";
            }
        }

        else if (jogador.ParaOndeVou == "koza")
        {
            StartCoroutine("Fading");
            if (preto.color.a == 1) 
            {
                SceneManager.LoadScene("Koza");
                jogador.ParaOndeVou = "num sei";
            }
        }

        else if (jogador.ParaOndeVou == "floresta")
        {
            StartCoroutine("Fading");
            if (preto.color.a == 1)
            {
                SceneManager.LoadScene("Floresta");
                jogador.ParaOndeVou = "num sei";
            }
        }

        else if (jogador.ParaOndeVou == "caverna")
        {
            StartCoroutine("Fading");
            if (preto.color.a == 1)
            {
                SceneManager.LoadScene("Caverna");
                jogador.ParaOndeVou = "num sei";
            }
        }

        else if (jogador.ParaOndeVou == "volta")
        {
            StartCoroutine("Fading");
            if (preto.color.a == 1)
            {
                SceneManager.LoadScene("CasaParte2");
                jogador.ParaOndeVou = "num sei";
            }
        }
    }

     IEnumerator Fading(){
        fade.SetBool("FadeIN", true);
        yield return new WaitUntil(() => preto.color.a == 1);
        fade.SetBool("FadeIN", false);
    }

    void Vaicama()
    {
        cama.isTrigger = false;
    }
}
