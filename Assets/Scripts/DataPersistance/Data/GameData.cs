using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int deathCount;

    // values defined in this constructor will be default
    // the game starts when there's no data to load
    public GameData()
    {
        this.deathCount = 0;
    }
}
