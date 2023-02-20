using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUIShower : MonoBehaviour
{
    private TMP_Text powerText;
    private GeneratorTimer timer;

    private void Start()
    {
        powerText = GetComponent<TMP_Text>();

        timer = FindObjectOfType<GeneratorTimer>();
    }

    private void FixedUpdate()
    {
        powerText.text = "Power : " + Mathf.Round(timer.currentPower);
    }
}
