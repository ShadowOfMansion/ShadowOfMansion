using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public string SceneToLoad;
    
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}