using UnityEngine;

public class Rotatetor1 : MonoBehaviour
{    
    public float speed = 5.0f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0,speed * Time.deltaTime,0 );
    }
}
