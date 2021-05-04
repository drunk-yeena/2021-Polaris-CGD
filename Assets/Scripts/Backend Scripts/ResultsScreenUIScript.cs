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
    private AsyncOperation sceneAsync;

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
        StartCoroutine(LoadScene(1));
    }

    public void ExitGame()
    {
        StartCoroutine(LoadScene(0));
    }

    IEnumerator LoadScene(int index)
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        scene.allowSceneActivation = false;
        sceneAsync = scene;

        while (scene.progress < 0.9f)
        {
            Debug.Log("Loading Scene " + " [][] Progress: " + scene.progress);
            yield return null;
        }
        OnFinishedLoadingAllScene(index);
    }

    public void EnableScene(int index)
    {
        sceneAsync.allowSceneActivation = true;

        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);
        if (sceneToLoad.IsValid())
        {
            Debug.Log("Scene is Valid");
            SceneManager.MoveGameObjectToScene(masterObject, sceneToLoad);
            SceneManager.SetActiveScene(sceneToLoad);
        }
    }

    private void OnFinishedLoadingAllScene(int index)
    {
        Debug.Log("Completed Scene Loading");
        EnableScene(index);
        Debug.Log("Scene Activated");
    }
}
