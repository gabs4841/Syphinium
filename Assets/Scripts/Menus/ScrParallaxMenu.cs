using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrParallaxMenu : MonoBehaviour {

    public GameObject coiso;
    public float Velocidade = 0f;
    public Transform[] paraondeir;
    public int contador = 0;

    void Update () {
        coiso.transform.position = Vector3.MoveTowards(coiso.transform.position, paraondeir[contador].position, Velocidade * Time.deltaTime);

        if (coiso.transform.position == paraondeir[contador].position)
        {
            contador++;
            coiso.transform.localScale = new Vector3(coiso.transform.localScale.x * -1, coiso.transform.localScale.y, coiso.transform.localScale.z);
            if (contador == 2)
            {
                contador = 0;
            }
        }
	}
}
