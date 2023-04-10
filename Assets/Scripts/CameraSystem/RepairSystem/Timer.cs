using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 10f;
    public bool isTimeOut;
    public bool isResetting;

    private SystemBrokeDownController ctr;
    
    private void Start()
    {
        isTimeOut = false;
        isResetting = false;

        ctr = FindObjectOfType<SystemBrokeDownController>();
    }

    private void Update()
    {
        if (!isTimeOut && !isResetting)
        {
            CheckSystem();
            CountDown();
        }

        if (isTimeOut)
        {
            BrokeSystem();
        }
    }

    private void CheckSystem()
    {
        switch (this.name.First().ToString())
        {
            case "C" : 
                ctr.RepairCam();
                break;
            case "S" : 
                ctr.RepairSound();
                break;
            case "V" : 
                ctr.RepairVent();
                break;
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
                ctr.BrokeCam();
                break;
            case "S" : 
                ctr.BrokeSound();
                break;
            case "V" : 
                ctr.BrokeVent();
                break;
        }
    }
}
