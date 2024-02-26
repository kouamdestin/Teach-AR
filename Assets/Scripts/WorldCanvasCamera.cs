using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCanvasCamera : MonoBehaviour
{
    private Canvas canvas;
    //[SerializeField] 
    // Start is called before the first frame update
    void Start()
    {
        canvas = this.GetComponent<Canvas>();
        //canvas.worldCamera = Camera.current;
        //Debug.Log(Camera.current.gameObject.name);
        Invoke("SetUpEventCamera", 0.1f);
        
    }
    
    // Update is called once per frame
    private void SetUpEventCamera(){
        canvas.worldCamera = Camera.main;
    }
}
