using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InfoBehaviour : MonoBehaviour
{
    const float speed = 6.0f;
    [SerializeField] Transform sectionInfo; //object To scale linearly
    List<InfoBehaviour> infos = new List<InfoBehaviour>();

    Vector3 desiredscale = Vector3.zero;
    // Vector3 iniTialPos;
    // Vector3 finalpos;
    private void Start(){
        // iniTialPos = transform.position;
        // finalpos =  iniTialPos + new Vector3(0,1,0);
    }

    void Update()
    {
        sectionInfo.localScale = Vector3.Lerp(sectionInfo.localScale,desiredscale,Time.deltaTime * speed);
        //transform.position = Vector3.Lerp(iniTialPos,finalpos,Time.deltaTime * speed);
        
    }

    public void openInfo(){
        desiredscale = Vector3.one * 2;
        //
        //finalpos =  iniTialPos + new Vector3(0,1,0);
    }
    public void close(){
        desiredscale = new Vector3(0f,0f,0f);
        //
        //finalpos =  iniTialPos;
    }
    void OnMouseDown(){
        CloseAll();
        if(this.CompareTag("hasInfo")){
            openInfo(GetComponent<InfoBehaviour>());
                //here is good
        }
    }
    void openInfo(InfoBehaviour desiredinfo){
        infos = FindObjectsOfType<InfoBehaviour>().ToList();
    
        //here is good
        foreach(InfoBehaviour info in infos) {
            if(info == desiredinfo){
                //Debug.Log("==");
                info.openInfo();
            }else{
                //Debug.Log("!=");
                info.close();
            }
        }
    }
    void CloseAll(){
        infos = FindObjectsOfType<InfoBehaviour>().ToList();

        foreach(InfoBehaviour info in infos) {
            info.close();
        }
    }
}
