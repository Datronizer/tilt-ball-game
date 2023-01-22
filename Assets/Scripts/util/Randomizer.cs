using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Gets random coordinate point based on square size
    /// </summary>
    /// <param name="gridSize"></param>
    /// <returns>int coordinatePoint</returns>
    public int GetRandomCoordinate(int gridSize)
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

    /// <summary>
    /// Returns a 2D random coordinate point based on gridSize
    /// </summary>
    /// <param name="gridSize"></param>
    /// <returns>(int x, int y)</returns>
    public (int, int) GetRandomCoordinatePair(int gridSize)
    {
        int x = GetRandomCoordinate(gridSize);
        int y = GetRandomCoordinate(gridSize);

        return (x, y);
    }

    public int MetricRandomness()
    {
        int a = Random.Range(0, 25000);
        int b = Random.Range(0, 25000);

        int m = Mathf.Abs(a - b);

        return m;
    }

    /// <summary>
    /// Pseudorandom guarantees the inputted percentage by tilting the odds in your favor whenever it doesn't trigger and reduces your odds whenever it does.
    /// To use, initialize a float "percentage" variable, and a bool "proc" variable.
    /// Assign this method to percentage. If proc == true, then pseudorandom generates a new percentage and
    /// </summary>
    /// <param name="percentage"></param>
    /// <returns></returns>
    public void Pseudorandom(float percentage)
    {
        if (percentage < 0.001)
        {
            throw new System.Exception("Percentage cannot be lower than 0.001");
        }

        float a = percentage * 1000; // To account for percentage as low as 0.001
        float b = Random.Range(0, 100_000);
    }

    //public bool
}
