using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GridController : MonoBehaviour
{
    [SerializeField] private SquareTrigger gridSquare;
    [SerializeField] private GlowingButton[] glowingButtonCollection;
    [SerializeField] private int gridSize;

    private GameObject highlightedSquare;

    private void Awake()
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
        // Gets random coordinates
        int x = GetRandom();
        int y = GetRandom();
        highlightedSquare = GameObject.Find($"{x}, {y}");

        // Randomly chooses next glowing square
        GlowingButton glowingButton = ChooseGlowingSquareType();

        // Instantiate square
        Instantiate(glowingButton, new Vector3(highlightedSquare.transform.position.x, -0.1f, highlightedSquare.transform.position.z), Quaternion.identity, FindObjectOfType<GridController>().transform);
    }

    void ShuffleGlowingSquare()
    {
        // Gets random coordinates
        int x = GetRandom();
        int y = GetRandom();

        GlowingButton glowingSquare = FindObjectOfType<GlowingButton>();

        // Checks if current square is of same type. If no then swap.
        GlowingButton newGlowingSquare = ChooseGlowingSquareType();
        if (glowingSquare.name != newGlowingSquare.name)
        {
            glowingSquare = newGlowingSquare;
        }

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
        // Simple randomizer
        int banana = Mathf.RoundToInt(UnityEngine.Random.Range(0, 99));

        return gridSize switch
        {
            3 => banana % 3,
            5 => banana % 5,
            7 => banana % 7,
            9 => banana % 9,
            11 => banana % 11,
            _ => 0,
        };
    }

    GlowingButton ChooseGlowingSquareType()
    {
        /**
         * (I) Radii of randomness:
         * 5     : Legendary
         * 25    : Epic
         * 150   : Rare
         * 2500  : Uncommon
         * 10000 : Common
         * 
         * (II) How it works: 
         * 1) Roll 2 numbers A and B up to 25000. Number A is the basis, B is the measurement.
         * 2) Using A, expand the radius by the amount in (I)
         * 3) If B is in the radius of A, choose that square
         *    Else, move on to next radius.
         * 4) Repeat until you finish Uncommon. Then just straight up output Common.
         */

        Debug.Log("Rollllllllll");

        int a = Mathf.RoundToInt(Random.Range(0, 25000));
        int b = Mathf.RoundToInt(Random.Range(0, 25000));

        int[] radii = { 5, 25, 150, 2500, 10000 };
        for (int i = 0; i > radii.Length; i++)
        {
            Debug.Log($"Rolling for radius {radii[i]}");
            if (b > (a - radii[i]) && b < (a + radii[i]))
            {
                return glowingButtonCollection[i];
                Debug.Log($"Roll successful. {glowingButtonCollection[i].name} is chosen!");
            }
        }

        return glowingButtonCollection[4];
    }
}
