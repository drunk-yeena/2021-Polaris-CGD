using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RemoveHP : MonoBehaviour
{

    public Image[] HealthPoints;
    // Start is called before the first frame update
    public void LoseHP(int number)
    {
        HealthPoints[number].enabled =  false;
    }
}
