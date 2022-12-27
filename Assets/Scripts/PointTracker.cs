using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointTracker : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreboard;

    private int point;
    private int death;

    void Awake()
    {
        ScoreboardUpdate(); // Just to start the scoreboard
    }

    void AddScore(int value)
    {
        point += value;
        ScoreboardUpdate();
    }

    void AddDeath(int value)
    {
        death += value;
        ScoreboardUpdate();
        // TODO: Have the death counter show up only after hitting 25 points
    }

    private void ScoreboardUpdate()
    {
        scoreboard.text = $"{point}\n" + $"Score {death}";
    }
}
