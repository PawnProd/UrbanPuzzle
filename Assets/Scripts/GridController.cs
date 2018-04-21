using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour {

    // Taille de la grille
    public int gridSize;

    // Le prefab de la cellule
    public GameObject cellPrefab;

    // La position du premier block 
    public Transform startPosition;

    // La grille contenant les cellules
    public Cell[,] grid = new Cell[4,4];

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
}
