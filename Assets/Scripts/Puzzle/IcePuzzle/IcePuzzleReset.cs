using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePuzzleReset : Interactable
{
    private IcePuzzle icePuzzle;
    private Vector3 originPos; 
    private const string resetText = "[E] to <color=red>reset</color> this puzzle.";

    public AudioSource ButtonOBJ;

    private void Start()
    {
        icePuzzle = FindObjectOfType<IcePuzzle>();
        originPos = icePuzzle.movingObj.transform.position;
    }

    public override string GetDescription()
    {
        return resetText;
    }

    public override void Interact()
    {
        icePuzzle.movingObj.transform.position = originPos;
        ButtonSound();
    }
    public void ButtonSound()
    {
        ButtonOBJ.Play();
    }
}
