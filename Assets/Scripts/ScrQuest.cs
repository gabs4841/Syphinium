using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrQuest : MonoBehaviour {

    public GameObject[] questativa;
    public bool[] quest;
    public int ativa, mapa;

    void Awake () {
        ativa = PlayerPrefs.GetInt("quest");
        mapa = PlayerPrefs.GetInt("mapa");
    }
	
	void Update () {

        switch (ativa)
        {
            #region Caso 0
            case 0: quest[0] = true;
                    quest[1] = false;
                    quest[2] = false;
                    quest[3] = false;
                    quest[4] = false;
                    quest[5] = false;
                    quest[6] = false;
                    quest[7] = false;
                    quest[8] = false;
                    quest[9] = false;
                break;
            #endregion
            #region Caso 1
            case 1:
                quest[0] = false;
                quest[1] = true;
                quest[2] = false;
                quest[3] = false;
                quest[4] = false;
                quest[5] = false;
                quest[6] = false;
                quest[7] = false;
                quest[8] = false;
                quest[9] = false;
                break;
            #endregion
            #region Caso 2
            case 2:
                quest[0] = false;
                quest[1] = false;
                quest[2] = true;
                quest[3] = false;
                quest[4] = false;
                quest[5] = false;
                quest[6] = false;
                quest[7] = false;
                quest[8] = false;
                quest[9] = false;
                break;
            #endregion
            #region Caso 3
            case 3:
                quest[0] = false;
                quest[1] = false;
                quest[2] = false;
                quest[3] = true;
                quest[4] = false;
                quest[5] = false;
                quest[6] = false;
                quest[7] = false;
                quest[8] = false;
                quest[9] = false;
                break;
            #endregion
            #region Caso 4
            case 4:
                quest[0] = false;
                quest[1] = false;
                quest[2] = false;
                quest[3] = false;
                quest[4] = true;
                quest[5] = false;
                quest[6] = false;
                quest[7] = false;
                quest[8] = false;
                quest[9] = false;
                mapa = 1;
                break;
            #endregion
            #region Caso 5
            case 5:
                quest[0] = false;
                quest[1] = false;
                quest[2] = false;
                quest[3] = false;
                quest[4] = false;
                quest[5] = true;
                quest[6] = false;
                quest[7] = false;
                quest[8] = false;
                quest[9] = false;
                break;
            #endregion
            #region Caso 6
            case 6:
                quest[0] = false;
                quest[1] = false;
                quest[2] = false;
                quest[3] = false;
                quest[4] = false;
                quest[5] = false;
                quest[6] = true;
                quest[7] = false;
                quest[8] = false;
                quest[9] = false;
                break;
            #endregion
            #region Caso 7
            case 7:
                quest[0] = false;
                quest[1] = false;
                quest[2] = false;
                quest[3] = false;
                quest[4] = false;
                quest[5] = false;
                quest[6] = false;
                quest[7] = true;
                quest[8] = false;
                quest[9] = false;
                break;
            #endregion
            #region Caso 8
            case 8:
                quest[0] = false;
                quest[1] = false;
                quest[2] = false;
                quest[3] = false;
                quest[4] = false;
                quest[5] = false;
                quest[6] = false;
                quest[7] = false;
                quest[8] = true;
                quest[9] = false;
                break;
            #endregion
            #region Caso 9
            case 9:
                quest[0] = false;
                quest[1] = false;
                quest[2] = false;
                quest[3] = false;
                quest[4] = false;
                quest[5] = false;
                quest[6] = false;
                quest[7] = false;
                quest[8] = false;
                quest[9] = true;
                break;
                #endregion
        }


        #region Quest 0
        if (quest[0])
        {
            questativa[0].SetActive(true);
        }

        if (!quest[0])
        {
            questativa[0].SetActive(false);
        }
        #endregion
        #region Quest 1
        if (quest[1])
        {
            questativa[1].SetActive(true);
        }
       
        if (!quest[1])
        {
            questativa[1].SetActive(false);
        }
        #endregion
        #region Quest 2
        if (quest[2])
        {
            questativa[2].SetActive(true);
        }

        if (!quest[2])
        {
            questativa[2].SetActive(false);
        }

        #endregion
        #region Quest 3
        if (quest[3])
        {
            questativa[3].SetActive(true);
        }

        if (!quest[3])
        {
            questativa[3].SetActive(false);
        }
        #endregion
        #region Quest 4
        if (quest[4])
        {
            questativa[4].SetActive(true);
        }

        if (!quest[4])
        {
            questativa[4].SetActive(false);
        }

        #endregion
        #region Quest 5
        if (quest[5])
        {
            questativa[5].SetActive(true);
        }

        if (!quest[5])
        {
            questativa[5].SetActive(false);
        }
        #endregion
        #region Quest 6
        if (quest[6])
        {
            questativa[6].SetActive(true);
        }

        if (!quest[6])
        {
            questativa[6].SetActive(false);
        }
        #endregion
        #region Quest 7
        if (quest[7])
        {
            questativa[7].SetActive(true);
        }

        if (!quest[7])
        {
            questativa[7].SetActive(false);
        }
        #endregion
        #region Quest 8
        if (quest[8])
        {
            questativa[8].SetActive(true);
        }

        if (!quest[8])
        {
            questativa[8].SetActive(false);
        }
        #endregion
        #region Quest 9
        if (quest[9])
        {
            questativa[9].SetActive(true);
        }

        if (!quest[9])
        {
            questativa[9].SetActive(false);
        }
        #endregion

        PlayerPrefs.SetInt("mapa", mapa);
        PlayerPrefs.SetInt("quest", ativa);
    }
}
