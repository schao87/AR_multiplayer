using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {
    public int health = 100;
    PhotonView view;
    Text HealthTxt;
    Text EnemyHealthTxt;
	// Use this for initialization
	void Start () {
        view = GetComponent<PhotonView>();
        //HealthTxt = GameObject.Find("HealthTxt").GetComponent<Text>();
        //EnemyHealthTxt = GameObject.Find("EnemyHealthTxt").GetComponent<Text>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet" && view.isMine){
            health -= 10;
            //view.RPC("damageOther", PhotonTargets.Others, health);
        }
    }

    [PunRPC] void destroyGA(){
        Destroy(gameObject);
    }

    //[PunRPC]void damageOther(int health){
        
    //}
    // Update is called once per frame
    void Update () {
        if(health <= 0){
            view.RPC("destrayGA", PhotonTargets.All);
        }
	}
}
