using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] private SquareTrigger gridSquare;
    [SerializeField] private GlowingButton glowingButton;
    [SerializeField] private int gridSize;

    private GameObject highlightedSquare;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateGridSquares(gridSize);
        SpawnGlowingSquare();
        ShuffleGlowingSquare();
    }

    void InstantiateGridSquares(int gridSize)
    {
        int startingPoint = Mathf.FloorToInt(gridSize / 2);
        for (int i = -startingPoint; i < gridSize - startingPoint; i++)
        {
            for (int j = -startingPoint; j < gridSize - startingPoint; j++)
            {
                // Instantiates by columns and parents them
                SquareTrigger square = Instantiate(gridSquare, new Vector3(i * 3, -0.2f, j * -3), Quaternion.identity, this.transform);
                square.name = $"{i + startingPoint}, {j + startingPoint}";
            }
        }
    }

    void SpawnGlowingSquare()
    {
        int x = GetRandom();
        int y = GetRandom();

        highlightedSquare = GameObject.Find($"{x}, {y}");
        Instantiate(glowingButton, new Vector3(highlightedSquare.transform.position.x, -0.1f, highlightedSquare.transform.position.z), Quaternion.identity, FindObjectOfType<GridController>().transform);
    }

    void ShuffleGlowingSquare()
    {
        GlowingButton glowingSquare = FindObjectOfType<GlowingButton>();

        int x = GetRandom();
        int y = GetRandom();

        // Prevents shuffling back to current square
        if (highlightedSquare.name == $"{x}, {y}")
        {
            ShuffleGlowingSquare();
        }
        else
        {
            highlightedSquare = GameObject.Find($"{x}, {y}");
            glowingSquare.transform.position = new Vector3(highlightedSquare.transform.position.x, -0.1f, highlightedSquare.transform.position.z);
        }
    }

    int GetRandom()
    {
        // Makeshift randomizer
        float fruit = Random.value;
        int pulp = Mathf.RoundToInt(Random.Range(0,9));
        float juice = fruit * Mathf.Pow(10, pulp%3); // da juice
        int juiceJug = Mathf.RoundToInt(juice);

        switch (gridSize)
        {
            case 3:
                return juiceJug % 3;
            case 5:
                return juiceJug % 5;
            case 7:
                return juiceJug % 7;
            case 9:
                return juiceJug % 9;
            case 11:
                return juiceJug % 11;
            default:
                return 0;
        }

    }
}
