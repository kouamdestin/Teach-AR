using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class SolarSystemManager : MonoBehaviour
{
    [SerializeField] private TMP_Text planetName;
    [SerializeField] List<GameObject> placables = new List<GameObject>();
    private int position = -1;
    void Start()
    {
        planetName.text = "";
        foreach(GameObject var in placables){
            var.SetActive(false);
        }
        placables[9].SetActive(true);
    }

    public void DeployPlanet(){
        position += 1;
        planetName.text = placables[position].name;
        foreach(GameObject planet in placables){
            planet.SetActive(false);
        }
        placables[position].SetActive(true);
        

        // Debug.Log(position);
        //position = -1;
        //reset value
        if(position == placables.Count -1){
            // Debug.Log(position + " " + placables.Count);
            position = 0;
        }
    }

}
