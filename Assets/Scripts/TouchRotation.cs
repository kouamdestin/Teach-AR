using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotation : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private Quaternion rotationY;
    // private Quaternion rotation;
    private float rotationSpeedModifier = 0.2f;

    void Update()
    {
        if(Input.touchCount > 0){
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved){
                //Code to only rotate on the Y axis (unity y axis = blender z axis)
                rotationY = Quaternion.Euler(0f,-touch.deltaPosition.x * rotationSpeedModifier,0f);
                transform.rotation = rotationY * transform.rotation;
                

                //code to rotate on both x and y
                // rotation = Quaternion.Euler(0f, -touch.deltaPosition.x * rotationSpeedModifier, touch.deltaPosition.y * rotationSpeedModifier);
                
                // transform.rotation = rotation * transform.rotation;
            }
        }
    }
}
