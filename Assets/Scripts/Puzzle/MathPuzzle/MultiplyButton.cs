using Photon.Pun;
using UnityEngine;

public class MultiplyButton : Interactable
{
    private string OffText = "[E] to <color=red>use</color> button";
    private const string ActivatedText = "[E] to <color=red>use</color> button";
    
    [Tooltip("Set starting state of value")]
    public float state = 1;
    [Tooltip("Value for multiply (Ex. 1 * VALUE)")]
    public float multiplyNum = 2;

    private bool isOn;

    private ResultText resultText;
    public AudioSource ButtonOBJ;

    private void Awake()
    {
        state = 1;
        multiplyNum = 2;
    }
    
    private void Start()
    {
        resultText = FindObjectOfType<ResultText>();
        state = 1;
        multiplyNum = 2;
    }

    public override string GetDescription()
    {
        return !isOn ? OffText : ActivatedText;
    }

    public override void Interact()
    {
        var PV = GetComponent<PhotonView>();
        PV.RPC("GetTextBoxMul", RpcTarget.All);
        ButtonSound();
    }
    public void ButtonSound()
    {
        ButtonOBJ.Play();
    }

    [PunRPC]
    private void GetTextBoxMul()
    {
        isOn = true;

        resultText.UpdateText(state);
        resultText.MultiplyState(multiplyNum);
        resultText.ChangeStateToAll(multiplyNum);
    }
}
