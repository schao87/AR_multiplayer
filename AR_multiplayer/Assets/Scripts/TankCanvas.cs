using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankCanvas : MonoBehaviour {
    public Text playerName;
    PhotonView view;
	// Use this for initialization
	void OnEnable () {
        view = GetComponent<PhotonView>();
        if (view.isMine)
        {
            playerName.text = "Tank 1";
        }
        else
        {
            playerName.text = "Enemy";
        }


    }
	
	// Update is called once per frame
	void Update () {
       

        Camera cam = Camera.main;
        //makes canvas face main camera
        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
    }
}
