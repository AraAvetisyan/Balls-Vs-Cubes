using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] namesInGame;
    [SerializeField] private TextMeshProUGUI[] maxLevelInGame;
    [SerializeField] private TextMeshProUGUI remainingTimeView;
    void Start()
    {
       // Geekplay.Instance.leaderboard = this;

        Utils.GetLeaderboard("score", 0, "Point");
        Utils.GetLeaderboard("name", 0, "Point");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
