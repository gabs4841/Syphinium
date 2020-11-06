using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBola : MonoBehaviour {
    public int continuar = 2;

    private void Awake()
    {
        PlayerPrefs.SetInt("continue", continuar);
    }
    void Start () {
        
	}
	
	void Update () {
		
	}
}
