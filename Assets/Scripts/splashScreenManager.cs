using UnityEngine;
using UnityEngine.SceneManagement;

public class splashScreenManager : MonoBehaviour
{
    int Access_state = 0;
    
    void Awake(){
        checkState();
    }
    
    public void LoadMain(){
        SceneManager.LoadSceneAsync("Welcome");
        PlayerPrefs.SetInt("Access_state",1);
    }

    private void checkState(){
        Access_state = PlayerPrefs.GetInt("Access_state",0);
        if(Access_state == 1){
            LoadMain();
        }else{
            return;
        }
        
    }

    public static void deletekey(){
        PlayerPrefs.DeleteKey("Access_state");
    }
    
}
