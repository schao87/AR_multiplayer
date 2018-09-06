using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosionScript : MonoBehaviour {
    PhotonView view;
    public GameObject Explosion;
	// Use this for initialization
	void Start () {
        view = GetComponent<PhotonView>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(view.isMine){
            //turn off collider once collided
            GetComponent<MeshCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            GameObject explosion = PhotonNetwork.Instantiate("Explosion", transform.position, Quaternion.identity, 0) as GameObject;
        }
    }
}
