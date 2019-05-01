using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{


    public void Restart()
    {
        SceneManager.LoadScene("Game");
    } 
    
    public void BackToMain()
    {
        SceneManager.LoadScene("Menu");
    }
}
