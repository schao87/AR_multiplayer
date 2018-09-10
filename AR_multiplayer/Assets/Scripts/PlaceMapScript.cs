using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;

public class PlaceMapScript : MonoBehaviour
{
    public GameObject MultiplayerBtn;
    public GameObject PlaceMapBtn;
    public GameObject ResetMapBtn;
    public GameObject ARSessionOrigin;
    //public GameObject FeatheredPlane;
    // Use this for initialization

    public void OnClickPlaceMapBtn()
    {
        //var SessionOrigin = GameObject.FindGameObjectsWithTag("ARSessionOrigin");

        ARSessionOrigin.GetComponent<ARPlaneManager>().enabled = false;
        ARSessionOrigin.GetComponent<AutoPlaceItem>().enabled = false;
        ARSessionOrigin.GetComponent<ARPointCloudManager>().enabled = false;
        MultiplayerBtn.SetActive(true);
        PlaceMapBtn.SetActive(false);
        ResetMapBtn.SetActive(true);

        if (!Application.isEditor)
        {
            var FeatheredPlane = GameObject.FindGameObjectWithTag("FeatheredPlane");
            var PointCloud = GameObject.FindGameObjectWithTag("PointCloud");

            FeatheredPlane.SetActive(false);
            PointCloud.SetActive(false);
        }
    }

    public void OnClickResetMap()
    {
        PlaceMapBtn.SetActive(true);
        ResetMapBtn.SetActive(false);
       
        ARSessionOrigin.GetComponent<ARPlaneManager>().enabled = true;
        ARSessionOrigin.GetComponent<AutoPlaceItem>().enabled = true;
        ARSessionOrigin.GetComponent<ARPointCloudManager>().enabled = true;

        if (!Application.isEditor)
        {
            var FeatheredPlane = GameObject.FindGameObjectWithTag("FeatheredPlane");
            var PointCloud = GameObject.FindGameObjectWithTag("PointCloud");

            FeatheredPlane.SetActive(true);
            PointCloud.SetActive(true);
        }
    }
}
