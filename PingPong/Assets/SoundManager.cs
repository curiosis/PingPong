using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip wall, goal1, goal2, goal0;
    static AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "wall":
                audioSource.PlayOneShot(wall);
                break;
            case "goal0":
                audioSource.PlayOneShot(goal0);
                break;
            case "goal1":
                audioSource.PlayOneShot(goal1);
                break;
            case "goal2":
                audioSource.PlayOneShot(goal2);
                break;
        }
    }
}