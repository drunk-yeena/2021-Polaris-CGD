using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAnimalSFX : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] slashClips;
    [SerializeField]
    private AudioClip[] footSteps;

    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void Slash()
    {
        audioSource.volume = Random.Range(0.7f, 1.0f);
        audioSource.pitch = Random.Range(0.7f, 1.1f);
        AudioClip clip2 = slashClips[UnityEngine.Random.Range(0, slashClips.Length)];
        audioSource.PlayOneShot(clip2);
       // Debug.Log("Bear_Slash");

    }
    private void Step()
    {
        audioSource.volume = Random.Range(0.090f, 0.160f);
        audioSource.pitch = Random.Range(0.7f, 1.1f);
        AudioClip clip = footSteps[UnityEngine.Random.Range(0, footSteps.Length)];
        audioSource.PlayOneShot(clip);

        //Debug.Log("Bear_Walk");
    }
}
