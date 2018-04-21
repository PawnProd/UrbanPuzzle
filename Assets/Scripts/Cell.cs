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

    public void GenerateBehavior()
    {
        switch(type)
        {
            case CellType.residence:
                gameObject.AddComponent<ResidenceBehavior>();
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
