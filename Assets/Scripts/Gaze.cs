using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    List<InfoBehaviour> infos = new List<InfoBehaviour>();
    void Start()
    {
        // 
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position,transform.forward, out RaycastHit hit)){
            GameObject go = hit.collider.gameObject;
            //here is good
            if(go.CompareTag("hasInfo")){
                openInfo(go.GetComponent<InfoBehaviour>());
                //here is good
            }
        }
        else{
            CloseAll();
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


//The original gaze script
// public class Gaze : MonoBehaviour
// {
//     List<InfoBehaviour> infos = new List<InfoBehaviour>();
//     void Start()
//     {
//         infos = FindObjectsOfType<InfoBehaviour>().ToList();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(Physics.Raycast(transform.position,transform.forward, out RaycastHit hit)){
//             GameObject go = hit.collider.gameObject;
//             //here is good
//             if(go.CompareTag("hasInfo")){
//                 openInfo(go.GetComponent<InfoBehaviour>());
//                 //here is good
//             }
//         }else{
//             CloseAll();
//         }
//     }

//     void openInfo(InfoBehaviour desiredinfo){
//         //here is good
//         foreach(InfoBehaviour info in infos) {
//             if(info == desiredinfo){
//                 Debug.Log("==");
//                 info.openInfo();
//             }else{
//                 Debug.Log("!=");
//                 info.close();
//             }
//         }
//     }
//     void CloseAll(){
//         foreach(InfoBehaviour info in infos) {
//             info.close();
//         }
//     }
// }
