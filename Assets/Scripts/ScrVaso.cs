using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrVaso : MonoBehaviour {

    public int continuar = 7;

    private void Awake()
    {
        PlayerPrefs.SetInt("continue", continuar);
    }

    void Start () {
		
	}
	

	void Update () {
		
	}
}
