using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class AnatomySceneManager : MonoBehaviour
{
    [SerializeField] private TestScriptableObject anatomyReference;
    private GameObject platform;
    private AudioSource audioSource;
    private int index = 0;
    GameObject go = null;
    [SerializeField] private List<TMP_Text> description;
    [SerializeField] private List<TMP_Text> title;

    private void Start(){
        platform = GameObject.Find("platform");
        audioSource = platform.GetComponent<AudioSource>();
        OperateARObject();
        ARPlacementURP.spawn += ObjectIsSpwaned;
        ARPlacementURP.unspawn += ObjectIsSpwaned;
    }

    void OnDestroy(){
        ARPlacementURP.spawn -= ObjectIsSpwaned;
        ARPlacementURP.unspawn -= ObjectIsSpwaned;
    }

    public void NextObject(){
        index += 1;
        if(index >= anatomyReference.gameObjects.Length) {
            index = 0;
        }   
        OperateARObject();
    }
    public void PreviousObject(){
        index -= 1;
        if(index < 0) {
            index = anatomyReference.gameObjects.Length-1;
        }   
        OperateARObject();
        
    }

    private void OperateARObject(){
        if(platform == null){
            platform = GameObject.Find("platform");
        }
        if(platform.transform.childCount > 0){
            Destroy(platform.transform.GetChild(0).gameObject);
        }
        
        go =  Instantiate(anatomyReference.gameObjects[index].Arobject,platform.transform);

        for(int i = 0;i<description.Count;i++){
            description[i].text = anatomyReference.gameObjects[index].description;
        }
        for(int i = 0; i<title.Count; i++){
            title[i].text = anatomyReference.gameObjects[index].Arobject.name;
        }
        audioSource.Stop();
    }

    public void PlayDescription(){
        audioSource.clip = anatomyReference.gameObjects[index].AudioDescription;
        audioSource.Play();
    }

    public void ObjectIsSpwaned(){
        platform = GameObject.Find("Controller").GetComponent<ARPlacementURP>().returnSpwanedObject();
        //platform.transform.localScale = Vector3.one;
        OperateARObject();
    }
    public void objectISUnSpwaned(){
        platform = GameObject.Find("platform");
        //platform.transform.localScale = Vector3.one * 10;
    }
}
