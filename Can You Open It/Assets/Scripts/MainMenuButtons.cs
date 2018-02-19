using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
      
	}
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
        //Debug.Log("Game is exiting");
    }
    public void OpenTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        //Debug.Log("Game is exiting");
    }
    public void OpenAbout()
    {
        SceneManager.LoadScene("About");
        //Debug.Log("Game is exiting");
    }
    public void PlayBa()
    {
        SceneManager.LoadScene("PlayBA");
        //Debug.Log("Game is exiting");
    }
    public void PlayHR()
    {
        SceneManager.LoadScene("PlayHR");
        //Debug.Log("Game is exiting");
    }
    public void PlayRS()
    {
        SceneManager.LoadScene("PlayRS");
        //Debug.Log("Game is exiting");
    }
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
        //Debug.Log("Game is exiting");
    }

}
