using PlayerScoreScript;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardUIEntryScript : MonoBehaviour
{
    public TextMeshProUGUI positionEntryText;
    public TextMeshProUGUI nameEntryText;
    public TextMeshProUGUI scoreEntryText;
    public TextMeshProUGUI hicomboEntryText;

    public void Initalise(PlayerScore playerScore, int position)
    {
        positionEntryText.text = position.ToString();
        nameEntryText.text = playerScore.playerName;
        scoreEntryText.text = playerScore.highScore.ToString();
        hicomboEntryText.text = playerScore.highestCombo.ToString();
    }
}
