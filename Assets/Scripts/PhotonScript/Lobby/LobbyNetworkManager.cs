using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LobbyNetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField roomInput;
    [SerializeField] private RoomItemUI roomUIPrefab;
    [SerializeField] private Transform roomListParent;

    [SerializeField] private RoomItemUI playerItemUIPrefab;
    [SerializeField] private Transform playerListParent;

    [SerializeField] private TextMeshProUGUI statusField;
    [SerializeField] private Button leaveRoomBtn;
    [SerializeField] private Button startGameBtn;

    [SerializeField] private TextMeshProUGUI roomText;
    [SerializeField] private TMP_Dropdown roleDropDown;

    [SerializeField] private GameObject Lobby_UI;
    [SerializeField] private GameObject Room_UI;

    private List<RoomItemUI> roomList = new List<RoomItemUI>();
    private List<RoomItemUI> playerList = new List<RoomItemUI>();


    private void Start()
    {
        Init();
        Connect();
        Lobby_UI.SetActive(true);
        Room_UI.SetActive(false);
    }

    #region PhotonCallbacks

    public override void OnConnectedToMaster()
    {
        statusField.text = "Connecting to master...";
        roomText.text = "Room list :";
        Debug.Log($"Connected to master server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        roomText.text = "Room list :";
        UpdateRoomList(roomList);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        roomText.text = "Disconnected";
        Debug.Log($"Disconnected");
    }

    public override void OnJoinedLobby()
    {
        statusField.text = "In lobby";
        roomText.text = "Room list :";
        Debug.Log($"Joined lobby");
    }

    public override void OnJoinedRoom()
    {
        statusField.text = "Joined";
        roomText.text = "Room : " + PhotonNetwork.CurrentRoom.Name;
        
        playerListParent.gameObject.SetActive(true);
        roomListParent.gameObject.SetActive(false);
        
        Debug.Log($"Joined room : {PhotonNetwork.CurrentRoom.Name}");

        if (PhotonNetwork.IsMasterClient)
        {
            startGameBtn.interactable = true;
        }
        else
        {
            startGameBtn.gameObject.SetActive(false);
        }
        
        leaveRoomBtn.interactable = true;
        startGameBtn.gameObject.SetActive(true);
        
        Lobby_UI.SetActive(false);
        Room_UI.SetActive(true);
        
        var _tempObj = new GameObject();
        _tempObj.AddComponent<SavedRole>();
        _tempObj.name = "Saved role ID";
        DontDestroyOnLoad(_tempObj);

        _tempObj.GetComponent<SavedRole>().SavedRoleID(roleDropDown.value);

        UpdatePlayerList();
    }

    public override void OnLeftRoom()
    {
        statusField.text = "In lobby";
        roomText.text = "Room list :";
        
        playerListParent.gameObject.SetActive(false);
        roomListParent.gameObject.SetActive(true);
        Debug.Log($"Left room");
        
        leaveRoomBtn.interactable = false;
        startGameBtn.gameObject.SetActive(false);
        
        Lobby_UI.SetActive(true);
        Room_UI.SetActive(false);

        UpdatePlayerList();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    #endregion

    private void Init()
    {
        leaveRoomBtn.interactable = false;
    }
    private void Connect()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(0, 500);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void UpdateRoomList(List<RoomInfo> _roomList)
    {
        foreach (var roomItem in roomList)
        {
            Destroy(roomItem.gameObject);
        }

        roomList.Clear();

        foreach (var roomInfo in _roomList)
        {
            if(roomInfo.PlayerCount == 0) continue;

            var newRoomItem = Instantiate(roomUIPrefab);
            newRoomItem.LobbyNetworkParent = this;
            newRoomItem.SetName(roomInfo.Name);
            newRoomItem.transform.SetParent(roomListParent);
            
            roomList.Add(newRoomItem);
        }
    }

    private void UpdatePlayerList()
    {
        foreach (var roomItem in playerList)
        {
            Destroy(roomItem.gameObject);
        }

        playerList.Clear();
        
        if(PhotonNetwork.CurrentRoom == null) {return;}
        
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            var newplayerItem = Instantiate(playerItemUIPrefab);
            
            newplayerItem.transform.SetParent(playerListParent);
            newplayerItem.SetName(player.Value.NickName);

            playerList.Add(newplayerItem);
        }
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomInput.text) == false)
            PhotonNetwork.CreateRoom(roomInput.text, new RoomOptions() { MaxPlayers = 3 }, null);
    }

    public void JoinRoom(string roomNameText)
    {
        PhotonNetwork.JoinRoom(roomNameText);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void OnPressedBackToMenu()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    
    public void OnPressedStartGame()
    {
        startGameBtn.gameObject.SetActive(false);
        PhotonNetwork.LoadLevel("Scenes/Lab_Map2");
    }

    public void OnchangeValue()
    {
        var _tempObj = GameObject.Find("Saved role ID");
        
        // Debug.Log($"Slider : {_tempObj}");
        _tempObj.GetComponent<SavedRole>().SavedRoleID(roleDropDown.value);
    }
}
