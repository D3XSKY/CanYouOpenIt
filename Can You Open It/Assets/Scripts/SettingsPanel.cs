using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MonoBehaviour {

    public GameObject SettingsMenu;
    public GameObject HeroManager;
    public GameObject SkillManager;
    public GameObject PerksManager;
    public GameObject N1;
    public GameObject N2;


	// Use this for initialization
	void Start () {
        SettingsMenu.SetActive(false);
        HeroManager.SetActive(false);
        SkillManager.SetActive(false);
        PerksManager.SetActive(false);
        N1.SetActive(false);
        N2.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void showSettingsMenu()
    {
        // making menu appear or disappear on click depending whether if it is already active
        if (SettingsMenu.active == false)
        {
            SettingsMenu.SetActive(true);
        }
        else
        {
            SettingsMenu.SetActive(false);
        }

    }
    public void showHeroMenu()
    {
        // making menu appear or disappear on click depending whether if it is already active
        if (HeroManager.active == false)
        {
            HeroManager.SetActive(true);
        }
        else
        {
            HeroManager.SetActive(false);
        }

    }
    public void showSkillMenu()
    {
        // making menu appear or disappear on click depending whether if it is already active
        if (SkillManager.active == false)
        {
            SkillManager.SetActive(true);
        }
        else
        {
            SkillManager.SetActive(false);
        }
       
    }
    public void showPerksMenu()
    {
        // making menu appear or disappear on click depending whether if it is already active
        if (PerksManager.active == false)
        {
            PerksManager.SetActive(true);
        }
        else
        {
            PerksManager.SetActive(false);
        }

    }
    public void showNotYetDecidedMenu()
    {
        // making menu appear or disappear on click depending whether if it is already active
        if (N1.active == false)
        {
            N1.SetActive(true);
        }
        else
        {
            N1.SetActive(false);
        }

    }
    public void showNotYetDecidedMenuTwo()
    {
        // making menu appear or disappear on click depending whether if it is already active
        if (N2.active == false)
        {
            N2.SetActive(true);
        }
        else
        {
            N2.SetActive(false);
        }

    }


}
