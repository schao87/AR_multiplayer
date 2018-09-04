using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameScript : MonoBehaviour {
    public Button MultiplayerButton;
    public GameObject NetworkManagerObject;
    public NetworkManagerScript NMS;
    //public GameObject Panel;
    // Use this for initialization
    void Start () {

        MultiplayerButton.onClick.AddListener(StartGameFunc);
        MultiplayerButton.gameObject.SetActive(false);
	}

    private void Update(){
        if (NMS.gameStarted == true){
            MultiplayerButton.gameObject.SetActive(false);
        }
    }
    void StartGameFunc(){

        //MultiplayerButton.gameObject.SetActive(false);
       
        NetworkManagerObject.SetActive(true);
        Debug.Log("btn pressed");
    }
}
