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
    public GameObject masterObject;

    LeaderboardManagementScript leaderboardManagement;

    private void Start()
    {
        leaderboardManagement = masterObject.GetComponent<LeaderboardManagementScript>();
        UpdateUI();
    }

    private void UpdateUI()
    {
        
        int count = 0;

        foreach(Transform child in highscoreHolderTransform)
        {
            Destroy(child.gameObject);
        }

        foreach (PlayerScore score in leaderboardManagement.scores)
        {
            if(count == maxLeaderboardEntries)
            {
                break;
            }
            else
            {
                count++;
                Instantiate(leaderboardEntryObject, highscoreHolderTransform).GetComponent<LeaderboardUIEntryScript>().Initalise(score,count);
                
            }
        }
    }
}
