using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brownianMotion : MonoBehaviour
{
    public int xrange1 = 3;
    public int xrange2 = 3;
    public int yrange1 = 3;
    public int yrange2 = 3;
    public int zrange1 = 3;
    public int zrange2 = 3;
    private bool started;
    void Start()
    {
        started = true;
    }

    void Update()
    {
        if(started == false){
            return;
        }else{
            StartSimulation();
        }
    }

    public void StartSimulation(){
        started = true;
        transform.position = new Vector3(Random.Range(xrange1,xrange2),Random.Range(yrange1,yrange2),Random.Range(zrange1,zrange2));
    }
    public void stopSimulation(){
        started = false;
    }
}
