using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Stun_txt_Script : MonoBehaviour
{
    public TextMeshProUGUI stn_txt;
   
    public void enableStunTXT()
    {
        stn_txt.enabled = true;
    }
    public void disableStunTXT()
    {
        stn_txt.enabled = false;
    }
}
