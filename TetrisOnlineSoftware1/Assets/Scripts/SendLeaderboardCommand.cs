using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendLeaderboardCommand : ICommand
{
    int score;

    public SendLeaderboardCommand(int score)
    {
        this.score = score;
    }
    public void Execute()
    {
        PlayfabManager.instance.SendLeaderboard(score);
    }
}
