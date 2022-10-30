using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePuzzleGoal : MonoBehaviour
{
    public bool isEnterGoal;
    private IcePuzzleController ctr;
    
    private void Start()
    {
        ctr = FindObjectOfType<IcePuzzleController>();
        isEnterGoal = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IceCube"))
        {
            isEnterGoal = true;
            
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ctr.CheckComplete();
        }
    }
}
