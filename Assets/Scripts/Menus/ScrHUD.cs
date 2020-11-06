using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrHUD : MonoBehaviour {

    public GameObject inventario;
    private Animator caixa;
    private int conteudo;

    private void Awake()
    {
        conteudo = PlayerPrefs.GetInt("");
    }
    void Start () {
        caixa = inventario.GetComponent<Animator>();
        caixa.SetInteger("conteudo", conteudo);
    }
	
	void Update () {
		
	}
}
