using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistractPos : MonoBehaviour
{
    public GameObject distractPos;
    public float delay = 4f;
    private Transform distractPoint;

    private void Start()
    {
        distractPoint = distractPos.transform;
    }

    public void PlaySound()
    {
        EnemyAI.DistractPos = distractPoint;
        EnemyAI.isDistractedbyPlayer = true;
        StartCoroutine(IceButtonDelay());
    }

    private IEnumerator IceButtonDelay()
    {
        this.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(delay);
        this.GetComponent<Button>().enabled = true;
    }
}
