using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Voice.Unity;
using Photon.Voice.PUN;
using Photon.Voice.Unity.UtilityScripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FPS_PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerMoveSpeed;
    [SerializeField] float playerWalkSpeed = 5f;
    [SerializeField] float playerRunSpeed = 10f;
    [SerializeField]
    private float playerLookSpeed = 5f;
    [SerializeField] float PlayerMaxStamina = 10f;
    [SerializeField] float PlayerCurrentStamina = 10f;
    [SerializeField] Slider StaminaBar;

    [SerializeField] AudioSource foot1;
    [SerializeField] AudioSource foot2;

    bool isrun;
    bool isrunable;
    private bool isDisableVoiceChat;
    public bool isDisableMoving;
    private bool isPushToTalkable;
    
    private PhotonView _view;
    // private PhotonVoiceView voiceView;

    //Y axis limit cam rotation stuff
    [SerializeField]
    private float camRotLimit = 85f;
    private float currentCamRotX = 0f;

    Rigidbody rb;

    [SerializeField]
    private Camera cam;
    
    public float micBoostP1,micBoostP2,micBoostP3 = 4f;

    private VoiceAnalyticLogger vcLogger;
    public float VCTimer;
    public float VCUsage;
    
    public GameObject enemyAI;
    public GameObject enemyGFX;

    void Awake()
    {
        isrun = false;
        isrunable = true;
    }
    private void Start()
    {
        _view = GetComponent<PhotonView>();
        vcLogger = FindObjectOfType<VoiceAnalyticLogger>();
        
        if (_view.IsMine)
        {
            //Finding Rigibody to move character
            rb = GetComponent<Rigidbody>();

            //Lock(cursor at middle screen) and Remove Cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StaminaBar = GameObject.FindGameObjectWithTag("StaminaBar").GetComponent<Slider>();
            
            var _micAmplifier = GetComponent<MicAmplifier>();

            if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("1"))
            {
                _micAmplifier.AmplificationFactor = micBoostP1;
            }
            if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("4"))
            {
                _micAmplifier.AmplificationFactor = micBoostP2;
            }
            if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("3"))
            {
                _micAmplifier.AmplificationFactor = micBoostP3;
            }
            
            this.gameObject.GetComponent<Recorder>().RecordingEnabled = false;

            // enemyGFX.SetActive(false);
        }

        if (!_view.IsMine)
        {
            cam.enabled = false;
        }

        isrun = false;

        StaminaBar.maxValue = PlayerMaxStamina;
        StaminaBar.value = PlayerCurrentStamina;

        // Debug.Log($"{enemyAI.gameObject.name}");
    }

    private void FixedUpdate() 
    {
        if (_view.IsMine)
        {
            //Stop ctrl z
            //Getting Input from keyboard
            float horizontalMove = Input.GetAxisRaw("Horizontal");
            float verticalMove = Input.GetAxisRaw("Vertical");

            //Calculate Movement speed
            Vector3 moveHorizontal = transform.right * horizontalMove;
            Vector3 moveVertical = transform.forward * verticalMove;

            Vector3 velocity = (moveHorizontal + moveVertical).normalized * playerMoveSpeed;
            
            if(velocity != Vector3.zero)
            {
                //Apply moving speed
                if (isDisableMoving) return;
                
                PlayerSpeedSet();
                // rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
                rb.AddForce(velocity*10f,ForceMode.Force);

                Vector3 flatVe1 = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                if (flatVe1.magnitude > playerMoveSpeed)
                {
                    Vector3 limitedVe1 = flatVe1.normalized * playerMoveSpeed;
                    rb.velocity = new Vector3(limitedVe1.x, rb.velocity.y, limitedVe1.z);
                }

            }
            else
            {
                rb.velocity = Vector3.zero;
                PlayerAnimationEvent.Invoke(0);
                foot1.enabled = false;
                foot2.enabled = false;
                isrun = false;
            }
            
            Staminacontroller();

            //Getting Input from mouse to move screen
            float horizontalRot = Input.GetAxisRaw("Mouse X");
            float verticalRot = Input.GetAxisRaw("Mouse Y");

            //Calculate X Axis rotation
            Vector3 xRotation = new Vector3 (0f, horizontalRot, 0f) * playerLookSpeed;

            //Apply X Axis rotation
            rb.MoveRotation(rb.rotation * Quaternion.Euler(xRotation));

            //Apply Y Axis rotation with head turn limit (not going over 180 degree)
            float yRotation = verticalRot * playerLookSpeed;

            if(cam != null)
            {
                //Calculate and Set Rotation with limit
                currentCamRotX -= yRotation;
                currentCamRotX = Mathf.Clamp(currentCamRotX, -camRotLimit, camRotLimit);

                //Apply Y axis rotation
                cam.transform.localEulerAngles = new Vector3(currentCamRotX, 0f ,0f);
            }

            StaminaBar.value = PlayerCurrentStamina;
        }
    }

    private void LateUpdate()
    {
        enemyAI = FindObjectOfType<EnemyAI>().gameObject;
        enemyGFX = enemyAI.transform.GetChild(0).gameObject;
        
        if(enemyGFX == null) return;

        if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("1"))
        {
            enemyGFX.SetActive(true);
        }else 
        if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("3") ||
            this.gameObject.GetComponent<PlayerStatus>().name.Contains("4"))
        {
            enemyGFX.SetActive(false);
        }
        
        // Debug.Log($"{enemyAI.name}");
        
        // enemyGFX.SetActive(false);

        // if (isDisableVoiceChat) return;

        // if (!_view.IsMine) return;
        
        // isDisableVoiceChat = true;
    }

    // private void PushToTalk()
    // {
    //     if (Input.GetKey(KeyCode.V))
    //     {
    //         this.gameObject.GetComponent<Recorder>().TransmitEnabled = true;
    //         
    //         if(isPushToTalkable)
    //         {
    //             isPushToTalkable = false;
    //             // Debug.Log("isPushToTalkable : " +isPushToTalkable);
    //             // Debug.Log("Press counted!");
    //             //Watcher
    //             if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("1"))
    //             {
    //                 vcLogger.AddVCCountToP1();
    //             }
    //             //Runner A
    //             if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("4"))
    //             {
    //                 vcLogger.AddVCCountToP2();
    //             }
    //             //Runner B
    //             if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("3"))
    //             {
    //                 vcLogger.AddVCCountToP3();
    //             }
    //         }
    //         else if(isDisableVoiceChat)
    //         {
    //             isDisableVoiceChat = false;
    //         }
    //         // Debug.Log("Press V!!");
    //     }
    //     
    //     else if (!Input.GetKey(KeyCode.V))
    //     {
    //         this.gameObject.GetComponent<Recorder>().TransmitEnabled = false;
    //
    //         if(!isPushToTalkable)
    //         {
    //             isPushToTalkable = true;
    //         }
    //
    //         else if(!isDisableVoiceChat)
    //         {
    //             isDisableVoiceChat = true;
    //             // Debug.Log("Time saved!");
    //             // Debug.Log("isDisableVoiceChat : " +isDisableVoiceChat);
    //
    //             if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("1"))
    //             {
    //                 vcLogger.StopVCTimerToP1();
    //             }
    //             
    //             if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("4"))
    //             {
    //                 vcLogger.StopVCTimerToP2();
    //             }
    //             
    //             if (this.gameObject.GetComponent<PlayerStatus>().name.Contains("3"))
    //             {
    //                 vcLogger.StopVCTimerToP3();
    //             }
    //         }
    //         //Debug.Log("Unpress V!!");
    //     }
    // }

    PlayerEvent PlayerAnimationEvent = new PlayerEvent();
    public void playeranimationevent(UnityAction<int> listener)
    {
        PlayerAnimationEvent.AddListener(listener);
        //Debug.Log("Invoked!!");
    }

    void PlayerSpeedSet()
    {
     //   Vector3 flatVe1 = new Vector3(rb.velocity.x ,0f , rb.velocity.z);
        if(isrunable)
        {
            if (Input.GetKey(KeyCode.LeftShift)&& PlayerCurrentStamina >= 0)
            {
                playerMoveSpeed = playerRunSpeed;
                isrun = true;
                PlayerAnimationEvent.Invoke(2);
                foot1.enabled = false;
                foot2.enabled = true;

               /* if (flatVe1.magnitude > playerMoveSpeed)
                {
                    Vector3 limitedVe1 = flatVe1.normalized* playerMoveSpeed;
                    rb.velocity = new Vector3(limitedVe1.x,rb.velocity.y,limitedVe1.z);
                }*/
                // Debug.Log("Run!");
            }
            else if ((Input.GetKey(KeyCode.LeftShift) && PlayerCurrentStamina < 0))
            {
                playerMoveSpeed = playerWalkSpeed;
                isrun = false;
                isrunable = false;
                PlayerAnimationEvent.Invoke(1);
                StartCoroutine(runablecooldown());
                foot1.enabled = true;
                foot2.enabled = false;

               /* if (flatVe1.magnitude > playerMoveSpeed)
                {
                    Vector3 limitedVe1 = flatVe1.normalized * playerMoveSpeed;
                    rb.velocity = new Vector3(limitedVe1.x, rb.velocity.y, limitedVe1.z);
                }*/
                //Debug.Log("Out of stamina!");
            }
            else if (!Input.GetKey(KeyCode.LeftShift))
            {
                playerMoveSpeed = playerWalkSpeed;
                isrun = false;
                PlayerAnimationEvent.Invoke(1);
                foot1.enabled = true;
                foot2.enabled = false;

              /*  if (flatVe1.magnitude > playerMoveSpeed)
                {
                    Vector3 limitedVe1 = flatVe1.normalized * playerMoveSpeed;
                    rb.velocity = new Vector3(limitedVe1.x, rb.velocity.y, limitedVe1.z);
                }*/
                // Debug.Log("Walk!");
            }
        }
    }


    void Staminacontroller()
    {
        if (isrun == true)
        {
            PlayerCurrentStamina -= 2f * Time.deltaTime;
        }
        else if (isrun == false)
        {
            StaminaRegeneration();
        }
    }

    void StaminaRegeneration()
    {
        if (PlayerCurrentStamina <= PlayerMaxStamina)
        {
            PlayerCurrentStamina += 1f * Time.deltaTime;
        }
        else if (PlayerCurrentStamina > PlayerMaxStamina)
        {
            PlayerCurrentStamina = PlayerMaxStamina;
        }
    }

    IEnumerator runablecooldown()
    {
        yield return new WaitForSeconds(2.0f);
        isrunable = true;
    }

}
