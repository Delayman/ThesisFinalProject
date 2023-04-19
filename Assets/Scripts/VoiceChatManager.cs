using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice.Unity;

public class VoiceChatManager : MonoBehaviour
{
    private PhotonView _view;
    private VoiceAnalyticLogger vcLogger;
    
    private bool isPushToTalkable;
    private bool isDisableVoiceChat;

    private void Start()
    {
        _view = GetComponent<PhotonView>();
        vcLogger = FindObjectOfType<VoiceAnalyticLogger>();
    }

    private void FixedUpdate()
    {
        if (_view.IsMine)
        {
            PushToTalk();
        }
    }

    private void PushToTalk()
    {
        if (Input.GetKey(KeyCode.V))
        {
            this.gameObject.GetComponent<Recorder>().TransmitEnabled = true;
            
            if(isPushToTalkable)
            {
                isPushToTalkable = false;
                // Debug.Log("isPushToTalkable : " +isPushToTalkable);
                // Debug.Log("Press counted!");
                //Watcher
                if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("1"))
                {
                    vcLogger.AddVCCountToP1();
                }
                //Runner A
                if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("4"))
                {
                    vcLogger.AddVCCountToP2();
                }
                //Runner B
                if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("3"))
                {
                    vcLogger.AddVCCountToP3();
                }
            }
            else if(isDisableVoiceChat)
            {
                isDisableVoiceChat = false;
            }
            // Debug.Log("Press V!!");
        }
        
        else if (!Input.GetKey(KeyCode.V))
        {
            this.gameObject.GetComponent<Recorder>().TransmitEnabled = false;

            if(!isPushToTalkable)
            {
                isPushToTalkable = true;
            }

            else if(!isDisableVoiceChat)
            {
                isDisableVoiceChat = true;
                // Debug.Log("Time saved!");
                // Debug.Log("isDisableVoiceChat : " +isDisableVoiceChat);

                if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("1"))
                {
                    vcLogger.StopVCTimerToP1();
                }
                
                if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("4"))
                {
                    vcLogger.StopVCTimerToP2();
                }
                
                if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("3"))
                {
                    vcLogger.StopVCTimerToP3();
                }
            }
            //Debug.Log("Unpress V!!");
        }
    }
}
