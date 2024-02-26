using UnityEngine;

public class Grabber : MonoBehaviour {


    private Vector3 initialPos = Vector3.zero;
    bool firstTime = true;
    private GameObject selectedobject;
    private GameObject refobject;

    private void Start(){
        Cursor.visible = true;
    }
    private void Update(){
        
        if(Input.GetMouseButtonDown(0)){

            if(selectedobject == null){
                RaycastHit hit = CastRay();
                
                if(hit.collider != null){ //we've hit something 
                    if(!hit.collider.CompareTag("drag")){  // is the tag of the object hit is not drag
                        return; // do nothing 
                    }

                    if(firstTime == true){  // if after reset or at beginning, there's not yet a selected gameobject clicked
                        selectedobject = hit.collider.gameObject; // asign the gameobject clicked to selectedobject 
                        //
                        initialPos = selectedobject.transform.position;  //assign variables 
                        refobject = selectedobject;
                        firstTime = false;
                        //
                        Cursor.visible = false;
                    }
                }
            }else{
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedobject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                //selectedobject.transform.position = new Vector3(worldPosition.x, 0f, worldPosition.z);
                selectedobject.transform.position = new Vector3(worldPosition.x, initialPos.y, worldPosition.z);

                selectedobject = null;
                Cursor.visible = true;
            }

        if(refobject != selectedobject){
            //firstTime = true;
        }


            // if(firstTime == true){
            //     if(selectedobject == null)
            //     {
            //         selectedobject = new GameObject("go");
            //         selectedobject.transform.position = Vector3.zero;
            //     }
            //     initialPos = selectedobject.transform.position;
            //     refobject = selectedobject;
            //     firstTime = false;
            //     Destroy(selectedobject);
                
            // }
            // //print(initialPos);


        }
        
        if(refobject == null && selectedobject == null){
            return;
        }else{
            if(refobject != selectedobject){
                firstTime = true;
            }
        }

    
        if(selectedobject != null){
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedobject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position); 
            //selectedobject.transform.position = new Vector3(worldPosition.x, 0.25f , worldPosition.z);
            selectedobject.transform.position = new Vector3(worldPosition.x, initialPos.y , worldPosition.z);

            if(Input.GetMouseButtonDown(1)) {
                selectedobject.transform.rotation = Quaternion.Euler(new Vector3(
                    selectedobject.transform.rotation.eulerAngles.x,
                    selectedobject.transform.rotation.eulerAngles.y + 90f,
                    selectedobject.transform.rotation.eulerAngles.z
                ));
            }
        }
    
    }

    private RaycastHit CastRay(){
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane
        );
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane
        );

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);
        return hit;
    }
}