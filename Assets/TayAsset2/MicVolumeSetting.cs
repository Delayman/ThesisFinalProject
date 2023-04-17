using Photon.Voice.Unity.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicVolumeSetting : MonoBehaviour
{
    //[SerializeField] private MicAmplifier micAmplifier1 , micAmplifier2, micAmplifier3;
  /*  [SerializeField] private AudioSource micAmplifier1, micAmplifier2, micAmplifier3;
    public Slider MicSlider1;
    public Slider MicSlider2;
    public Slider MicSlider3;
    [SerializeField] private GameObject _RunnerA;
    [SerializeField] private GameObject _RunnerB;
    [SerializeField] private GameObject _Watcher;
    private int id = 0;*/
    void Start()
    {
       // micAmplifier1 = _Watcher.GetComponent<MicAmplifier>();
       // micAmplifier2 = _RunnerA.GetComponent<MicAmplifier>();
       // micAmplifier3 = _RunnerB.GetComponent<MicAmplifier>();
        //micAmplifier1= _Watcher.GetComponent<AudioSource>();
       // micAmplifier2 = _RunnerA.GetComponent<AudioSource>();
      //  micAmplifier3 = _RunnerB.GetComponent<AudioSource>();
        this.gameObject.SetActive(false);
    }

    public void Mic1Volume1()
    {
        //micAmplifier1.AmplificationFactor = MicSlider1.value;
      //  micAmplifier1.volume = MicSlider1.value;
    }
    public void Mic1Volume2()
    {
        //micAmplifier2.AmplificationFactor = MicSlider2.value;
        //micAmplifier2.volume = MicSlider2.value;
    }
    public void Mic1Volume3()
    {
        //micAmplifier3.AmplificationFactor = MicSlider3.value;
      //  micAmplifier3.volume = MicSlider3.value;
    }
}
