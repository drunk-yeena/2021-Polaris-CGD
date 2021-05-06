using PlayerScoreScript;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LeaderboardUIScript : MonoBehaviour
{
    public int maxLeaderboardEntries = 5;
    public Transform highscoreHolderTransform;
    public GameObject leaderboardEntryObject;

    private void Start()
    {
        //UpdateUI();
    }

    public void UpdateUI(List<PlayerScore> scores)
    {
        
        int count = 0;

        foreach(Transform child in highscoreHolderTransform)
        {
            Destroy(child.gameObject);
        }

        if (scores != null)
        { 
            foreach (PlayerScore score in scores)
            {
                if (count == maxLeaderboardEntries)
                {
                    break;
                }
                else
                {
                    count++;
                    Instantiate(leaderboardEntryObject, highscoreHolderTransform).GetComponent<LeaderboardUIEntryScript>().Initalise(score, count);

                }
            }
        }
        else
        {
            Debug.Log("List is currently Null");
        }
    }
}
