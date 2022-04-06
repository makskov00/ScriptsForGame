using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Uduino;


public class GameOverUI : MonoBehaviour



{

   
    public void Quit () 
    {
        Debug.Log("APPLICATION QUIT");
        Application.Quit();
        
    }
    public void Retry () 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   
}
