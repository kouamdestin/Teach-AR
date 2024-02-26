using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    void Update()
    {
        // Get the position of the mouse cursor in the game world.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Create a ray that extends from the camera to the mouse position.
        Ray ray = new Ray(Camera.main.transform.position, mousePosition);

        // Cast the ray and see if it collides with any objects in the scene.
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // The ray collided with an object.
            GameObject objectClicked = hit.collider.gameObject;

            // Do something with the object that was clicked.
            Debug.Log("Clicked on object: " + objectClicked.name);
        }
    }
}
