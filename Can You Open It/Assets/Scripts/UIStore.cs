using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStore : MonoBehaviour {

    public Text BuyButtonText;
    public Button BuyButton;
    public Slider ProgressSlider;
    public Text StoreCountText;
    public Text ProfitPerStoreText;
    public Text CurrentStoreTimer;





    public store Store;


    void Awake()
    {
        Store = transform.GetComponent<store>();
    }
    // Use this for initialization
    void Start () {
        StoreCountText.text = Store.StoreCount.ToString();
        BuyButtonText.text = "Buy " + Store.GetNextStoreCost().ToString("C2");
        ProfitPerStoreText.text = "+" + Store.GetCurrentProfit().ToString("C2");
       // CurrentStoreTimer.text = Store.GetCurrenStoreMinutes().ToString("00") + ":" + Store.GetCurrenStoreSeconds().ToString("00");
    }
	
	// Update is called once per frame
	void Update () {
        ProgressSlider.value = Store.GetCurrentTimer() / Store.GetStoreTimer();
        
        UpdateUI();
        // Store.GetCurrenStoreTimer();
        //CurrentStoreTimer.text = Store.GetCurrenStoreMinutes().ToString("00") + ":" + Store.GetCurrenStoreSeconds().ToString("00");
    }

    void OnEnable()
    {
        gamemanager.OnUpdateBalance += UpdateUI;
        LoadGameData.OnLoadDataComplete += UpdateUI;

    }
    void OnDisable()
    {
        gamemanager.OnUpdateBalance += UpdateUI;
        LoadGameData.OnLoadDataComplete += UpdateUI;
    }

    public void UpdateUI()
    {
        // HIDE STORE UNTIL ABLE TO BUY
        CanvasGroup cg = this.transform.GetComponent<CanvasGroup>();
        if (!Store.StoreUnlocked && !gamemanager.instance.CanBuy(Store.GetNextStoreCost()))
        {

            cg.interactable = false;
            cg.alpha = 0;
        }
        else

        {
            cg.interactable = true;
            cg.alpha = 1;
            Store.StoreUnlocked = true;

        }
        // UPDATE BUTTON GREEN or RED BUY OR NO MONEY
        if (gamemanager.instance.CanBuy(Store.GetNextStoreCost()))
            BuyButton.interactable = true;
        else
            BuyButton.interactable = false;


        BuyButtonText.text = "Buy " + Store.GetNextStoreCost().ToString("C2");
        ProfitPerStoreText.text = "+" + Store.GetCurrentProfit().ToString("C2");
    }

    public void BuyStoreOnClick()
    {
        if (!gamemanager.instance.CanBuy(Store.GetNextStoreCost()))
            return;
        Store.BuyStore();
        StoreCountText.text = Store.StoreCount.ToString();
       BuyButtonText.text = "Buy " + Store.GetNextStoreCost().ToString("C2");
        ProfitPerStoreText.text = "+" + Store.GetCurrentProfit().ToString("C2");
        
        UpdateUI();

    }
    public void OnTimerClick()
    {

      Store.OnStartTimer();
        //Store.OnStartClock();


    }
}
