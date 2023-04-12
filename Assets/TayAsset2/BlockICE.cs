using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockICE : MonoBehaviour
{
    public GameObject StartICEPoint;
    public GameObject MainGameICE;
    private void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            MainGameICE.transform.position = StartICEPoint.transform.position;
        }
    }
}
