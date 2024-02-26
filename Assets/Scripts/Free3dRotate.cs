using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Free3dRotate : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationY;
    private Quaternion rotation;
    private float rotationSpeedModifier = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved){
                

               // code to rotate on both x and y
                rotation = Quaternion.Euler(touch.deltaPosition.y * rotationSpeedModifier, -touch.deltaPosition.x * rotationSpeedModifier, 0);
                
                transform.rotation = rotation * transform.rotation;
            }
        }
    }
}
