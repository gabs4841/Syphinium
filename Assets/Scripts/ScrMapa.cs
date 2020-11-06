using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrMapa : MonoBehaviour {

    public Button KozaCidade, Floresta, KozaCasa;
    public ScrVouPara tp;
    public ScrLoading loading;
    public Animator anim;
    public int mapa;
    public bool Aberto;

    void Start() {
        mapa = PlayerPrefs.GetInt("mapa");
        anim = Floresta.GetComponent<Animator>();
        Floresta.onClick = new Button.ButtonClickedEvent();
    }

    void Update() {
        if (mapa == 1)
        {
            Aberto = true;
            anim.SetBool("CadeadoFloresta", true);
        }

        if (Aberto)
        {
            Floresta.onClick.AddListener(() => TPFloresta());
        }
    }

    public void TPKozaCidade() {
        tp.ParaOndeVou = "koza";
    }

    public void TPKozaCasa()
    {
        tp.ParaOndeVou = "saida";
    }

    public void TPFloresta()
    {
        tp.ParaOndeVou = "floresta";
    }

}
