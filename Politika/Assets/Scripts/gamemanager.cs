using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gamemanager : MonoBehaviour {

    public delegate void UpdateBalance();
    public static event UpdateBalance OnUpdateBalance;


    public static gamemanager instance;
      float CurrentBalance = 0;
    public string CompanyName;
    
    float TotalProfit;
    public Text TotalProfitText;

    // Use this for initialization
    void Start () {
   
        if (OnUpdateBalance != null)
            OnUpdateBalance();
        //UIManager.instance.UpdateUI();




    }
	
	// Update is called once per frame
	void Update () {


		
	}

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void AddToBalance(float amt)
    {
        CurrentBalance += amt;
        if (OnUpdateBalance != null)
            OnUpdateBalance();
        //UIManager.instance.UpdateUI();
       
    }
    public bool CanBuy (float AmtToSpend)
    {
        if (AmtToSpend > CurrentBalance)
            return false;
        else
            return true;
    }

    public float GetCurrentBalance()
    {

        return CurrentBalance;

    }
   
}


