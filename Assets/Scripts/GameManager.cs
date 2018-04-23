using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }

    public GridController gridController;
    public ATHManager athManager;
    public RessourcesGain ressources;

    public AudioSource refusSource;

    public int moneyGoal = 0;
    public int energyGoal = 0;
    public int popGoal = 0;
    public int envirGoal = 0;


    // Use this for initialization
    void Awake () {
		
        if(Instance == null)
        {
            Instance = this;
        }
	}

    public void ReloadLevel()
    {
        MasterGameManager.Instance.ReloadLevel();
    }

    public void NextLevel()
    {
        MasterGameManager.Instance.NextLevel();
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
        if(CheckWin())
        {
            athManager.ShowPanelWin();
        }
    }

    void UpdateRessource()
    {
        RessourcesGain ressourcesGrid = gridController.GetAllRessourcesOfGrid();
        athManager.UpdateRessources(ressourcesGrid.money, ressourcesGrid.energy, ressourcesGrid.population, ressourcesGrid.pollution);
    }

    public bool CheckWin()
    {
        RessourcesGain ressourcesGrid = gridController.GetAllRessourcesOfGrid();

        return (moneyGoal <= ressourcesGrid.money) && (energyGoal <= ressourcesGrid.energy) && (popGoal <= ressourcesGrid.population) && (envirGoal <= ressourcesGrid.pollution);
    }
}
