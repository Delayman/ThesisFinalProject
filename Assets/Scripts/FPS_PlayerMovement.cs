using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class FPS_PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerMoveSpeed = 5f;
    [SerializeField]
    private float playerLookSpeed = 5f;

    private PhotonView _view;

    //Y axis limit cam rotation stuff
    [SerializeField]
    private float camRotLimit = 85f;
    private float currentCamRotX = 0f;

    Rigidbody rb;

    [SerializeField]
    private Camera cam;
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
        }

        if (!_view.IsMine)
        {
            cam.enabled = false;
        }
    }

    private void FixedUpdate() 
    {
        if (_view.IsMine)
        {
            //Getting Input from keyboard
            float horizontalMove = Input.GetAxisRaw("Horizontal");
            float verticalMove = Input.GetAxisRaw("Vertical");

            //Calculate Movement speed
            Vector3 moveHorizontal = transform.right * horizontalMove;
            Vector3 moveVertical = transform.forward * verticalMove;

            Vector3 velocity = (moveHorizontal + moveVertical).normalized * playerMoveSpeed;

            //Apply moving speed
            if(velocity != Vector3.zero)
            {
                rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
            }

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
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

        }
    }
        
}
