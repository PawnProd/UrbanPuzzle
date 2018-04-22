﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ATHManager : MonoBehaviour {

    public GameObject cursor;
    public GameObject[] prefabsCell;

    public Text moneyCount,energyCount,populationCount,environnmentCount;

    [HideInInspector]
    public GameObject cell;

    private void Start()
    {
        ResetCursor();
    }

    public void SelectBatiment(string type)
    {
       
        cursor.transform.position = EventSystem.current.currentSelectedGameObject.transform.position;
        switch (type)
        {
            case "residence":
                cell = Instantiate(prefabsCell[0], Vector3.zero, GameManager.Instance.gridController.transform.rotation);
                break;
            case "industrie":
                cell = Instantiate(prefabsCell[1], Vector3.zero, GameManager.Instance.gridController.transform.rotation);
                break;
            case "commerce":
                cell = Instantiate(prefabsCell[2], Vector3.zero, GameManager.Instance.gridController.transform.rotation);
                break;
            case "parc":
                cell = Instantiate(prefabsCell[3], Vector3.zero, GameManager.Instance.gridController.transform.rotation);
                break;
            default:
                cell = null;
                break;
        }
    }

    public void ResetCursor()
    {
        cursor.transform.position = new Vector3(1000, -3000, 0);
    }

    void Update()
    {
        if(cell != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Cell")
                {
                    cell.transform.position = new Vector3(hit.transform.position.x, 1.5f, hit.transform.position.z);
                }
            }
            else
            {
                cell.transform.position = new Vector3(1000, transform.position.y, 1000);
            }
        }
       
    }

    public void UpdateRessources(int money, int energy, int pop, int envi)
    {
        moneyCount.text = money.ToString();
        energyCount.text = energy.ToString();
        populationCount.text = pop.ToString();
        environnmentCount.text = envi.ToString();

    }
}
