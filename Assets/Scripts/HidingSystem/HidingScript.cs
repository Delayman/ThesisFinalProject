using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        isOccupy = !isOccupy;
        
        ChooseTargetPlayer();
        HidePlayer();
    }

    private void ChooseTargetPlayer()
    {
        float distance;

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
        // targetPlayer.gameObject.GetComponent<FPS_PlayerMovement>().enabled = false;
        targetPlayer.gameObject.GetComponent<PlayerStatus>().isHidden = true;
        
        var disableTargetPlayer = targetPlayer.gameObject.GetComponent<DisablePlayerControl>();
        disableTargetPlayer.isDisableControlAndCam = true;

        //Lock camera NEEDED!!!!!

        HideSound.Play();
    }

    public void GetPlayerOut()
    {
        isOccupy = false;
        colToChange.isTrigger = false;
        targetPlayer.transform.position = this.transform.position + getOutOffSet;
        targetPlayer.gameObject.GetComponent<FPS_PlayerMovement>().enabled = true;
        
        var disableTargetPlayer = targetPlayer.gameObject.GetComponent<DisablePlayerControl>();
        disableTargetPlayer.isDisableControlAndCam = false;
        
        targetPlayer.gameObject.GetComponent<PlayerStatus>().isHidden = false;

    }
}
