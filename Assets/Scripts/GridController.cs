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
    public static Cell[,] grid;

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
                posY += 2;
            }

            posX += 2;
        }
    }

    public void Clear()
    {
        for (int x = 0; x < gridSize; ++x) // HORIZONTAL
        {
            for (int y = 0; y < gridSize; ++y) // VERTICAL
            {
                DestroyImmediate(grid[x, y]);
            }
        }
    }
}
