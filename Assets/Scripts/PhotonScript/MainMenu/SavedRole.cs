using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedRole : MonoBehaviour
{
    public static int savedRoleID = 10;
    public static string roomName = "null";

    public void SavedRoleID(int _roleID)
    {
        savedRoleID = _roleID;
        
        // Debug.Log($"Value : {savedRoleID}");
    }
    
    public void SavedRoomName(string _roomName)
    {
        roomName = _roomName;
        
        // Debug.Log($"Value : {roomName}");
    }
}
