using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSound : Interactable
{
    [SerializeField] private Timer textBox;
    [SerializeField] private float addedTime = 10f;
    [SerializeField] private float repairTime = 5f;
    
    private RepairPanelController ctr;
    
    private const string ActiveText = "[E] to repair the sound.";
    
    private bool isOn;
    public AudioSource Sound;

    private void Awake()
    {
        if (textBox == null) Debug.Log($"<color=red>Timer </color> was NOT FOUND");;
    }

    private void Start()
    {
        ctr = FindObjectOfType<RepairPanelController>();
        isOn = false;
    }

    public override string GetDescription()
    {
        return ActiveText;
    }

    public override void Interact()
    {
        isOn = true;
        
        Repair();
    }

    private void Repair()
    {
        textBox.isResetting = true;
        ctr.DisableAllButton();
        Invoke(nameof(Cooldown), repairTime);
        Sound.Play();
    }

    private void Cooldown()
    {
        ctr.EnableAllButton();
        textBox.AddTime(addedTime);
        textBox.isResetting = false;
        textBox.isTimeOut = false;
        isOn = false;
    }
}
