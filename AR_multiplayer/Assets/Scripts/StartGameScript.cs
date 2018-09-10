using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour {
    public Button MultiplayerButton;
    public GameObject NetworkManagerObject;
    public NetworkManagerScript NMS;
    public GameObject ResetPositionBtn;
    //public GameObject Panel;
    // Use this for initialization


    //THIS SCRIPT LOCATED IN CANVAS
    void Start () {

        MultiplayerButton.onClick.AddListener(StartGameFunc);

        //hides muliplayer button on start
        MultiplayerButton.gameObject.SetActive(false);
	}

    private void Update(){
        if (NMS.gameStarted == true){
            MultiplayerButton.gameObject.SetActive(false);
        }
    }
    void StartGameFunc(){

        ResetPositionBtn.SetActive(false);
       
        NetworkManagerObject.SetActive(true);
        Debug.Log("btn pressed");
    }
}
