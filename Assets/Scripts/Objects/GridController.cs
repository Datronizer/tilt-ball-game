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

        // Prevents shuffling back to current square
        if (highlightedSquare.name == $"{x}, {y}")
        {
            ShuffleGlowingSquare();
        }
        else
        {
            // Swapping square types
            GlowingButton newGlowingButton = ChooseGlowingSquareType();

            // Move square to new spot
            highlightedSquare = GameObject.Find($"{x}, {y}");
            Instantiate(newGlowingButton, new Vector3(highlightedSquare.transform.position.x, -0.1f, highlightedSquare.transform.position.z), Quaternion.identity, FindObjectOfType<GridController>().transform);

            Debug.Log($"Success! Injected {newGlowingButton}");
        }
    }

    int GetRandom()
    {
        // Simple randomizer
        int banana = Random.Range(0, 99);

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

    GlowingButton ChooseGlowingSquareType(string buttonType)
    {
        GlowingButton foundButton = System.Array.Find(glowingButtonCollection, elt => elt.buttonType == buttonType);
        return foundButton;
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
         * 
         * (III) Finding the radius:
         * 1) Fix A
         * 2) Find the metric of A and B which is |A-B|
         * 3) If m(A,B) less than radius then 
         */

        int a = Random.Range(0, 25000);
        int b = Random.Range(0, 25000);

        int m = Mathf.Abs(a - b);

        return m switch
        {
            < 5 => ChooseGlowingSquareType("Legendary"),
            < 25 => ChooseGlowingSquareType("Epic"),
            < 150 => ChooseGlowingSquareType("Rare"),
            < 2500 => ChooseGlowingSquareType("Uncommon"),
            _ => ChooseGlowingSquareType("Common"),
        };
    }
}
