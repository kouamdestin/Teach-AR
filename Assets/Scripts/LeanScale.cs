using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanScale : MonoBehaviour
{
    [SerializeField] private Vector3 scaleVector = Vector3.one;
    [SerializeField] private float _Time_toComplete;
    [SerializeField] private float _duration;
    //[SerializeField] private float _delay = 0.0f;
    [SerializeField] private LeanTweenType Animtype = LeanTweenType.easeOutElastic;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.scale(this.gameObject,scaleVector, _Time_toComplete).
        setDelay(_duration).
        setEase(Animtype);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable()
    {
        LeanTween.scale(this.gameObject,scaleVector, _Time_toComplete).
        setDelay(_duration).
        setEase(LeanTweenType.easeOutCubic);
    }

}
