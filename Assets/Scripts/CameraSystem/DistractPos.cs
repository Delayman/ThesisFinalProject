using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractPos : MonoBehaviour
{
    public GameObject distractPos;
    private Transform distractPoint;

    private void Start()
    {
        distractPoint = distractPos.transform;
    }

    public void PlaySound()
    {
        EnemyAI.DistractPos = distractPoint;
        EnemyAI.isDistractedbyPlayer = true;
    }
}
