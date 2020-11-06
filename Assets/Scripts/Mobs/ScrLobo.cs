using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrLobo : MonoBehaviour {

    public GameObject coiso;
    public float Velocidade = 0f;
    public Transform pontofinal, spawnpoint;
    public int contador = 0;
    public bool RUNBITCHRUN = false, lobo;
    public int continuar = 4;
    private Animator anim;
    public ScrQuest quest;

    private void Awake()
    {
        PlayerPrefs.SetInt("continue", continuar);
    }

    private void Start()
    {
        if (lobo)
        {
            quest.ativa = 5;
            Invoke("mudaquest", 6f);
        }
        else
        {
            continuar = 5;
            PlayerPrefs.SetInt("continue", continuar);
            quest.ativa = 8;
        }
    }

    void Update()
    {
        if (RUNBITCHRUN)
        {
            coiso.transform.position = Vector3.MoveTowards(coiso.transform.position, pontofinal.position, Velocidade * Time.deltaTime);

            if (coiso.transform.position == pontofinal.position)
            {
                if (lobo)
                {
                    spawn();
                }
                else
                {
                    anim = GetComponent<Animator>();
                    anim.SetBool("VamoMorrer", true);
                    Invoke("spawn",0.3f);
                }
            }
        }
    }

    public void spawn()
    {
        coiso.transform.position = spawnpoint.position;
        RUNBITCHRUN = false;
        if (!lobo)
        {
            anim.SetBool("VamoMorrer", false);
        }
    }

    public void mudaquest()
    {
        quest.ativa = 6;
    }
}
