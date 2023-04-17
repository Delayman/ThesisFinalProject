using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Photon.Voice.PUN;
using UnityEngine;

public class VoiceAnalyticLogger : MonoBehaviour
{
    public float VCTimerP1, VCTimerP2, VCTimerP3 = 0f;
    public float VCUseageP1, VCUseageP2, VCUseageP3 = 0f;

    private bool isCountedP1, isCountedP2, isCountedP3;
    private bool isPushToTalkP1, isPushToTalkP2, isPushToTalkP3;
    
    private List<FPS_PlayerMovement> vcGetterList = new List<FPS_PlayerMovement>();
    
    private void FixedUpdate()
    {
        if (vcGetterList.Count != 3)
        {
            vcGetterList = FindObjectsOfType<FPS_PlayerMovement>().ToList();
        }

        AddVCTimerToP1();
        AddVCTimerToP2();
        AddVCTimerToP3();
    }
    
    public void AddVCCountToP1()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("AddVCCountToP1RPC", RpcTarget.All);
    }
    
    public void AddVCCountToP2()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("AddVCCountToP2RPC", RpcTarget.All);
    }
    
    public void AddVCCountToP3()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("AddVCCountToP3RPC", RpcTarget.All);
    }
    
    public void AddVCTimerToP1()
    {
        if (!isPushToTalkP1) return;
        
        var PV = GetComponent<PhotonView>();
        PV.RPC("AddVCTimerToP1RPC", RpcTarget.All);
    }
    
    public void AddVCTimerToP2()
    {
        if (!isPushToTalkP2) return;
        
        var PV = GetComponent<PhotonView>();
        PV.RPC("AddVCTimerToP2RPC", RpcTarget.All);
    }
    
    public void AddVCTimerToP3()
    {
        if (!isPushToTalkP3) return;
        
        var PV = GetComponent<PhotonView>();
        PV.RPC("AddVCTimerToP3RPC", RpcTarget.All);
    }
    
    [PunRPC]
    public void AddVCCountToP1RPC()
    {
        // this.gameObject.GetComponent<PhotonVoiceView>().RecorderInUse.TransmitEnabled = true;

        if (!isCountedP1)
        {
            VCUseageP1 += 1;
            isCountedP1 = true;
        }

        isPushToTalkP1 = true;
    }
    
    [PunRPC]
    public void AddVCCountToP2RPC()
    {
        // this.gameObject.GetComponent<PhotonVoiceView>().RecorderInUse.TransmitEnabled = true;
        if (!isCountedP2)
        {
            VCUseageP2 += 1;
            isCountedP2 = true;
        }

        isPushToTalkP2 = true;
    }
    
    [PunRPC]
    public void AddVCCountToP3RPC()
    {
        // this.gameObject.GetComponent<PhotonVoiceView>().RecorderInUse.TransmitEnabled = true;
        if (!isCountedP3)
        {
            VCUseageP3 += 1;
            isCountedP3 = true;
        }

        isPushToTalkP3 = true;
    }
    
    [PunRPC]
    public void AddVCTimerToP1RPC()
    {
        VCTimerP1 += Time.deltaTime;
    }
    
    [PunRPC]
    public void AddVCTimerToP2RPC()
    {
        VCTimerP2 += Time.deltaTime;
    }
    
    [PunRPC]
    public void AddVCTimerToP3RPC()
    {
        VCTimerP3 += Time.deltaTime;
    }
    
    
    //==============================//
    
    public void StopVCTimerToP1()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("StopVCTimerToP1RPC", RpcTarget.All);
    }
    
    public void StopVCTimerToP2()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("StopVCTimerToP2RPC", RpcTarget.All);
    }
    
    public void StopVCTimerToP3()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("StopVCTimerToP3RPC", RpcTarget.All);
    }
    
    [PunRPC]
    public void StopVCTimerToP1RPC()
    {
        isPushToTalkP1 = false;
        isCountedP1 = false;
    }
    
    [PunRPC]
    public void StopVCTimerToP2RPC()
    {
        isPushToTalkP2 = false;
        isCountedP2 = false;
    }
    
    [PunRPC]
    public void StopVCTimerToP3RPC()
    {
        isPushToTalkP3 = false;
        isCountedP3 = false;
    }
}
