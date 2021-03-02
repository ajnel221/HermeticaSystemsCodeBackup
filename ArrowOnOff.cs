using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOnOff : MonoBehaviour
{
    public GameObject arrow;
    public AudioSource buttonAudioSource;
    public AudioClip hoverButton;

    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(false);
    }

    public void PointerEnterButton()
    {
        arrow.SetActive(true);
        buttonAudioSource.PlayOneShot(hoverButton);
    }

    public void PointerExitButton()
    {
        arrow.SetActive(false);
    }
}
