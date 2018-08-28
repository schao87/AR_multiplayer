using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerScript : MonoBehaviour {

    public Text ConnectionInfo;
    public int MaxJoinedPlayers = 4;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public Transform SpawnPoint3;
    public Transform SpawnPoint4;
    public GameObject GamePlane;
    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings("v01");
	}
	
	// Update is called once per frame
	void Update () {
        if (PhotonNetwork.connectionStateDetailed.ToString() != "Joined"){
            ConnectionInfo.text = PhotonNetwork.connectionStateDetailed.ToString();
        }else{
            ConnectionInfo.text = "Connected to: " + PhotonNetwork.room.Name + " Players Online: " + PhotonNetwork.room.PlayerCount;
        }
       
	}

    void OnConnectedToMaster()
    {
        Debug.Log("Connected with Master");
        PhotonNetwork.JoinLobby();
    }

    void OnJoinedLobby(){
        Debug.Log("Connected with Lobby");

        RoomOptions MyRoomOptions = new RoomOptions();
        MyRoomOptions.MaxPlayers = (byte)MaxJoinedPlayers;

        PhotonNetwork.JoinOrCreateRoom("Room1", MyRoomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom(){

        if(PhotonNetwork.playerList.Length == 1){
            StartCoroutine(SpawnMyPlayer());
        }else{
            StartCoroutine(SpawnMyPlayer2());
        }

    }

    IEnumerator SpawnMyPlayer(){
        yield return new WaitForSeconds(1);
        GameObject MyPlayer = PhotonNetwork.Instantiate("Tank", SpawnPoint1.position, Quaternion.identity, 0) as GameObject;
        MyPlayer.transform.parent = GamePlane.transform;
    }

    IEnumerator SpawnMyPlayer2()
    {
        yield return new WaitForSeconds(1);
        GameObject MyPlayer = PhotonNetwork.Instantiate("Tank", SpawnPoint1.position, Quaternion.identity, 0) as GameObject;
        MyPlayer.transform.parent = GamePlane.transform;
    }
}
