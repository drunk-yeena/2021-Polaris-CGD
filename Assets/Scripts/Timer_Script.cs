using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Script : MonoBehaviour
{
    public float  timeRemaining=0;
    public Text Timetext;
    public GameObject endGameUI;
    public GameObject retryAndExit;

    void Start()
    {
        this.gameObject.GetComponent<OST_script>().OST_Play();
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            endGameUI.SetActive(false);
            timeRemaining -= Time.deltaTime;

            Debug.Log("Time: ");

        }
        TimerTest(timeRemaining);
        if(timeRemaining<=0)
        {
            enabled = false;
            this.gameObject.GetComponent<OST_script>().OST_Stop();
            endGameUI.SetActive(true);
            retryAndExit.SetActive(false);
        }
    }
    void TimerTest(float timeDisplay)
    {
        float minutes = Mathf.FloorToInt(timeDisplay/60);
        float seconds = Mathf.FloorToInt(timeDisplay%60);
        
        Timetext.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

}
