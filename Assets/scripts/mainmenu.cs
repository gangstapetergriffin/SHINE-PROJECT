using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void clickstart()
    {
        SceneManager.LoadScene(1);
    }
    public void exit() 
    {
    Application.Quit();
    }
}
