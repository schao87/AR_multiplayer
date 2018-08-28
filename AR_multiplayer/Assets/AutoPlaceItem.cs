using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARSessionOrigin))]
public class AutoPlaceItem : MonoBehaviour {
  
    public GameObject GameObjectToPlace;
    public LayerMask layerMask;
    public GameObject[] TestingGround;
    public float speed = .5f;
    public bool isPlaced = false;

    ARSessionOrigin m_SessionOrigin;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    void Awake()
    {
        m_SessionOrigin = GetComponent<ARSessionOrigin>();

        //checks if game is in editor or running as. turns off fake plane when running as app
        if(Application.isEditor){
            for (int i = 0; i < TestingGround.Length; i++)
            {
                TestingGround[i].SetActive(true);
            }
        }else{
            for (int i = 0; i < TestingGround.Length; i++)
            {
                TestingGround[i].SetActive(false);
            }
        }
    }

    public void GameCode(Vector3 NewPos){
        isPlaced = true;
        GameObjectToPlace.transform.localScale = new Vector3(1,1,1);
        GameObjectToPlace.transform.SetParent(null);
        GameObjectToPlace.transform.position = Vector3.Lerp(GameObjectToPlace.transform.position, NewPos, Time.deltaTime * speed);


        if (!GameObjectToPlace.activeSelf){
            GameObjectToPlace.SetActive(true);
        }
    }

    private void Start()
    {
        //sets main camera in position to see fake AR plane
        Camera.main.transform.position = new Vector3(0, 8, -10);
    }
    void Update()
    {
        if(Application.isEditor){
            //raycast casting to the center of the screen

            Vector3 camRay = new Vector3(Camera.main.pixelWidth * .5f, Camera.main.pixelHeight * .5f, 0f);
            Ray ray = Camera.main.ScreenPointToRay(camRay);
            RaycastHit hit;

            //sets up a fake plane in the editor so immitate AR plane
            if (Physics.Raycast(ray, out hit, 500f, layerMask)){
                GameCode(hit.point);
                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
                GameObjectToPlace.transform.rotation = Quaternion.identity;
            }
        }else{
            //set up the real plane when running on ipad
            if (m_SessionOrigin.Raycast(Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0f)), s_Hits, TrackableType.PlaneWithinPolygon)){
                Pose hitPose = s_Hits[0].pose;
                GameCode(hitPose.position);
                GameObjectToPlace.transform.rotation = hitPose.rotation;
            }
        }

        //places gameobject back into camera when camera is not facing a plane
        if(isPlaced == false){
            GameObjectToPlace.transform.parent = Camera.main.transform;
            GameObjectToPlace.transform.localPosition = Vector3.zero;
        }

        isPlaced = false;

    }
}
