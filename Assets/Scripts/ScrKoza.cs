using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrKoza : MonoBehaviour {

    public GameObject estatua, estatua2, estatua3, estatua4;
    public GameObject falaentregador, esc;
    public GameObject[] falanpc;
    public bool estatuabool, estatua2bool, estatua3bool, estatua4bool;
    public bool estatuafecha, estatua2fecha, estatua3fecha, estatua4fecha;
    public bool[] npc;
    public bool entregador;
    private int valorinventario = 0;
    public ScrQuest quest;
    public int continuar = 3;

    public GameObject inventario;
    private Animator caixa;

    void Start() {
        caixa = inventario.GetComponent<Animator>();
        PlayerPrefs.SetInt("continue", continuar);
    }

    void Update()
    {
        #region Placas
        #region Estatua
        if (estatuabool && Input.GetKeyDown(KeyCode.E))
        {
            if (estatua.activeInHierarchy)
            {
                estatua.SetActive(false);
                estatuafecha = false;
            }
            else if (!estatua.activeInHierarchy)
            {
                estatua.SetActive(true);
                estatuafecha = true;
            }
        }
        
        if (!estatuabool)
        {
            estatua.SetActive(false);
            estatuafecha = false;
        }

        if (estatuafecha && Input.GetKeyDown(KeyCode.Escape)) 
        {
            esc.SetActive(false);
            Time.timeScale = 1f;
            estatua.SetActive(false);
            estatuafecha = false;
        }
        #endregion
        #region Estatua2
        if (estatua2bool && Input.GetKeyDown(KeyCode.E))
        {
            if (estatua2.activeInHierarchy)
            {
                estatua2.SetActive(false);
                estatua2fecha = false;
            }
            else if (!estatua2.activeInHierarchy)
            {
                estatua2.SetActive(true);
                estatua2fecha = true;
            }
        }

        if (!estatua2bool)
        {
            estatua2.SetActive(false);
            estatua2fecha = false;
        }

        if (estatua2fecha && Input.GetKeyDown(KeyCode.Escape))
        {
            esc.SetActive(false);
            Time.timeScale = 1f;
            estatua2.SetActive(false);
            estatua2fecha = false;
        }
        #endregion
        #region Estatua3
        if (estatua3bool && Input.GetKeyDown(KeyCode.E))
        {
            if (estatua3.activeInHierarchy)
            {
                estatua3.SetActive(false);
                estatua3fecha = false;
            }
            else if (!estatua3.activeInHierarchy)
            {
                estatua3.SetActive(true);
                estatua3fecha = true;
            }
        }

        if (!estatua3bool)
        {
            estatua3.SetActive(false);
            estatua3fecha = false;
        }

        if (estatua3fecha && Input.GetKeyDown(KeyCode.Escape))
        {
            esc.SetActive(false);
            Time.timeScale = 1f;
            estatua3.SetActive(false);
            estatua3fecha = false;
        }
        #endregion
        #region Estatua4
        if (estatua4bool && Input.GetKeyDown(KeyCode.E))
        {
            if (estatua4.activeInHierarchy)
            {
                estatua4.SetActive(false);
                estatua4fecha = false;
            }
            else if (!estatua4.activeInHierarchy)
            {
                estatua4.SetActive(true);
                estatua4fecha = true;
            }
        }

        if (!estatua4bool)
        {
            estatua4.SetActive(false);
            estatua4fecha = false;
        }

        if (estatua4fecha && Input.GetKeyDown(KeyCode.Escape))
        {
            esc.SetActive(false);
            Time.timeScale = 1f;
            estatua4.SetActive(false);
            estatua4fecha = false;
        }
        #endregion

        #endregion

        #region NPC

        if (npc[0] && Input.GetKeyDown(KeyCode.E))
        {
            falanpc[0].SetActive(true);
        }

        if (!npc[0])
        {
            falanpc[0].SetActive(false);
        }

        if (npc[1] && Input.GetKeyDown(KeyCode.E))
        {
            falanpc[1].SetActive(true);
        }

        if (!npc[1])
        {
            falanpc[1].SetActive(false);
        }

        if (npc[2] && Input.GetKeyDown(KeyCode.E))
        {
            falanpc[2].SetActive(true);
        }

        if (!npc[2])
        {
            falanpc[2].SetActive(false);
        }

        if (npc[3] && Input.GetKeyDown(KeyCode.E))
        {
            falanpc[3].SetActive(true);
        }

        if (!npc[3])
        {
            falanpc[3].SetActive(false);
        }

        if (npc[4] && Input.GetKeyDown(KeyCode.E))
        {
            falanpc[4].SetActive(true);
        }

        if (!npc[4])
        {
            falanpc[4].SetActive(false);
        }

        if (npc[5] && Input.GetKeyDown(KeyCode.E))
        {
            falanpc[5].SetActive(true);
        }

        if (!npc[5])
        {
            falanpc[5].SetActive(false);
        }

        if (npc[6] && Input.GetKeyDown(KeyCode.E))
        {
            falanpc[6].SetActive(true);
        }

        if (!npc[6])
        {
            falanpc[6].SetActive(false);
        }

        if (npc[7] && Input.GetKeyDown(KeyCode.E))
        {
            falanpc[7].SetActive(true);
        }

        if (!npc[7])
        {
            falanpc[7].SetActive(false);
        }

        if (npc[8] && Input.GetKeyDown(KeyCode.E))
        {
            falanpc[8].SetActive(true);
        }

        if (!npc[8])
        {
            falanpc[8].SetActive(false);
        }

        if (npc[9] && Input.GetKeyDown(KeyCode.E))
        {
            falanpc[9].SetActive(true);
        }

        if (!npc[9])
        {
            falanpc[9].SetActive(false);
        }
        #endregion

        if (entregador && Input.GetKeyDown(KeyCode.E))
        {
            falaentregador.SetActive(true);
            quest.ativa = 2;
            caixa.SetInteger("conteudo", valorinventario);
            PlayerPrefs.SetInt("inventario", valorinventario);
        }

        if (!entregador)
        {
            falaentregador.SetActive(false);
        }
    }
}
