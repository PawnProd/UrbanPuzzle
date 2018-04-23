using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoManager : MonoBehaviour {

    public string[] allTextTuto;

    // Phase 1
    public GameObject ressourcesATH;

    // Phase 2
    public GameObject goalATH;

    // Phase 3
    public GameObject constructionATH;

    // Phase 4
    public GameObject cellPhase4;
    public GameObject overlayEffect;

    // Phase 5
    public GameObject industryATH;

    // Phase 6
    public GameObject parc;

    // End Phase
    public GameObject endTuto;

    public Text tutoText;

    private int indexTuto;

	// Use this for initialization
	void Start () {
        indexTuto = 0;
        NextPhase();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextPhase()
    {
        
        if(indexTuto == 1)
        {
            ressourcesATH.SetActive(true);
        }
        else if (indexTuto == 2)
        {
            goalATH.SetActive(true);
        }
        else if (indexTuto == 3)
        {
            constructionATH.SetActive(true);
        }
        else if (indexTuto == 4)
        {
            cellPhase4.SetActive(true);
            overlayEffect.SetActive(true);
        }
        else if (indexTuto == 5)
        {
            industryATH.SetActive(true);
        }
        else if (indexTuto == 6)
        {
            parc.SetActive(true);
            industryATH.SetActive(false);
            overlayEffect.SetActive(false);
        }
        else if (indexTuto == 8)
        {
            endTuto.SetActive(true);
        }

        if(indexTuto < 8)
        {
            tutoText.text = allTextTuto[indexTuto];
            ++indexTuto;
        }
      
    }


}
