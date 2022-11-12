using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AnimetionController : MonoBehaviour
{
    [SerializeField] Animator playeranimator;
    
    void Start()
    {
        playeranimator = this.gameObject.GetComponent<Animator>();
    }

    
    void Update()
    {
        playeranimationcontroll();
    }

    void playeranimationcontroll()
    {
        if(Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.D))
        {
            playeranimator.SetBool("IsIdle",false);
            playeranimator.SetBool("IsWalk",true);
            playeranimator.SetBool("IsRun",false);
        }
        else if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.S)||Input.GetKeyUp(KeyCode.D))
        {
            playeranimator.SetBool("IsIdle",true);
            playeranimator.SetBool("IsWalk",false);
            playeranimator.SetBool("IsRun",false);
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKeyDown(KeyCode.RightShift))
        {
            playeranimator.SetBool("IsIdle",false);
            playeranimator.SetBool("IsWalk",false);
            playeranimator.SetBool("IsRun",true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)||Input.GetKeyUp(KeyCode.RightShift))
        {
            playeranimator.SetBool("IsIdle",false);
            playeranimator.SetBool("IsWalk",true);
            playeranimator.SetBool("IsRun",false);
        }
    }
}
