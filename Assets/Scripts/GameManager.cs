﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }

    public GridController gridController;
    public ATHManager athManager;
    public RessourcesGain ressources;

    public int[] goalsRessources;


    // Use this for initialization
    void Awake () {
		
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}

    public void PlaceBuilding()
    {
        if(athManager.cell != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Cell")
                {
                    string objName = athManager.cell.name.Replace("(Clone)", "");
                    if(hit.collider.GetComponent<Cell>().type == CellType.empty)
                    {
                        switch (objName)
                        {
                            case "CommerceATH":
                                gridController.PlaceCommerceInCell(hit.collider.GetComponent<Cell>());
                                break;
                            case "ResidenceATH":
                                gridController.PlaceResidenceInCell(hit.collider.GetComponent<Cell>());
                                break;
                            case "IndustrieATH":
                                gridController.PlaceIndustrieInCell(hit.collider.GetComponent<Cell>());
                                break;
                            case "ParcATH":
                                gridController.PlaceParcInCell(hit.collider.GetComponent<Cell>());
                                break;
                            default:
                                break;
                        }
                    }   
                }
            }
        }
       
    }
	
	// Update is called once per frame
	void Update () {
        UpdateRessource();
    }

    void UpdateRessource()
    {
        RessourcesGain ressourcesGrid = gridController.GetAllRessourcesOfGrid();
        athManager.UpdateRessources(ressourcesGrid.energy, ressourcesGrid.money, ressourcesGrid.population, ressourcesGrid.pollution);
    }

}
