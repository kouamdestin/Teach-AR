using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;


public class ARPlacementURP : MonoBehaviour
{
    [Header ("Sliders")]
    [SerializeField] private Slider scaleslider;
    [SerializeField] private Slider ySlider;


    public static event Action spawn;
    public static event Action unspawn;

    [Header ("AR Gameobjects")]
    public ARSessionOrigin sessionOrigin;
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private GameObject spawnedObject;
    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementPoseIsValid = false;

    [Header ("initialValues")]
    private float initialScale;
    private float initialyposition;
    private float scale_Coeficient = 1.0f;
    private float y_Coeficient = 1.0f;


    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        //spawnedObject = Instantiate(arObjectToSpawn,PlacementPose.position, PlacementPose.rotation);

        scaleslider.onValueChanged.AddListener (AdjustScale);
        ySlider.onValueChanged.AddListener (Adjustposition);

        scale_Coeficient = ySlider.value/10;

        initialyposition = 0.0f;
        initialScale = 0.0f;
    }
 
    void Update()
    {
        if(spawnedObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            ARRPlaceObject();
        }
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    private void UpdatePlacementIndicator(){
        if(spawnedObject == null && placementPoseIsValid){
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }else{
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose(){
        Vector3 screenCenter = sessionOrigin.camera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if(placementPoseIsValid){
            PlacementPose = hits[0].pose;
            var cameraFoward = sessionOrigin.camera.transform.forward;
            var cameraOrientation = new Vector3(cameraFoward.x, 0, cameraFoward.z).normalized;
            PlacementPose.rotation = Quaternion.LookRotation(cameraOrientation);
        }
    } 

    void ARRPlaceObject(){
        spawnedObject = Instantiate(arObjectToSpawn,PlacementPose.position, PlacementPose.rotation);
        //spawnedObject.tag = "hasinfo";

        //update initial values
        initialScale = spawnedObject.transform.localScale.x;
        initialyposition = spawnedObject.transform.position.y;

        spawn?.Invoke();
    }

    public void AR_unPlace_object(){
        
        if(spawnedObject == null){
            Debug.Log("null unplace");
            //exception();
            return;
        }else{
            
            GameObject.Find("Controller").GetComponent<ARPlacementURP>().destroyObject();
        }
    }
    public void destroyObject(){
        Destroy(spawnedObject);
        unspawn?.Invoke();
    }

    public void AdjustScale(float scale){
        scale_Coeficient = scale/10;
        
        if(spawnedObject == null){
            //Debug.Log(scale);
            //exception();
            return;
        }else{
            spawnedObject.transform.localScale = new Vector3(initialScale,initialScale,initialScale) * scale_Coeficient;
        }
        
    }
    public void Adjustposition(float y){
        
        if(spawnedObject == null){
            //Debug.Log(y);
            //exception();
            return;
        }else{
            y_Coeficient = y-10;
            spawnedObject.transform.position = new Vector3(transform.position.x,transform.position.y + y_Coeficient,transform.position.z);
        }
    }
    public void ResetAdjustment(){
        //Arrange the slider to fit resetted value
        ySlider.value = 10;
        scaleslider.value = 10;

        if(spawnedObject == null){
            return;
        }else{
            spawnedObject.transform.localScale = new Vector3(initialScale,initialScale,initialScale);
            spawnedObject.transform.position = new Vector3(transform.position.x,initialyposition,transform.position.z);
            spawnedObject.transform.Find("Parts").transform.gameObject.SetActive(true);
 
        }
    }

    public void DisplayParts(bool condition){
        if(spawnedObject == null){
            Debug.Log(condition);
            //exception();
            return;
        }else{
            spawnedObject.transform.Find("Parts")?.transform.gameObject.SetActive(condition);
        }
        
    }
    public GameObject returnSpwanedObject(){
        
        return spawnedObject;
    }
    

}
