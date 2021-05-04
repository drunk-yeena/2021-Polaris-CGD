using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smalAnimal_SFX : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] slashClips;
    [SerializeField]
    private AudioClip[] defaultClips;

    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

    }

    private void Slash()
    {
        audioSource.volume = Random.Range(0.090f, 0.160f);
        audioSource.pitch = Random.Range(0.7f,1.1f);
        AudioClip clip2 = slashClips[UnityEngine.Random.Range(0, slashClips.Length)];
        audioSource.PlayOneShot(clip2);
       // Debug.Log("Wolf_slash");

    }
    private void Step()
    {
        audioSource.volume = Random.Range(0.090f, 0.160f);
        audioSource.pitch = Random.Range(0.7f, 1.1f);
        AudioClip clip = defaultClips[UnityEngine.Random.Range(0, defaultClips.Length)];
        audioSource.PlayOneShot(clip);

        // Debug.Log("wolf_walk");
    }
}
