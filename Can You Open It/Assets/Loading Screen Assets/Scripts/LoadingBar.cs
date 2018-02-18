using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour
{
    public Slider ProgressBar;
    public Text LoadingText;
    int maxValue = 101;
    int CurrentValue;
    int StartValue = 0;
    
    
    // Use this for initialization
    void Start()
    {
        ProgressBar.value = StartValue;
        CurrentValue = StartValue;
        LoadingText.text = "Loading" + "  " + ProgressBar.value + "  %";
    }

    // Update is called once per frame
    void Update()
    {


        ChangeValue();
        DisplayLoadPercent();

        LoadScene();




    }
    public void LoadScene()
    {
        if (CurrentValue == maxValue) { 
            LoadingText.text = "Loading Finished";
        SceneManager.LoadScene("MainMenu");
        }
    }

    public void ChangeValue()
    {
        
        if (CurrentValue <= maxValue)
            
        {
            ProgressBar.value = CurrentValue;
            CurrentValue++;
        }
        

    }
    public void DisplayLoadPercent()
    {
        if (ProgressBar.value <= maxValue)
            LoadingText.text = "Loading" + "  " + ProgressBar.value + "  %";
        
    }
    



}