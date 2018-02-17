using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preloader : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minimumLogoTime = 3.0f; // minimm

    private void Start()
    {

        //Grab the only canvas group in the scene
        fadeGroup = FindObjectOfType<CanvasGroup>();
        // start with white screen

        fadeGroup.alpha = 1;

        // preload the game

        //get the timestamp Time.time
        if (Time.time < minimumLogoTime)
            loadTime = minimumLogoTime;
        else
            loadTime = Time.time;
    }
    private void Update()
    {
        //fade in

        if (Time.time < minimumLogoTime)
        {

            fadeGroup.alpha = 1 - Time.time;
        }

        //fade out
        if (Time.time > minimumLogoTime && loadTime != 0)
        {
            fadeGroup.alpha = Time.time - minimumLogoTime;

            if (fadeGroup.alpha >= 1)
            {
                Debug.Log("Change the scene");
            }
        }
    }
}
