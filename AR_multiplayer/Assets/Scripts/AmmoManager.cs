using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour {
    public GameObject AmmoPrefab = null;

    public int PoolSize = 20;

    private GameObject[] AmmoArray;

    public static AmmoManager AmmoManagerSingleton = null;

    public Queue<Transform> AmmoQueue = new Queue<Transform>();

	void Awake () {
        if(AmmoManagerSingleton != null){
            DestroyImmediate(gameObject);
            return;
        }

        AmmoManagerSingleton = this;
	}
	
    void Start(){
        //create new game object of size Poolsize 
        AmmoArray = new GameObject[PoolSize];

        for (int i = 0; i < PoolSize; i++){
            AmmoArray[i] = Instantiate(AmmoPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            //make ammo child of ammo array
            Transform ObjTransform = AmmoArray[i].GetComponent<Transform>();
            ObjTransform.parent = transform;

            AmmoQueue.Enqueue(ObjTransform);
            AmmoArray[i].SetActive(false);
        }

    }
    public static Transform SpawnAmmo(Vector3 Position, Quaternion Rotation){
        Transform SpawnedAmmo = AmmoManagerSingleton.AmmoQueue.Dequeue(); //removes ammo from queue
        SpawnedAmmo.gameObject.SetActive(true); //enable object to make it visible
        SpawnedAmmo.position = Position;
        SpawnedAmmo.rotation = Rotation;

        AmmoManagerSingleton.AmmoQueue.Enqueue(SpawnedAmmo); //adds ammo object back to the end of queue

        return SpawnedAmmo; //return reference to SpawnedAmmo transform in case any other function needs access to the ammo object that has been generated
    }
}
