using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MovementScript : MonoBehaviour {
    public float rotateSpeed = 5f;
    public float moveSpeed = 2f;

    PhotonView view;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        view = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if(view.isMine){

            //pc control
            var x = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
            var z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);

            //mobile control
            float xValue = CrossPlatformInputManager.GetAxis("Horizontal");
            float yValue = CrossPlatformInputManager.GetAxis("Vertical");

            Vector3 movement = new Vector3(xValue, 0, yValue);
            rb.velocity = movement * moveSpeed;

            if(xValue !=0 && yValue !=0){
                //make tank face wherever you move joystick
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xValue, yValue) * Mathf.Rad2Deg, transform.eulerAngles.z);

            }
        }

	}
}
