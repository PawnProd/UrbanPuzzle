using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResidenceBehavior : MonoBehaviour, ICellBehavior {

    public List<Conditions> cellConditions;

    private Cell cell;
    private Cell[,] grid;

    private void Start()
    {
        cell = GetComponent<Cell>();
        grid = GridController.grid;
    }

    public bool CheckBehavior()
    {

        return true;
    }
}

[System.Serializable]
public class Conditions
{
    public CellType key;
    public bool value;
}

