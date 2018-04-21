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
    [SerializeField]
    public Cell[,] grid;

    private Vector3 m_centerGrid;

    private void Start()
    {
        m_centerGrid = GetCenter();
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
                posY += 2;
            }

            posX += 2;
        }
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
        cell.GenerateCell();
    }

    public void PlaceResidenceInCell(Cell cell)
    {
        cell.type = CellType.residence;
        cell.GenerateCell();
    }

    public void PlaceIndustrieInCell(Cell cell)
    {
        cell.type = CellType.industrie;
        cell.GenerateCell();
    }

    public void PlaceParcInCell(Cell cell)
    {
        cell.type = CellType.parc;
        cell.GenerateCell();
    }

    public void Rotate(float yawValue)
    {
        print(m_centerGrid);
         transform.RotateAround(m_centerGrid, Vector3.up, yawValue);
    }
}
