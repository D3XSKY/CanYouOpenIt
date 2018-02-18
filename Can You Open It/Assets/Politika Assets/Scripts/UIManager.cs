using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {


    

    public Text CurrentBalanceText;
    public Text CompanyNameText;
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
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
        CurrentBalanceText.text = gamemanager.instance.GetCurrentBalance().ToString("C2");
        CompanyNameText.text = gamemanager.instance.CompanyName; 

    }
}
