using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrTatu : MonoBehaviour {

    public GameObject coiso;
    public float Velocidade = 0f,anguloRotacao = 360, direcao = 1;
    public Transform[] paraondeir;
    public int contador = 0;

	
	void Update () {
        coiso.transform.position = Vector3.MoveTowards(coiso.transform.position, paraondeir[contador].position, Velocidade * Time.deltaTime);

        Quaternion rotacao = transform.rotation;
        float z = rotacao.eulerAngles.z;

        z += direcao * anguloRotacao * Time.deltaTime;
        rotacao = Quaternion.Euler(0, 0, z);
        transform.rotation = rotacao;

        if (coiso.transform.position == paraondeir[contador].position)
        {
            contador++;
            coiso.transform.localScale = new Vector3(coiso.transform.localScale.x * -1, coiso.transform.localScale.y, coiso.transform.localScale.z);
            direcao = -direcao;
            if (contador == 2)
            {
                contador = 0;
            }
        }
	}
}
