using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RepairAll : Interactable
{
    [SerializeField] private List<Timer> textBoxList;
    [SerializeField] private float addedTime = 10f;
    [SerializeField] private float repairTime = 15f;
    
    private RepairPanelController ctr;
    
    private const string ActiveText = "[E] to repair the all system.";
    
    private bool isOn;

    public AudioSource Sound;
    private void Awake()
    {
        if (textBoxList == null) Debug.Log($"<color=red>Timer </color> was NOT FOUND");;
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
        var PV = GetComponent<PhotonView>();
        PV.RPC("RepairAllSystem", RpcTarget.All);
    }

    [PunRPC]
    private void RepairAllSystem()
    {
        isOn = true;

        foreach (var textBox in textBoxList)
        {
            textBox.isResetting = true;
        }
        
        ctr.DisableAllButton();
        Invoke(nameof(Cooldown), repairTime);
        Sound.Play();
    }

    private void Cooldown()
    {
        foreach (var textBox in textBoxList)
        {
            textBox.AddTime(textBox.maxTimer);
            textBox.isResetting = false;
            textBox.isTimeOut = false;
        }
        
        ctr.EnableAllButton();
        isOn = false;
    }
}
