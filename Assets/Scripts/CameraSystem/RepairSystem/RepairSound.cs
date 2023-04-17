using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RepairSound : Interactable
{
    [SerializeField] private Timer textBox;
    [SerializeField] private bool isTutorial;
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
        if (isTutorial)
        {
            RepairVoiceNoRpc();
        }
        else
        {
            var PV = GetComponent<PhotonView>();
            PV.RPC("RepairVoice", RpcTarget.All);
        }
    }
    
    [PunRPC]
    private void RepairVoice()
    {
        isOn = true;
        textBox.isResetting = true;
        ctr.DisableAllButton();
        Invoke(nameof(Cooldown), repairTime);
        Sound.Play();
    }
    
    private void RepairVoiceNoRpc()
    {
        isOn = true;
        textBox.isResetting = true;
        ctr.DisableAllButton();
        Invoke(nameof(Cooldown), repairTime);
        Sound.Play();
    }

    private void Cooldown()
    {
        ctr.EnableAllButton();
        textBox.AddTime(textBox.maxTimer);
        textBox.isResetting = false;
        textBox.isTimeOut = false;
        isOn = false;
    }
}
