using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roomName;
    public LobbyNetworkManager LobbyNetworkParent;

    public void SetName(string _roomName)
    {
        roomName.text = _roomName;
    }

    public void OnJoinPressed()
    {
        LobbyNetworkParent.JoinRoom(roomName.text);
    }
}
