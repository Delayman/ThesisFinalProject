using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        if (isTimeOut)
        {
            BrokeSystem();
        }
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

    private void BrokeSystem()
    {
        switch (this.name.First().ToString())
        {
            case "C" : 
                //Broke cam
                break;
            case "V" : 
                //Broke vent
                break;
            case "S" : 
                //Broke sound
                break;
        }
    }
}
