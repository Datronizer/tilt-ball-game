using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointTracker : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreboard;

    [SerializeField]
    private TextMeshProUGUI deathboard;

    private int point;
    private int death;

    void Awake()
    {
        ScoreboardUpdate(); // Just to start the scoreboard
        deathboard.text = $"Feature\n" + $"coming soon";
    }

    void AddScore(int value)
    {
        point += value;
        ScoreboardUpdate();
    }

    void AddDeath(int value)
    {
        death += value;
        if (point >= 5) // 5 for testing
        {
            DeathboardUpdate();
        }
    }

    private void ScoreboardUpdate()
    {
        scoreboard.text = $"{point}\n" + $"Score";
    }

    private void DeathboardUpdate()
    {
        // TODO: Have the death counter show up only after hitting 25 points
        deathboard.text = $"{death}\n" + $"Deaths";
    }
}
