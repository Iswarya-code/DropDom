using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int rows = 9;          // Number of rows in the grid
    public int columns = 9;       // Number of columns in the grid
    public GameObject tilePrefab; // Prefab for the grid tiles (default 2D sprite)
    public float spacing = 0.1f;  // Space between tiles

    private GameObject[,] gridArray;

    void Start()
    {
        CreateGrid();
    }

    // Creates the grid using the tilePrefab
    void CreateGrid()
    {
        gridArray = new GameObject[rows, columns];  // Create a grid array

        // Calculate the starting position of the grid (centered)
        Vector2 startPos = new Vector2(-columns / 2f + 0.5f, -rows / 2f + 0.5f);

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < columns; x++)
            {
                Vector2 spawnPos = new Vector2(x, y) + startPos;
                GameObject tile = Instantiate(tilePrefab, spawnPos, Quaternion.identity);
                tile.transform.localScale = Vector3.one * (1 - spacing);
                tile.transform.SetParent(this.transform); // Parent under GridManager
                gridArray[y, x] = tile; // Store reference in the array
            }
        }
    }
}
