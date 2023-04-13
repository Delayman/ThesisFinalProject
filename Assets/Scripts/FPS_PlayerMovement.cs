using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Voice.Unity;
using Photon.Voice.PUN;
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
    public bool isDisableMoving;
    
    private PhotonView _view;
    private PhotonVoiceView voiceView;

    //Y axis limit cam rotation stuff
    [SerializeField]
    private float camRotLimit = 85f;
    private float currentCamRotX = 0f;

    Rigidbody rb;

    [SerializeField]
    private Camera cam;
    void Awake()
    {
        isrun = false;
        isrunable = true;
    }
    private void Start()
    {
        _view = GetComponent<PhotonView>();
        if (_view.IsMine)
        {
            //Finding Rigibody to move character
            rb = GetComponent<Rigidbody>();

            //Lock(cursor at middle screen) and Remove Cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StaminaBar = GameObject.FindGameObjectWithTag("StaminaBar").GetComponent<Slider>();

            this.gameObject.GetComponent<PhotonVoiceView>().RecorderInUse.TransmitEnabled = false;

        }

        if (!_view.IsMine)
        {
            cam.enabled = false;
        }

        isrun = false;

        StaminaBar.maxValue = PlayerMaxStamina;
        StaminaBar.value = PlayerCurrentStamina;
        
        // var audioSource = GetComponent<AudioSource>();
        // audioSource.enabled = false;
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

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Cursor.lockState = CursorLockMode.None;
                // Cursor.visible = true;
            }

            PushToTalk();

            StaminaBar.value = PlayerCurrentStamina;

        }
    
    }

    private void PushToTalk()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            this.gameObject.GetComponent<PhotonVoiceView>().RecorderInUse.TransmitEnabled = true;
        }
        
        if (Input.GetKeyUp(KeyCode.V))
        {
            this.gameObject.GetComponent<PhotonVoiceView>().RecorderInUse.TransmitEnabled = false;
        }
    }

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
