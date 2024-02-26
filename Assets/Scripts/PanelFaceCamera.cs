using UnityEngine;

[ExecuteInEditMode]
public class PanelFaceCamera : MonoBehaviour
{
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
        targetAngle.y = 0;
        targetAngle.x = 0;

        transform.localEulerAngles = targetAngle;
    }
}
