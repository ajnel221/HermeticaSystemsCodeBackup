using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDeathSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sounds;
    int randomInt;

    public void PlayRandomDeathScream()
    {
        randomInt = Random.Range(0,sounds.Length);

        audioSource.PlayOneShot(sounds[randomInt]);
    }
}
