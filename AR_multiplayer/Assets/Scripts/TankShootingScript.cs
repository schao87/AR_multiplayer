using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class TankShootingScript : MonoBehaviour
{

    PhotonView view;
    private bool ShootBool = true;
    //public int force = 30;
    //public GameObject AmmoPrefab = null;

    // Use this for initialization
    void Start()
    {
        view = GetComponent<PhotonView>();
       
    }

    // Update is called once per frame
    void Update()
    {

        //view rpc (remote procedure call) allows us to send a method to all clients connected
        // shootBullet is the method
        // photonTargets.all sends it to all clients

        if ((view.isMine && (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButton("Fire"))) && ShootBool)
        {
            ShootBool = false;
            StartCoroutine(SetShootBool());
            //view.RPC("ShootBullet", PhotonTargets.All, transform.Find("ShootPosition").transform.position, transform.Find("ShootPosition").transform.rotation);
            view.RPC("ShootBullet", PhotonTargets.All);
        }

    }

    IEnumerator SetShootBool(){
        yield return new WaitForSeconds(1f);
        ShootBool = true;
    }
    //[PunRPC] void ShootBullet(Vector3 Pos, Quaternion quaat){
    //    GameObject GO = Instantiate(Bullet, Pos, quaat) as GameObject;
    //    GO.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * force);
    //}

    [PunRPC]void ShootBullet()
    {
        //Instantiate(AmmoPrefab, transform.position, transform.rotation);
        AmmoManager.SpawnAmmo(transform.position, transform.rotation);
      
    }
}
