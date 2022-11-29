using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class MicPermissionHelper : MonoBehaviour
{
    private void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }
    
}
