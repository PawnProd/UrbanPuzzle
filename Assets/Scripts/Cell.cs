using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Cell : MonoBehaviour {

    // Le type de la cellule
    public CellType type;

    // La taille de la cellule
    public int cellSize;

    public GameObject[] prefabsCell;

    public BuildingController building;

    // La position de la cellule dans la grille
    public int m_posX;
    public int m_posY;

    public void SetPos(int x, int y)
    {
        m_posX = x;
        m_posY = y;
    }

    public int GetPosX()
    {
        return m_posX;
    }

    public int GetPosY()
    {
        return m_posY;
    }

    public void GenerateCell()
    {
        if (type != CellType.empty && type != CellType.mountain && gameObject.GetComponent<CellBehaviour>() == null)
        {
            gameObject.AddComponent<CellBehaviour>();
        }

        switch (type)
        {
            case CellType.residence:
                building = Instantiate(prefabsCell[0], transform).GetComponent<BuildingController>();
                break;
            case CellType.industrie:
                building = Instantiate(prefabsCell[1], transform).GetComponent<BuildingController>();
                break;
            case CellType.commerce:
                building = Instantiate(prefabsCell[2], transform).GetComponent<BuildingController>();
                break;
            case CellType.parc:
                building = Instantiate(prefabsCell[3], transform).GetComponent<BuildingController>();
                break;
            case CellType.mountain:
                building = Instantiate(prefabsCell[4], transform).GetComponent<BuildingController>();
                break;
            default:
                break;
        }
    }

    public void GenerateCellInGame()
    {
        if (type != CellType.empty && type != CellType.mountain && gameObject.GetComponent<CellBehaviour>() == null)
        {
            gameObject.AddComponent<CellBehaviour>();
        }

        switch (type)
        {
            case CellType.residence:
                building = Instantiate(prefabsCell[0], transform).GetComponent<BuildingController>();
                break;
            case CellType.industrie:
                building = Instantiate(prefabsCell[1], transform).GetComponent<BuildingController>();
                break;
            case CellType.commerce:
                building = Instantiate(prefabsCell[2], transform).GetComponent<BuildingController>();
                break;
            case CellType.parc:
                building = Instantiate(prefabsCell[3], transform).GetComponent<BuildingController>();
                break;
            case CellType.mountain:
                building = Instantiate(prefabsCell[4], transform).GetComponent<BuildingController>();
                break;
            default:
                break;
        }

        if (!gameObject.GetComponent<CellBehaviour>().CheckBehavior())
        {
            Destroy(building.gameObject);
            type = CellType.empty;
            Destroy(GetComponent<CellBehaviour>());
            GameManager.Instance.refusSource.Play();

        }
        else
        {
            Destroy(GameManager.Instance.athManager.cell.gameObject);
            GameManager.Instance.athManager.ResetCursor();
        }
    }
}

public enum CellType
{
    residence,
    industrie,
    commerce,
    parc,
    empty,
    mountain
}

[System.Serializable]
public struct RessourcesGain
{
    public int money;
    public int energy;
    public int population;
    public int pollution;
}
