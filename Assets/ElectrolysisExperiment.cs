using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElectrolysisExperiment : MonoBehaviour
{
    [SerializeField] private TMP_Text status;
    [SerializeField] private GameObject metal1;
    [SerializeField] private GameObject metal2;
    Animator animator;
    private int value = 0;
    private float repeatRate= 0.1f;

    void Start(){
        value = 0;
        animator = GetComponent<Animator>();
        status.text = "Not Running";
        status.color = Color.blue;
    }

    public void PerformElectrolysis()
    {
        
        animator.SetBool("animate", true);

        InvokeRepeating("PerformOperationonMetals",1.0f,repeatRate);
    }

    private void PerformOperationonMetals(){
        if(value <= 99){
            value += 1;
            status.text = "Running";
            status.color = Color.red;

            metal1.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,value);
            metal2.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,value);
        }else{
            CancelInvoke("PerformOperationonMetals");
            status.text = "Finished";
            status.color = Color.green;
            animator.SetBool("animate", false);
        }
        
    }
    public void ResartExperiement(){
        metal1.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,0);
        metal2.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0,0);
        status.text = "Not Running";
        status.color = Color.blue;
        value = 0;
        
    }
}
