using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Cell : MonoBehaviour {

    // Le type de la cellule
    public CellType type;

    // La liste des gains/pertes de ressources généré par la cellule
    public RessourcesGain ressources;

    // La taille de la cellule
    public int cellSize;

    // La position de la cellule dans la grille
    private int m_posX;
    private int m_posY;

    public GameObject[] prefabsCell;

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
        if(type != CellType.empty && type != CellType.mountain)
        {
            gameObject.AddComponent<CellBehaviour>();
        }
        
        switch (type)
        {
            case CellType.residence:
                Instantiate(prefabsCell[0], transform);
                break;
            case CellType.industrie:
                Instantiate(prefabsCell[1], transform);
                break;
            case CellType.commerce:
                Instantiate(prefabsCell[2], transform);
                break;
            case CellType.parc:
                Instantiate(prefabsCell[3], transform);
                break;
            case CellType.mountain:
                Instantiate(prefabsCell[4], transform);
                break;
            default:
                break;
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
