using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Generator : Interactable
{
    [SerializeField] private float delay = 0.5f;
    [SerializeField] private float powerToAdd = 10;
    private const string clickText = "[E] to add power";
    public AudioSource GeneraterSound;
    private bool isHeld;

    public override string GetDescription()
    {
        return clickText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("AddPower", RpcTarget.All);
    }

    [PunRPC]
    private void AddPower()
    {
        var generatorTimer = GetComponent<GeneratorTimer>();

        generatorTimer.AddTime(powerToAdd);

        GeneraterSound.Play();
    }

    // private IEnumerator HoldToAddPower()
    // {
    //     while (isHeld)
    //     {
    //         AddPower();
    //         yield return new WaitForSeconds(delay);
    //     }
    // }
}
