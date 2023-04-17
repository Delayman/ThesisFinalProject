using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class DistractPos : MonoBehaviour
{
    [SerializeField] private Button lureButton;
    
    public GameObject distractPos;
    private Transform distractPoint;

    private void Start()
    {
        distractPoint = distractPos.transform;
    }

    public void PlaySound()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("PlayerLureSound", RpcTarget.All);
        
    }

    [PunRPC]
    public void PlayerLureSound()
    {
        Debug.Log($"chosenDistractPos : {distractPos.transform.position}");

        EnemyAI.DistractPos = distractPos.transform;
        EnemyAI.isDistractedbyPlayer = true;
    }
}
