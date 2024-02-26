using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/Anamtomy")]
public class TestScriptableObject : ScriptableObject
{
   public AnatomyObject[] gameObjects;
}
[System.Serializable]
public class AnatomyObject {
    public GameObject Arobject;
    public string description;
    public AudioClip AudioDescription;
    //public AudioClip introAudio;
    
}