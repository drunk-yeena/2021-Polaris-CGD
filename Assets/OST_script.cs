using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OST_script : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] OSTclips;
   
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void OST_Play()
    {
        
        AudioClip clip3 = OSTclips[UnityEngine.Random.Range(0, OSTclips.Length)];
        audioSource.PlayOneShot(clip3);
    }

    public void OST_Stop()
    {
        audioSource.Stop();
    }
}
