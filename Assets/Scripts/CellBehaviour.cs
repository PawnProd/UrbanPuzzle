using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellBehaviour : MonoBehaviour {

    public List<Conditions> cellConditions = new List<Conditions>();

    private void Start()
    {
        Initialise();
    }


    private Cell cell;
    private Cell[,] gridC;

    public void Initialise()
    {
        cell = GetComponent<Cell>();
        gridC = transform.parent.GetComponent<GridController>().grid;
    }

    public bool CheckBehavior()
    {
        if (!cell)
        {
            Initialise();
        }

        List<Cell> allNeightboor = GetAllNeightboor(cell.GetPosX(), cell.GetPosY());

        bool isOk = true;

        foreach (Conditions condition in cellConditions)
        {
            if (condition.value != allNeightboor.Exists(x => x.type == condition.key))
            {
                isOk = false;
            }
        }

        return isOk;
    }

    public void ShowAllNeightboor(Cell[] array)
    {
        foreach(Cell cell in array)
        {
            Debug.Log("Voisin x = " + cell.GetPosX() + " y = " + cell.GetPosY());
        }
    }

    public List<Cell> GetAllNeightboor(int x, int y)
    {
        List<Cell> allNeightboor = new List<Cell>();

        // Gestion des cas particuliers
            if (x == gridC.GetLength(0) - 1 && y == gridC.GetLength(0) - 1) // TOP - RIGHT
            {

                allNeightboor.Add(gridC[x, y - 1]);
                allNeightboor.Add(gridC[x - 1, y - 1]);
                allNeightboor.Add(gridC[x - 1, y]);
            }
            else if (x == gridC.GetLength(0) - 1 && y == 0) // BOTTOM - RIGTH
            {
                allNeightboor.Add(gridC[x, y + 1]);
                allNeightboor.Add(gridC[x - 1, y + 1]);
                allNeightboor.Add(gridC[x - 1, y]);
            }
            else if (x == 0 && y == gridC.GetLength(0) - 1) // TOP - LEFT
            {

                allNeightboor.Add(gridC[x + 1, y]);
                allNeightboor.Add(gridC[x + 1, y - 1]);
                allNeightboor.Add(gridC[x, y - 1]);
            }
            else if (x == 0 && y == 0) // BOTTOM - LEFT
            {
                allNeightboor.Add(gridC[x, y + 1]);
                allNeightboor.Add(gridC[x + 1, y + 1]);
                allNeightboor.Add(gridC[x + 1, y]);
            }
            else if(x == 0)
            {
                allNeightboor.Add(gridC[x, y - 1]);
                allNeightboor.Add(gridC[x + 1, y + 1]);
                allNeightboor.Add(gridC[x, y + 1]);
                allNeightboor.Add(gridC[x + 1, y - 1]);
                allNeightboor.Add(gridC[x + 1, y]);
            }
            else if (y == 0)
            {
                allNeightboor.Add(gridC[x + 1, y]);
                allNeightboor.Add(gridC[x + 1, y + 1]);
                allNeightboor.Add(gridC[x, y + 1]);
                allNeightboor.Add(gridC[x - 1, y]);
                allNeightboor.Add(gridC[x - 1, y + 1]);
            }
            else if (x == gridC.GetLength(0) - 1)
            {
                allNeightboor.Add(gridC[x, y - 1]);
                allNeightboor.Add(gridC[x - 1, y + 1]);
                allNeightboor.Add(gridC[x, y + 1]);
                allNeightboor.Add(gridC[x - 1, y - 1]);
                allNeightboor.Add(gridC[x - 1, y]);
            }
            else if (y == gridC.GetLength(0) - 1)
            {
                allNeightboor.Add(gridC[x + 1, y]);
                allNeightboor.Add(gridC[x + 1, y - 1]);
                allNeightboor.Add(gridC[x, y - 1]);
                allNeightboor.Add(gridC[x - 1, y]);
                allNeightboor.Add(gridC[x - 1, y - 1]);
            }
        else
            {
                allNeightboor.Add(gridC[x + 1, y]);
                allNeightboor.Add(gridC[x + 1, y + 1]);
                allNeightboor.Add(gridC[x, y + 1]);
                allNeightboor.Add(gridC[x - 1, y + 1]);
                allNeightboor.Add(gridC[x - 1, y]);
                allNeightboor.Add(gridC[x - 1, y - 1]);
                allNeightboor.Add(gridC[x, y - 1]);
                allNeightboor.Add(gridC[x + 1, y - 1]);
            }

        return allNeightboor;

    }
}

[System.Serializable]
public class Conditions
{
    public CellType key;
    public bool value;
}
