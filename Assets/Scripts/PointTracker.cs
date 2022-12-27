using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointTracker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreboard;

    private int point;

    void AddScore(int value)
    {
        point += value;
        ScoreboardUpdate();
    }

    private void ScoreboardUpdate() {
        scoreboard.text = $"{point}\n" +
            $"Score";

    }
}
