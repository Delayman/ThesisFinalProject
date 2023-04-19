using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockICE : MonoBehaviour
{
    public GameObject StartICEPoint;
    //public GameObject MainGameICE;
    public IcePuzzleController PuzzleController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "IceCube")
        {
            PuzzleController.UnLockButton();
        }
    }
}
