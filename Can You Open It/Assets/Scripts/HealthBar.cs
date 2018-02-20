using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    public Image bar;
    public float maxHealth = 100f;
    public float currentHealth = 0f;
    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        //InvokeRepeating("DecreaseHealth", 0f, 2f);
	}
	public void DecreaseHealth()
    {
        currentHealth -= 1f;
        float calculateHealth = currentHealth / maxHealth;
        SetHealth(calculateHealth);
    }
    void SetHealth(float myHealth) {

        bar.fillAmount = myHealth;
    }
}
