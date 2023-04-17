using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Generator : Interactable
{
    [SerializeField] private float delay = 3f;
    [SerializeField] private float powerToAdd = 10;
    private const string clickText = "[E] to add power";
    public AudioSource GeneraterSound;
    
    private bool isHeld;

    private bool isInTutorial;

    public override string GetDescription()
    {
        return clickText;
    }

    public override void Interact()
    {
        isInTutorial = GetComponent<GeneratorTimer>().isTutorialScene;
        if (isInTutorial)
        {
            AddPower();
            GeneraterSound.Play();
        }
        else
        {
            var PV = GetComponent<PhotonView>();
            PV.RPC("AddPowerOnline", RpcTarget.All);
            GeneraterSound.Play();
        }
    }

    [PunRPC]
    private void AddPowerOnline()
    {
        var generatorTimer = GetComponent<GeneratorTimer>();

        generatorTimer.AddTime(powerToAdd);
        
        StartCoroutine(AddPowerDelay());
    }
    
    private void AddPower()
    {
        var generatorTimer = GetComponent<GeneratorTimer>();

        generatorTimer.AddTime(powerToAdd);
        
        StartCoroutine(AddPowerDelay());
    }

    private IEnumerator AddPowerDelay()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(delay);
        this.gameObject.GetComponent<BoxCollider>().enabled = true;

    }
}
