using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource intro, loop;

    private void Start()
    {
        intro.Play();
        loop.PlayScheduled(AudioSettings.dspTime + intro.clip.length);
    }
}
