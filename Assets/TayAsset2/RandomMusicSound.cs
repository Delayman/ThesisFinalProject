using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusicSound : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    private AudioSource mymusicaudio;
    // Start is called before the first frame update
    void Start()
    {
        mymusicaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mymusicaudio.isPlaying)
        {
            mymusicaudio.clip = MusicRandomSound();
            mymusicaudio.Play();
        }
    }
    private AudioClip MusicRandomSound()
    {
        return clips[Random.Range(0,clips.Length)];
    }
}
