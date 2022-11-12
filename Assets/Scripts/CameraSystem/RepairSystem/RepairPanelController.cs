using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RepairPanelController : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttonList;

    public void DisableAllButton()
    {
        foreach (var _btn in buttonList)
        {
            _btn.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void EnableAllButton()
    {
        foreach (var _btn in buttonList)
        {
            _btn.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
