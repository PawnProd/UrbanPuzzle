using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class GridController : MonoBehaviour {

    // Taille de la grille
    public int gridSize;

    // Le prefab de la cellule
    public GameObject cellPrefab;

    // La position du premier block 
    public Transform startPosition;

    // La grille contenant les cellules
    public Cell[,] grid;

    public List<Temp> temp;

    private Vector3 m_centerGrid;

    private MemoryStream ms;

    private void Awake()
    {
        m_centerGrid = GetCenter();
        CopyToGrid();
    }

    public void CopyToTemp()
    {
        temp = new List<Temp>();
        for (int x = 0; x < gridSize; ++x) // HORIZONTAL
        {
            temp.Add(new Temp());
            for (int y = 0; y < gridSize; ++y) // VERTICAL
            {
                temp[x].cellList.Add(grid[x, y]);
            }
        }
    }

    public void CopyToGrid()
    {
        grid = new Cell[gridSize, gridSize];
        for (int x = 0; x < gridSize; ++x) // HORIZONTAL
        {
            for (int y = 0; y < gridSize; ++y) // VERTICAL
            {
                print("Temp " + temp[x].cellList[y].GetPosX());
                grid[x, y] = temp[x].cellList[y];
                print("Grid " + grid[x, y].GetPosX());
            }
        }
    }

    public void GenerateGrid()
    {
        // Initialisation de la grille
        grid = new Cell[gridSize, gridSize];

        // Initialisation de la position de la cellule
        Vector3 cellPos = Vector3.zero;
        int posX = 0;
        int posY;

        for(int x = 0; x < gridSize; ++x) // HORIZONTAL
        {
            cellPos.x = posX;
            posY = 0;
            for (int y = 0; y < gridSize; ++y) // VERTICAL
            {
                cellPos.z = posY;
                grid[x, y] = Instantiate(cellPrefab, cellPos, Quaternion.identity, transform).GetComponent<Cell>();
                grid[x, y].SetPos(x, y);
                grid[x, y].type = CellType.empty;
                grid[x, y].gameObject.tag = "Cell";
                posY += 2;
            }

            posX += 2;
        }

        CopyToTemp();
    }

    public void Clear()
    {
        print("Grid" + grid);
        for (int x = 0; x < gridSize; ++x) // HORIZONTAL
        {
            for (int y = 0; y < gridSize; ++y) // VERTICAL
            {
                DestroyImmediate(grid[x, y].gameObject);
            }
        }
    }

    public void CheckGrid()
    {
        for (int x = 0; x < gridSize; ++x) // HORIZONTAL
        {
            for (int y = 0; y < gridSize; ++y) // VERTICAL
            {
                Debug.Log("X = " + x + " Y = " + y + " grid = " + grid[x, y]);
                if(grid[x,y].GetComponent<CellBehaviour>() != null)
                    if(!grid[x,y].GetComponent<CellBehaviour>().CheckBehavior())
                        throw new System.Exception("La condition de la cellule[" + x + "," + y + "] n'est pas remplit");
            }
        }
    }

    public Vector3 GetCenter()
    {
        var rends = GetComponentsInChildren<MeshRenderer>();

        if (rends.Length == 0)
        {
            return transform.position;
        }
        else
        {
            var b = rends[0].bounds;
            for (int i = 1; i < rends.Length; ++i)
            {
                b.Encapsulate(rends[i].bounds);
            }
            return b.center;
        }
        
    }

    public void PlaceCommerceInCell(Cell cell)
    {
        cell.type = CellType.commerce;
        cell.GenerateCellInGame();
    }

    public void PlaceResidenceInCell(Cell cell)
    {
        cell.type = CellType.residence;
        cell.GenerateCellInGame();
    }

    public void PlaceIndustrieInCell(Cell cell)
    {
        cell.type = CellType.industrie;
        cell.GenerateCellInGame();
    }

    public void PlaceParcInCell(Cell cell)
    {
        cell.type = CellType.parc;
        cell.GenerateCellInGame();
    }

    public void Rotate(float yawValue)
    {
        print(m_centerGrid);
         transform.RotateAround(m_centerGrid, Vector3.up, yawValue);
    }
}

[System.Serializable]
public class Temp
{
    public List<Cell> cellList;

    public Temp()
    {
        cellList = new List<Cell>();
    }
}
