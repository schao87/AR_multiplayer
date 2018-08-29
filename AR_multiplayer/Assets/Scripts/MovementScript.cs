using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour {
    public float rotateSpeed = 5f;
    public float moveSpeed = 2f;

    PhotonView view;

	// Use this for initialization
	void Start () {
        view = GetComponent<PhotonView>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if(view.isMine){
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
        }

	}
}
