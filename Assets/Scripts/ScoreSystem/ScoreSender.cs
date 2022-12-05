using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSender : MonoBehaviour
{
    public static int scoreToBeSend;
    
    public void SavedScore(int _roleID)
    {
        scoreToBeSend = _roleID;
    }
    
}
