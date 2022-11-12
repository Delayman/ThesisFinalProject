using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_AnimetionController : MonoBehaviour
{
    [SerializeField] Animator playeranimator;
    
    void Start()
    {
        playeranimator = this.gameObject.GetComponent<Animator>();
        PlayerAnimationed();
    }
    
    public void PlayerAnimationed()
    {
        FPS_PlayerMovement Playeranimationed = GetComponentInParent<FPS_PlayerMovement>();
        Playeranimationed.playeranimationevent(SetAnimation);
    }
    public void SetAnimation(int AnimationID)
    {
        playeranimator.SetInteger("PlayerAnimationID",AnimationID);
    }

}
