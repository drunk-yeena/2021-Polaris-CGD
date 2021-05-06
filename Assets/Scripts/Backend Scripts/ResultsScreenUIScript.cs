using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsScreenUIScript : MonoBehaviour
{
    public InputField nameSubmission;
    public GameObject masterObject;
    public GameObject scoreSystem;

    LeaderboardManagementScript leaderboardManagement;

    public int score;
    public int combo;

    // Start is called before the first frame update
    void Start()
    {
        nameSubmission.characterLimit = 10;
        masterObject = GameObject.Find("Master Object");
        leaderboardManagement = masterObject.GetComponent<LeaderboardManagementScript>();
        score = scoreSystem.GetComponent<Points_Script>().Point_score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubmitScore()
    {
        string scoreName;

        if(nameSubmission.text == "")
        {
            scoreName = "NONAME";
        }
        else
        {
            scoreName = nameSubmission.text;
        }
        
        leaderboardManagement.AddToLeaderboard(scoreName, score, combo);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

}
