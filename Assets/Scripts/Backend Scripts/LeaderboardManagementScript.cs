using System;
using System.Collections.Generic;
using System.IO;
using PlayerScoreScript;
using UnityEngine;

public class LeaderboardManagementScript : MonoBehaviour
{
    //List Variable holding the scores when game is running
    public List<PlayerScore> scores = new List<PlayerScore>();
    //Laying out path of the file holding the scores
    private string path;

    // Start is called before the first frame update
    void Start()
    {
        AddToLeaderboard("Test", 100, 10);

        path = Application.dataPath + "/Leaderboard.txt";
        CreateTextFile();

        Debug.Log(scores.Count.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddToLeaderboard(string name, int highscore, int hicombo)
    {
        PlayerScore playerScore = new PlayerScore(name, highscore, hicombo);
        scores.Add(playerScore);
        scores.Sort();

    }

    public void UpdateScoreboardUI()
    {
        Debug.Log(scores.Count.ToString());
        GameObject.Find("ScoreBoard").GetComponent<LeaderboardUIScript>().UpdateUI(scores);
    }

    /// <summary>
    /// Creates and/or searches for a Text File to hold highscores when the application is quit
    /// </summary>
    public void CreateTextFile()
    {
        //Creating the file if it doesn't already exist
        if (!File.Exists(path))
        {
            Debug.Log("No Leaderboard File - Creating File");
            File.Create(path).Dispose();
        }
        else
        {
            Debug.Log("Leaderboard File exists - Skipping Method, Reading to List");
            ReadToList();
        }
    }

    public void ReadToList()
    {
        try
        {
            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();

            while (line != null)
            {
                Debug.Log(line);
                string[] linedata = line.Split(',');

                var name = linedata[0];
                var hiscore = int.Parse(linedata[1]);
                var hicombo = int.Parse(linedata[2]);

                AddToLeaderboard(name, hiscore, hicombo);

                line = sr.ReadLine();
            }
            sr.Close();
        }
        catch (Exception e)
        {
            Debug.LogError("Exception: " + e.Message);
        }
        finally
        {
            Debug.Log("Executing Finally Block");
        }
    }

    public void WriteToFile()
    {
        try
        {
            File.WriteAllText(path, "");
            StreamWriter sw = new StreamWriter(path);

            foreach (PlayerScore score in scores)
            {
                var name = score.playerName;
                var hiscore = score.highScore;
                var hicombo = score.highestCombo;

                string line = name + "," + hiscore + "," + hicombo;
                Debug.Log(line);
                sw.WriteLine(line);
            }

            sw.Close();
        }
        catch (Exception e)
        {
            Debug.LogError("Exception: " + e.Message);
        }
        finally
        {
            Debug.Log("Executing Finally Block");
        }
    }
        
    /// <summary>
    /// If needed, this method can be called to remove all of the current scores
    /// </summary>
    public void PurgeLeaderboard()
    {
        scores.Clear();
        Debug.Log("The Leaderboard has been purged, list is now empty");
    }
}