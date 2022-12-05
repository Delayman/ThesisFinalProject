using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnablePlayerControl : MonoBehaviour
{
    private List<DisablePlayerControl> DisAblePlayerlist;

    private void Awake()
    {
        DisAblePlayerlist = FindObjectsOfType<DisablePlayerControl>().ToList();
    }
    private void Start()
    {
        foreach (var player in DisAblePlayerlist)
        {
            player.isDisable = false;
        }
        
    }

    
}
