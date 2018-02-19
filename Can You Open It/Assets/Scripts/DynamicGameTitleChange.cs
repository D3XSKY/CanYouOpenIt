using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DynamicGameTitleChange : MonoBehaviour {
    public Image GameTitle;
    public Sprite s0;
    public Sprite s1;
    public Sprite s2;
    public Sprite[] images;
    
    
    // Use this for initialization
    void Start () {
        images = new Sprite[3];
        images[0] = s0;
        images[1] = s1;
        images[2] = s2;
       
    }

   

    // Update is called once per frame
    void Update()
    {
       
    }




    IEnumerator ChangeImage(int time)
    {
       
        int num = UnityEngine.Random.Range(0, images.Length);
        yield return new WaitForSeconds(time / 100);
        GameTitle.sprite = images[num];
        
        
    }
}



