using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class MainMenuScript : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject highScoreMenu;

    private AsyncOperation sceneAsync;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen.SetActive(true);
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        highScoreMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("Start Game Called");
        StartCoroutine(LoadScene(1));
    }

    public void QuitApplication()
    {
        Debug.Log("Application Quit");
        Application.Quit();
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
        OnFinishedLoadingAllScene();
    }

    public void EnableScene(int index)
    {
        sceneAsync.allowSceneActivation = true;

        Scene sceneToLoad = SceneManager.GetSceneByBuildIndex(index);
        if (sceneToLoad.IsValid())
        {
            Debug.Log("Scene is Valid");
            SceneManager.SetActiveScene(sceneToLoad);          
        }
    }

    private void OnFinishedLoadingAllScene()
    {
        Debug.Log("Completed Scene Loading");
        EnableScene(1);
        Debug.Log("Scene Activated");
    }
}
