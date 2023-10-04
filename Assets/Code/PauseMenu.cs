using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene("Lobby");
                Debug.Log($"Restart");}
        
        if (Input.GetKeyDown(KeyCode.Escape)){
                Application.Quit();
                 Debug.Log($"Exit");}
     
    }

}
