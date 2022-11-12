using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timer = 10f;
    public bool isTimeOut;
    public bool isResetting;
    
    private void Start()
    {
        isTimeOut = false;
        isResetting = false;
    }

    private void Update()
    {
        if(!isTimeOut && !isResetting) 
            CountDown();
    }

    private void CountDown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
            isTimeOut = true;
    }

    public void AddTime(float _time)
    {
        timer = _time;
    }
}
