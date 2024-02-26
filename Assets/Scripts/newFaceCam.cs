using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newFaceCam : MonoBehaviour
{
    // Start is called before the first frame update
    Transform cam;
    Vector3 targetAngle = Vector3.zero;
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam);
        targetAngle = transform.localEulerAngles;
        targetAngle.y = -90;
        targetAngle.z = -90;

        transform.localEulerAngles = targetAngle;
    }
}
