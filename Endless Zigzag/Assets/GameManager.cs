using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Restart()
    {
        Application.LoadLevel("Level1");
        //SceneManager.LoadScene("Level1");
    }   
    
    public void Quit()
    {
        Application.Quit(0);
    }
}
