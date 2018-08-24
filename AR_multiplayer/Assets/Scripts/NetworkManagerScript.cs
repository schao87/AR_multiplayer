using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerScript : MonoBehaviour {

    public Text ConnectionInfo;
	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("v01");
	}
	
	// Update is called once per frame
	void Update () {
        ConnectionInfo.text = PhotonNetwork.connectionStateDetailed.ToString();
	}

    void OnConnectedToServer()
    {
        Debug.Log("Connected with Lobby");
    }
}
