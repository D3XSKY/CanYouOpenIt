using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class store : MonoBehaviour {
   // PUBLIC VARIABLES - DEFINE GAMEPLAY
    public float BaseStoreCost;
    public float BaseStoreProfit;
    public float StoreTimer;
    public int StoreCount;
    public bool ManagerUnlocked;
    float CurrentProfit;
    float NextStoreCost;
    public float StoreMultiplier;
    float CurrentTimer = 0;
    bool StartTimer;
    public bool StoreUnlocked;
    public int StoreTimerDivision;
    public float StoreMultiplierIncrement;
    public float StoreProfitMultiplier;
    public float ManagerCost;
    //public string CurrentStoreTimer;
   // float StoreClock;
   // bool StartClock;
   // float CurrentClock= 0;
    //int TimerMinutes;
    //int TimerSeconds;
    // Use this for initialization
    void Start () {

       // NextStoreCost = BaseStoreCost;
       
        
        StartTimer = false;
    }
    
	// Update is called once per frame
	void Update () {

        if (StartTimer)
        {
            CurrentTimer += Time.deltaTime;
            if(CurrentTimer > StoreTimer)
            {
                if (!ManagerUnlocked)
                StartTimer = false;
                CurrentTimer = 0f;  
                gamemanager.instance.AddToBalance(BaseStoreProfit * StoreCount);
            }
            
        }
      /*  // TIMER TRY
        if (StartClock)
        {
            CurrentClock += Time.deltaTime;
            if (CurrentClock > StoreClock)
            {
                if (!ManagerUnlocked)
                    StartClock = false;
                CurrentClock = 0f;
                
            }

        }
        // TIMER END*/
        CurrentStoreProfit();
       /*   int TimerMinutes = Mathf.FloorToInt(StoreTimer / 60F);
           int TimerSeconds = Mathf.FloorToInt(StoreTimer - TimerMinutes * 60);*/
}

     public void BuyStore()
    {
       
        StoreCount = StoreCount + 1;
        float Amt = -NextStoreCost;
        NextStoreCost = (BaseStoreCost * Mathf.Pow(StoreMultiplier, StoreCount));
        gamemanager.instance.AddToBalance(Amt);
        

        if (StoreCount % StoreTimerDivision == 0)
            StoreTimer = StoreTimer / 2;

        if (StoreCount % StoreMultiplierIncrement == 0)
            StoreMultiplier = StoreMultiplier + 0.01f;

        if (StoreCount % StoreProfitMultiplier == 0)
            BaseStoreProfit = BaseStoreProfit+ ((BaseStoreProfit / 100) * 20);

    }
    public void OnStartTimer()
    {
       
        if (!StartTimer && StoreCount > 0)
            StartTimer = true;
    }
   /* public void OnStartClock()
    {

        if (!StartClock && StoreCount > 0)
            StartClock = true;
    }*/
    public void CurrentStoreProfit() {
        
         
        CurrentProfit = BaseStoreProfit * StoreCount;

    }
    //
    /*

        public void CurrentStoreTimerCalculation()
        {

            public int TimerMinutes = Mathf.FloorToInt(StoreTimer / 60F);
           public int TimerSeconds = Mathf.FloorToInt(StoreTimer - TimerMinutes * 60);
            string CurrentStoreTimer = string.Format("{0:0}:{1:00}", TimerMinutes, TimerSeconds);


        }*/
  /*  public int GetCurrenStoreMinutes()
    {

        return TimerMinutes;
    }
    public int GetCurrenStoreSeconds()
    {

        return TimerSeconds;
    }*/
    //

    public float GetCurrentProfit()
    {

        return CurrentProfit;

    }
    public float GetCurrentTimer()
    {

        return CurrentTimer;
    }
   public bool GetStartTimer()
    {

        return StartTimer;
    }

    public float GetStoreTimer() {

        return StoreTimer;
      
    }
    public float GetNextStoreCost() {

        return NextStoreCost;


    }
    public void SetNextStoreCost(float amt)
    {

        NextStoreCost = amt;


    }


}
