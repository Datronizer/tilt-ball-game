using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManagerScript : MonoBehaviour
{
    [SerializeField]
    int gridSize;

    [SerializeField]
    SquareButton squarePrefab;

    // Start is called before the first frame update
    private void Awake()
    {
        InstantiateGridSquares(gridSize);
        // SpawnGlowingSquare();
    }

    //TODO: Re-code this shit. The coordinates are wrong because of the new grid. Make sure it's available for even numbers too. Probably start with 2?
    void InstantiateGridSquares(int gridSize)
    {
        int startingPoint = (gridSize - 1) / 2;
        for (int i = -startingPoint; i < gridSize - startingPoint; i++)
        {
            for (int j = -startingPoint; j < gridSize - startingPoint; j++)
            {
                // Instantiates by columns and parents them
                SquareButton square = Instantiate(this.squarePrefab, new Vector2(i * 3, j * -3), Quaternion.identity, this.transform);
                square.name = $"{i + startingPoint}, {j + startingPoint}";
            }
        }
    }

    //TODO: Code a thing that "selects" a chosen square. It does this by selecting every square and turning off the "it" boolean. Then chooses one at random and flicks that one's "it" on (different method).
    //TODO: Code a thing that flicks a square on.
    
}
