using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateBlock : MonoBehaviour
{
    [SerializeField] PressAllPlateController puzzleControl;
    private void Start()
    {
        puzzleControl = FindObjectOfType<PressAllPlateController>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other)
        {
            puzzleControl.ResetThisPuzzle();
        }
    }
}
