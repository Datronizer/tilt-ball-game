using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistanceManager : MonoBehaviour
{
    private GameData gameData;

    public static DataPersistanceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in the scene.");
        }
        instance = this;
    }

    private void Start()
    {
        LoadGame();
    }

    private void NewGame()
    {
        this.gameData = new GameData();
    }

    private void LoadGame()
    {
        // TODO: Load any saved data from a file using data handler

        // if no data, initialize new game
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }

        // TODO: Push loaded data to all other scripts that need it
    }

    private void SaveGame()
    {
        // TODO: Pass data to other scripts so they can update it

        // TODO: Save that data to a file using data handler
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
