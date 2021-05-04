using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Points_Script : MonoBehaviour
{
    public Text Points_text;
    public int Point_score=0;

    void Update()
    {
        Points_text.text = "" + Point_score;
    }
    public void addPoints(int pPoints)
    {
        Point_score += pPoints;
    }
    public void removePoints(int pPoints)
    {
        Point_score += pPoints;
    }
}
