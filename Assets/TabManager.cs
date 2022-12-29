using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabManager : MonoBehaviour
{

    private void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        Debug.Log(buttons.Length);
        foreach (var button in buttons)
        {
            Debug.Log(button);
        }
    }

    // Gameplay tab
    // Mostly things that contribute to the main flow of the game like
    // more obstacles, multipliers, glowing squares, etc.
    //
    // Grants score boosting for that one run.

    // Features tab
    // Things that contribute to the game itself. Example: skybox, skins,
    // mats, extra functionality, narration, etc.
    //
    // Grants score multiplication / percentage boost 

    // ?? tab
    // Weird ARG shit that grants a permanent % boost/multiplier
    // Requires massive brain thinking to unlock.
    //
    // Opens up new gamemodes/challenges to further boost permanent stacks (invisible wall challenge/solving main puzzle using shadows challenge/etc.)
    // Also unlocks spooky things ingame
}
