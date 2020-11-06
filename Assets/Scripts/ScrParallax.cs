using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrParallax : MonoBehaviour {

    public GameObject coiso;
    public float Velocidade;
    public Transform paraondeir, paraondevoltar;
    public bool direita;

    void Start () {
	}
	
	void Update () {
        
        coiso.transform.position = Vector2.MoveTowards(coiso.transform.position, paraondeir.position, Velocidade * Time.deltaTime);

        if (direita)
        {
            if (coiso.transform.position.x >= paraondeir.transform.position.x)
            {
                coiso.transform.position = paraondevoltar.position;
            }
        }
        else
        {
            if (coiso.transform.position.x <= paraondeir.transform.position.x)
            {
                coiso.transform.position = paraondevoltar.position;
            }
        }

    }
}
