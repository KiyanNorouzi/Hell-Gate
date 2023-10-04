using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
  public void SceneLoad(){
        
    SceneManager.LoadScene("Lobby");
  }


    public void ExitScene(){
        Application.Quit();
  }
}
