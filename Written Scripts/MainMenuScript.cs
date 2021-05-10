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
    public GameObject masterObject;

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
        SceneManager.LoadScene(1);
    }

    public void QuitApplication()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }

}
