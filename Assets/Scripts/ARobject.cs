using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARobject : MonoBehaviour
{
    private float doubleTapThreshold = 0.2f; // The time in seconds between two taps to be considered a double tap.
    private float lastTapTime = 0.0f;
    
    private float firstTapTime = 0.0f;
    private float doubletaptime = 0.0f;
    
    private bool firsttap, secondtap;
    private  int numberofTap = 0;

    private Animator animator;
    bool animate = false;
    private GameObject parts;


    private void Start(){
        animator = GetComponent<Animator>();
        parts = transform.Find("Parts").gameObject;
        numberofTap = 0;
        firsttap = false;
        secondtap = false;
    }

    private void Update()
    {
        if(Time.time - firstTapTime > 0.3){
            ResetDoubleTap();
        }

        
        if (Input.GetMouseButtonDown(0)){
            doubleTap();
        }
    }

    private void ResetDoubleTap(){
        firstTapTime = 0.0f;
        lastTapTime = 0.0f;
        firsttap = false;
        secondtap = false;
        numberofTap = 0;
    }

    public void doubleTap(){
        //Debug.Log(Time.time);
        numberofTap += 1;
        //Debug.Log("here is the number of taps " + numberofTap);

        if(firsttap == false && firstTapTime == 0.0f){
            firstTapTime = Time.time;
            firsttap = true;
        }
        

        if(numberofTap == 2 && firsttap == true ){
            secondtap = true;
            lastTapTime = Time.time;
            doubletaptime = lastTapTime - firstTapTime;
            if(doubletaptime > 0.25){
                //start all over
                ResetDoubleTap();
            }
            if(doubletaptime < doubleTapThreshold && doubletaptime > 0.0f){

                animate = !animate;
                animator.SetBool("animate", animate);
                parts.SetActive(!animate);


                Debug.Log("we doubled tap");
                ResetDoubleTap();
            }
            ResetDoubleTap();
        }
        if(numberofTap >= 3){
            ResetDoubleTap();
        }
    }
}
