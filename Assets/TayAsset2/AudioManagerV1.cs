using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AudioManagerV1 : MonoBehaviour
{
    public static AudioManagerV1 Instance;
    public SoundList[] musicSound, sfxSound;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("");//EnterMusicName
    }
    public void PlayMusic(string name)
    {
        SoundList s = Array.Find(musicSound , x=> x.name == name);

        if (s == null)
        {
            Debug.Log("MusicSound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        SoundList s = Array.Find(sfxSound, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SfxSound not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
    //Not complate https://www.youtube.com/watch?v=rdX7nhH6jdM&t=393s&ab_channel=RehopeGames
}
