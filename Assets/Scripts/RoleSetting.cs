using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleSetting : MonoBehaviour
{
    public string roleName;
    private void Start()
    {
        roleName ??= "null";
    }
}
