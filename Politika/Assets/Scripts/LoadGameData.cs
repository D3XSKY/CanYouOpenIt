using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameData : MonoBehaviour
{

    public delegate void LoadDataComplete();
    public static event LoadDataComplete OnLoadDataComplete;

    public TextAsset GameData;
    public GameObject StorePrefab;
    public GameObject StorePanel;

    public GameObject ManagerPrephab;
    public GameObject ManagerPanel;

    public void Start()
    {
        // Invoke("LoadData", .1f);
        LoadData();
        if (OnLoadDataComplete != null)
            OnLoadDataComplete();
    }
    public void LoadData()
    {
        // Create xml to hold data
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(GameData.text);

        // LOad game manager data
        LoadGameManagerData(xmlDoc);

        // LOAD tHE STORES
        LoadStores(xmlDoc);
    }
    public void LoadGameManagerData(XmlDocument xmlDoc)
    {

        // LOAD GAME MANAGER INFO
        //Starting Balance
        float StartingBalance = float.Parse(xmlDoc.GetElementsByTagName("StartingBalance")[0].InnerText);
        gamemanager.instance.AddToBalance(StartingBalance);
        // Policko ime
        string CompanyName = (xmlDoc.GetElementsByTagName("CompanyName")[0].InnerText);
        gamemanager.instance.CompanyName = CompanyName;


    }
    void LoadManagerNodes(XmlDocument xmlDoc)
    {





    }
    void LoadStores(XmlDocument xmlDoc)
    {
        XmlNodeList StoreList = xmlDoc.GetElementsByTagName("store");

        foreach (XmlNode StoreInfo in StoreList)
        {

            LoadStoreNodes(StoreInfo);
          

        }
    }
    void SetStoreObj(store StoreObj, XmlNode StoreNode, GameObject NewStore )
    {
        if (StoreNode.Name == "name")
        {

            Text StoreText = NewStore.transform.Find("StoreNameText").GetComponent<Text>();
            StoreText.text = StoreNode.InnerText;
        }
      

        if (StoreNode.Name == "image")
        {
            Sprite newSprite = Resources.Load<Sprite>(StoreNode.InnerText);
            Image StoreImage = NewStore.transform.Find("ImageButtonClick").GetComponent<Image>();
            StoreImage.sprite = newSprite;


        }

        if (StoreNode.Name == "BaseStoreProfit")
            StoreObj.BaseStoreProfit = float.Parse(StoreNode.InnerText);
        if (StoreNode.Name == "BaseStoreCost")
            StoreObj.BaseStoreCost = float.Parse(StoreNode.InnerText);

        if (StoreNode.Name == "StoreTimer")
            StoreObj.StoreTimer = float.Parse(StoreNode.InnerText);
        if (StoreNode.Name == "StoreMultiplier")
            StoreObj.StoreMultiplier = float.Parse(StoreNode.InnerText);
        if (StoreNode.Name == "StoreTimerDivision")
            StoreObj.StoreTimerDivision = int.Parse(StoreNode.InnerText);
        if (StoreNode.Name == "StoreCount")
            StoreObj.StoreCount = int.Parse(StoreNode.InnerText);
        if (StoreNode.Name == "ManagerCost")
            CreateManager(StoreNode, StoreObj);



    }
   
    void LoadStoreNodes(XmlNode StoreInfo)
    {
        GameObject NewStore = (GameObject)Instantiate(StorePrefab);
        store StoreObj = NewStore.GetComponent<store>();
        XmlNodeList StoreNodes = StoreInfo.ChildNodes;
        
        foreach (XmlNode StoreNode in StoreNodes)
        {
            //Debug.Log(StoreNode.Name);
            //Debug.Log(StoreNode.InnerText);

            SetStoreObj(StoreObj, StoreNode, NewStore);




        }
        // Set up store nextcost
        StoreObj.SetNextStoreCost(StoreObj.BaseStoreCost);
        // Connect store to the parent panel
        NewStore.transform.SetParent(StorePanel.transform);


    }
    void CreateManager(XmlNode StoreNode, store StoreObj)
    {
        GameObject NewManager = (GameObject)Instantiate(ManagerPrephab);
        NewManager.transform.SetParent(ManagerPanel.transform);
        

    }

}
