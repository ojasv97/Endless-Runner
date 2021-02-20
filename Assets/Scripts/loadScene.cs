using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

	public void gameLoader()
    {
        SceneManager.LoadScene("Game");
    }
    public void quitLoader()
    {
        Application.Quit();
    }
  
}
