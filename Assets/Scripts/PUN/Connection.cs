using UnityEngine.SceneManagement;
using Photon.Pun;

public class Connection : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
