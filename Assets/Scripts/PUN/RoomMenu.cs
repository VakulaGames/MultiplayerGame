using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class RoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField _inputFieldRoomName;
    [SerializeField] private int _maxPlayer;
    [SerializeField] private Button _createRoomButton;
    [SerializeField] private Button _joinRoomButton;
    [SerializeField] private Button _errorPanel;

    public override void OnEnable()
    {
        base.OnEnable();

        _createRoomButton  .onClick.AddListener(CreateRoom);
        _joinRoomButton    .onClick.AddListener(JoinRoom);
        _errorPanel        .onClick.AddListener(()=> _errorPanel.gameObject.SetActive(false));
    }

    public override void OnDisable()
    {
        base.OnDisable();

        _createRoomButton   .onClick.RemoveListener(CreateRoom);
        _joinRoomButton     .onClick.RemoveListener(JoinRoom);
        _errorPanel         .onClick.RemoveListener(() => _errorPanel.gameObject.SetActive(false));
    }

    public void CreateRoom()
    {
        if(_inputFieldRoomName.text.Length > 3)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = _maxPlayer;
            PhotonNetwork.CreateRoom(_inputFieldRoomName.text, roomOptions);
        }
        else
        {
            _errorPanel.gameObject.SetActive(true);
        }
    }

    public void JoinRoom()
    {
        if (_inputFieldRoomName.text.Length > 3)
        {
            PhotonNetwork.JoinRoom(_inputFieldRoomName.text);
        }
        else
        {
            _errorPanel.gameObject.SetActive(true);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("LobbyScene");
    }
}
