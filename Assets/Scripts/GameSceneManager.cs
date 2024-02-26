using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Collections.Generic;
using System.Linq;


public class GameSceneManager : MonoBehaviour{

#region variables
    public TMP_Text chem_text,It_text,phy_text,geo_text,Econs_text,Bio_text;

    public string defaultMessage = "Please Select a Choice";
    public string ErrorMessage = "NB:   please Select a choice before you continue";

    private List<Button> buttons = new List<Button>();


    public static int Tp_chem = 0;
    public static int Tp_phy = 0;
    
    public static int Tp_IT = 0;
    public static int Tp_geo = 0;
    public static int Tp_Econs = 0;
    public static int Tp_Bio = 0;

#endregion

    void Start(){
        //send this if condition to update if you need to check every frame
        if(SceneManager.GetActiveScene().buildIndex == 1){
            Tp_chem = 0;
            Tp_phy = 0;
            Tp_IT = 0;
            Tp_Bio = 0;
            Tp_Econs = 0;
            Tp_geo = 0;
        }

        buttons = GameObject.Find("Canvas").GetComponentsInChildren<Button>().ToList();

        foreach(Button btn in buttons){
            btn.onClick.AddListener(playTapsound);
        }


        defaultMessage = "Please Select a Choice             ";
        ErrorMessage = "NB:   please Select a choice before you continue";

        It_text.text = defaultMessage;
        phy_text.text = defaultMessage;
        chem_text.text = defaultMessage;
        Econs_text.text = defaultMessage;
        geo_text.text = defaultMessage;
        Bio_text.text = defaultMessage;
        Cursor.visible = true;
    }


    public static void SetChem(int value){
        Tp_chem = value;
    }
    public static void SetPhysics(int value){
        Tp_phy = value;
    }
    public static void SetInformatique(int value){
        Tp_IT = value;
    }
    public static void SetGeoGraphy(int value){
        Tp_geo = value;
    }
    public static void SetEconomics(int value){
        Tp_Econs = value;
    }
    public static void SetBiology(int value){
        Tp_Bio = value;
    }
    
    public void loadchem(){
        switch(Tp_chem){
            case 0: {
                chem_text.text = ErrorMessage;
                chem_text.color = Color.red;
                break;
            }
            case 1: {
                SceneManager.LoadSceneAsync("ChemLaboratory");
                break;
            }
        }
    }
    public void loadIT(){
    switch(Tp_IT){
        case 0: {
            It_text.text = ErrorMessage;
            It_text.color = Color.red;
            break;
        }
        case 1: {
            SceneManager.LoadSceneAsync("ITLaboratory");
            break;
        }
    }
}
    public void loadPhy(){
    switch(Tp_phy){
        case 0: {
            phy_text.text = ErrorMessage;
            phy_text.color = Color.red;
            break;
        }
        case 1: {
            SceneManager.LoadSceneAsync("phyLaboratory");
            break;
        }
    }
}
    public void loadBio(){
    switch(Tp_Bio){
        case 0: {
            Bio_text.text = ErrorMessage;
            Bio_text.color = Color.red;
            break;
        }
        case 1: {
            SceneManager.LoadSceneAsync("BioLaboratory");
            break;
        }case 2: {
            SceneManager.LoadSceneAsync("BioLaboratory1");
            break;
        }case 3: {
            SceneManager.LoadSceneAsync("BioLaboratory2");
            break;
        }case 4: {
            SceneManager.LoadSceneAsync("BioLaboratory3");
            break;
        }case  5: {
            SceneManager.LoadSceneAsync("test");
            break;
        }
    }
}
    public void loadEcons(){
    switch(Tp_Econs){
        case 0: {
            Econs_text.text = ErrorMessage;
            Econs_text.color = Color.red;
            break;
        }
        case 1: {
            SceneManager.LoadSceneAsync("EconsLaboratory");
            break;
        }
    }
}
    public void loadGeo(){
    switch(Tp_geo){
        case 0: {
            geo_text.text = ErrorMessage;
            geo_text.color = Color.red;
            break;
        }
        case 1: {
            SceneManager.LoadSceneAsync("GeoLaboratory");
            break;
        }
        case 2: {
            SceneManager.LoadSceneAsync("CamerAr");
            break;
        }
    }
}

    private void playTapsound(){
        GameObject.Find("SoundManager").GetComponent<AudioSource>().Play();
    }

    public void LoadSignLanguage(){
        SceneManager.LoadSceneAsync("SignLanguage");
    }

    public void LoadMain(){
        SceneManager.LoadSceneAsync("Welcome");
    }
    public void ExitApplication(){
        Application.Quit();
    }
}
