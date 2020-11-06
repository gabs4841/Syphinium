using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrMinhoca : MonoBehaviour {

    public Animator animnhoca;
    public Rigidbody2D corpo;
    public float pulo;
    public bool minhoca;

	void Start () {
        animnhoca = GetComponent<Animator>();
	}
	
	void Update () {
        if (minhoca && Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("pula");
            CancelInvoke("acorda");
            CancelInvoke("dorme");
            Invoke("acorda", 0.3f);
            Invoke("dorme", 0.5f);
            Invoke("pula", 0.4f);
        }
	}

    public void acorda()
    {
        animnhoca.SetBool("Dormindo", false);
    }

    public void dorme()
    {
        animnhoca.SetBool("Dormindo", true);
    }

    public void pula()
    {
        corpo.AddForce(new Vector2(0f, pulo), ForceMode2D.Impulse);
    }
}
