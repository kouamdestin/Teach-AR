using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TpSceneManager : MonoBehaviour
{
    public GameObject ObjectToSpawn;

    [SerializeField] private Slider slider;
    [SerializeField] private List<GameObject> defaultobjects = new List<GameObject>();
    [SerializeField] private List<GameObject> Arobjects = new List<GameObject>();
    float initial_Scale_Value = 1.0f;
    private float coef = 1.0f;

    void Start(){
        //just modified // slider.value = ObjectToSpawn.transform.localScale.x;
        
        initial_Scale_Value = ObjectToSpawn.transform.localScale.x;

        slider?.onValueChanged.AddListener (Adjustscale);
    }



    // Update is called once per frame
    public void SwitchToAR(){

        foreach(GameObject obj in Arobjects){
            obj.SetActive(true);
        }

        foreach(GameObject obj in defaultobjects){
            obj.SetActive(false);
        }
        
    }
    public void SwitchTodefault(){
        GameObject.Find("Controller").GetComponent<ARPlacementURP>().destroyObject();
        foreach(GameObject obj in Arobjects){
            obj.SetActive(false);
        }

        foreach(GameObject obj in defaultobjects){
            obj.SetActive(true);
        }
        
    }
    public void backtohome(){
        SceneManager.LoadSceneAsync("Welcome");
    }

    public void Adjustscale(float arg){
        coef = arg/10;
        ObjectToSpawn.transform.localScale = new Vector3(initial_Scale_Value,initial_Scale_Value,initial_Scale_Value) * coef;
    }

    public void displayParts(bool condition){
        ObjectToSpawn.transform.Find("Parts")?.gameObject.SetActive(condition);
    }


}
