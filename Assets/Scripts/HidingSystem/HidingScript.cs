using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;

public class HidingScript : Interactable
{
    [SerializeField] private float hidingRadius = 2f;
    [SerializeField] private Vector3 hidingOffSet = new Vector3(0,0,0);
    [SerializeField] private Vector3 getOutOffSet = new Vector3(0,0,0);
    [SerializeField] private Vector3 hidingRotationOffSet = new Vector3(0, 0, 0);

    private const string OffText = "[E] to hide.";

    private GameObject hidingSpot;
    private GameObject targetPlayer;
    private List<PlayerInteraction> playerList;

    private Collider colToChange;
    
    public bool isOccupy;
    public AudioSource HideSound;
        
    private void Start()
    {
        hidingSpot = this.gameObject;

        playerList = FindObjectsOfType<PlayerInteraction>().ToList();
        colToChange = GetComponent<BoxCollider>();

        colToChange.isTrigger = false;
    }

    public override string GetDescription()
    {
        return OffText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("HideSetting", RpcTarget.All);
    }

    [PunRPC]
    public void HideSetting()
    {
        isOccupy = !isOccupy;
        
        ChooseTargetPlayer();
        HidePlayer();
    }

    private void ChooseTargetPlayer()
    {
        float distance;

        if (playerList.Count <= 0)
        {
            playerList = FindObjectsOfType<PlayerInteraction>().ToList();
        }
        
        foreach (var player in playerList)
        {
            distance = Vector3.Distance(player.transform.position,hidingSpot.transform.position);

            if (distance < hidingRadius && player.GetComponent<PlayerStatus>().requestHiding == true)
            {
                targetPlayer = player.gameObject;
                player.GetComponent<PlayerStatus>().requestHiding = false;
            }
        }
    }
    
    private void HidePlayer()
    {
        colToChange.isTrigger = true;

        targetPlayer.transform.position = this.transform.position + hidingOffSet;
        
        targetPlayer.transform.eulerAngles = this.transform.eulerAngles + hidingRotationOffSet;
        
        if (targetPlayer.GetComponent<PlayerStatus>().PlayerName.Contains("2"))
        {
            var PV = GetComponent<PhotonView>();
            PV.RPC("HidePlayerA", RpcTarget.All);
        }
        
        if (targetPlayer.GetComponent<PlayerStatus>().PlayerName.Contains("3"))
        {
            var PV = GetComponent<PhotonView>();
            PV.RPC("HidePlayerB", RpcTarget.All);
        }
        
        // Debug.Log($"Player name : {targetPlayer.GetComponent<PlayerStatus>().PlayerName}");
        
        var disableTargetPlayer = targetPlayer.gameObject.GetComponent<DisablePlayerControl>();
        disableTargetPlayer.isDisableFPSMovement = true;
        
        HideSound.Play();
    }
    
    [PunRPC]
    public void HidePlayerA()
    {
        var hidePlayer = FindObjectOfType<PlayerHidingStatus>();
        hidePlayer.isPlayerAHiding = true;
        
        // Debug.Log($"Player name : {targetPlayer.GetComponent<PlayerStatus>().PlayerName} Status : {hidePlayer.isPlayerAHiding}");
    }
    
    [PunRPC]
    public void HidePlayerB()
    {
        var hidePlayer = FindObjectOfType<PlayerHidingStatus>();
        hidePlayer.isPlayerBHiding = true;
        
        // Debug.Log($"Player name : {targetPlayer.GetComponent<PlayerStatus>().PlayerName} Status : {hidePlayer.isPlayerBHiding}");
    }

    [PunRPC]
    public void GetPlayerOut()
    {
        isOccupy = false;
        colToChange.isTrigger = false;
        targetPlayer.transform.position = this.transform.position + getOutOffSet;
        targetPlayer.gameObject.GetComponent<FPS_PlayerMovement>().enabled = true;
        
        var disableTargetPlayer = targetPlayer.gameObject.GetComponent<DisablePlayerControl>();
        disableTargetPlayer.isDisableFPSMovement = false;
        
        if (targetPlayer.GetComponent<PlayerStatus>().PlayerName.Contains("2"))
        {
            var hidePlayer = FindObjectOfType<PlayerHidingStatus>();
            hidePlayer.isPlayerAHiding = false;
        }
        
        if (targetPlayer.GetComponent<PlayerStatus>().PlayerName.Contains("3"))
        {
            var hidePlayer = FindObjectOfType<PlayerHidingStatus>();
            hidePlayer.isPlayerBHiding = false;
        }
    }
}
