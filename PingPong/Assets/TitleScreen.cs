using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    void Start()
    {
        
    }

    public void playerMode()
    {
        SceneManager.LoadScene(1);
    }

    public void playersMode()
    {
        SceneManager.LoadScene(2);
    }

}
