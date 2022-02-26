using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject shopWindows; //keep the shop or store windows
    [SerializeField] private GameObject shopName; //is the text(TMP) with the name of the store 
    [SerializeField] private GameObject itemName; //is the text(TMP) with the name of the selected item
    [SerializeField] private GameObject itemDetails; //is the text(TMP) with the description of the selected item
    [SerializeField] private GameObject itemPrice; //is the text(TMP) with the price of the selected item
    [SerializeField] private GameObject buttons; //contain the father gameobject whit all buttons of aviable items
    [SerializeField] private GameObject alertPanel; //contain the alert panel
    private List<Item> currentShopItems = new List<Item>(); //used for save each item aviable
    private int buttonSelected;
    private enum ShopClass {cars, clothes, hairStyles}
    private ShopClass shopClass;

    PlayerController player;

    void Start()
    {
        shopWindows.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

  
    void Update()
    {
        
    }

    public void ShowItems(Item[] allItems, string name)
    {
        shopWindows.SetActive(true);
        shopName.GetComponent<TMPro.TextMeshProUGUI>().text = name;

        for (int i = 0; i < buttons.transform.childCount; i++)
        {
            GameObject child = buttons.transform.GetChild(i).gameObject;
            child.SetActive(false);
        }

        currentShopItems.Clear();
        foreach(Item i in allItems)
        {
            currentShopItems.Add(i);
        }

        for (int i = 0; i < currentShopItems.Count; i++)
        {
            GameObject child = buttons.transform.GetChild(i).gameObject;
            child.SetActive(true);
            child.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = currentShopItems[i].icon;
        }
    }

    public void SetItemsInfo(int id)
    {
        buttonSelected = id;

        itemName.GetComponent<TMPro.TextMeshProUGUI>().text = currentShopItems[id].name;
        itemDetails.GetComponent<TMPro.TextMeshProUGUI>().text = currentShopItems[id].description;
        itemPrice.GetComponent<TMPro.TextMeshProUGUI>().text = "$ " + currentShopItems[id].price.ToString();
    }

    public void Buy()
    {
        if(player.money >= currentShopItems[buttonSelected].price)
        {
            switch (shopClass)
            {
                case ShopClass.clothes:
                    AddClothes();
                    break;
                case ShopClass.hairStyles:
                    AddHairStyle();
                    break;
                case ShopClass.cars:
                    AddCar();
                    break;
            }

            player.money -= currentShopItems[buttonSelected].price;
        }
        else
        {
            print("You have not enought money.");
        }
    }

    public void CloseShop()
    {
        if (alertPanel.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("AlertPanel_Idle"))
        {
            itemName.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            itemDetails.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            itemDetails.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            shopWindows.SetActive(false);
        }
    }

    public void CloseAlert()
    {
        alertPanel.GetComponent<Animator>().Play("AlertPanel_Hide");
        gameObject.GetComponent<Canvas>().sortingOrder = 0;
    }

    private void Alert(string alert)
    {
        gameObject.GetComponent<Canvas>().sortingOrder = 2;
        alertPanel.GetComponent<Animator>().Play("AlertPanel_Show");
        alertPanel.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = alert;
    }

    private void AddClothes()
    {
        Alert("Congratulations! You have a new clothe.");
    }
    
    private void AddHairStyle()
    {
        Alert("Congratulations! You have a new hair style.");
    }
    
    private void AddCar()
    {
        Alert("Congratulations! You have a new car.");
    }

}

[Serializable]
public struct Item
{
    public Sprite icon;
    public string name;
    public string description;
    public int price;
}
