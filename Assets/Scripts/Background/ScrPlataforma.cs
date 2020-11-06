using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlataforma : MonoBehaviour {

    #region Variavel
    private PlatformEffector2D efeito;
    public int continuar = 3;
    #endregion
    #region Awake
    void Awake (){
        efeito = GetComponent<PlatformEffector2D>();
        PlayerPrefs.SetInt("continue", continuar);
	}
    #endregion
    #region Update
    void Update () {
        #region Se Pressionar Para Baixo
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            efeito.rotationalOffset = 180f;
            Invoke("volta", 0.4f);
        }
        #endregion
        #region Se Pressionar Espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            volta();
        }
        #endregion
    }
    #endregion
    #region Volta
    void volta(){
        efeito.rotationalOffset = 0f;
    }
    #endregion
}
