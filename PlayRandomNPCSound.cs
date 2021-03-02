using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomNPCSound : MonoBehaviour
{
    public AudioSource player;
    public AudioClip[] sounds;
    public int playint;
    public int soundint;
    public bool canPlay;

    IEnumerator PlaySounds()
    {
        soundint = sounds.Length;
        playint = Random.Range(0, soundint);                
        player.PlayOneShot(sounds[playint]);

        yield return new WaitForSeconds(3f);

        canPlay = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && other.gameObject.layer == 17)
        {
            if(canPlay == false)
            {
                StartCoroutine(PlaySounds());
                canPlay = true;
            }
        }
    }
}
