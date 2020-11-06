using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrInventario : MonoBehaviour {

    public int inventario;
    private Animator anim;
    public bool casa;

	void Start () {
        anim = GetComponent<Animator>();
        if (casa)
        {
            inventario = PlayerPrefs.GetInt("inventario");
            anim.SetInteger("conteudo", inventario);
        }
    }
	
	void Update () {
        inventario = PlayerPrefs.GetInt("inventario");
        anim.SetInteger("conteudo", inventario);
    }
}
