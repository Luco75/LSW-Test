using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private Color[] borderColors; //keep the shop or store windows
    [SerializeField] private Color[] interiorColors; //keep the shop or store windows
    [SerializeField] private Color[] titleColors; //keep the shop or store windows
    [SerializeField] private GameObject[] uiBorders; //keep the shop or store windows
    [SerializeField] private GameObject[] uiInteriors; //keep the shop or store windows
    [SerializeField] private GameObject textPlayerMoney; //keep the shop or store windows
    [SerializeField] private GameObject uiTitle; //keep the shop or store windows
    [SerializeField] private GameObject shopWindows; //keep the shop or store windows
    [SerializeField] private GameObject pcWindows; //keep the shop or store windows
    [SerializeField] private GameObject bedMenu; //keep the shop or store windows
    [SerializeField] private GameObject shopName; //is the text(TMP) with the name of the store 
    [SerializeField] private GameObject itemName; //is the text(TMP) with the name of the selected item
    [SerializeField] private GameObject itemDetails; //is the text(TMP) with the description of the selected item
    [SerializeField] private GameObject itemPrice; //is the text(TMP) with the price of the selected item
    [SerializeField] private GameObject alertPanel; //contain the alert panel
    [SerializeField] private GameObject buyButton; //button use when player buy an object
    [SerializeField] private GameObject sellButton; //button use when player sell an object
    [SerializeField] private GameObject takeButton; //button use when player eat or drink
    [SerializeField] private GameObject useButton; //button use when player use a clothe
    public GameObject buttons; //contain the father gameobject whit all buttons of aviable items
    private List<Item> currentShopItems = new List<Item>(); //used for save each item aviable
    private int buttonSelected;
    public string shopClass;
    
    //Buy and Sell feature
    [SerializeField] private Dropdown dropdown;
    [SerializeField] private GameObject dropdownContainer; // use for enable and disable dropdown
    private int newValue;
    private int lastValue;
    private bool valueHasChange;
    private List<Item> shopList = new List<Item>();
    private List<Item> shopListAux = new List<Item>();
    private List<Item> playerList = new List<Item>();
    public Vector3 newItemsScale;
    public Vector3 nextDestiny;

    PlayerController player;
    PlayerItems refrigerator, closet, house, garage;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        refrigerator = GameObject.FindGameObjectWithTag("Refrigerator").GetComponent<PlayerItems>();
        closet = GameObject.FindGameObjectWithTag("Closet").GetComponent<PlayerItems>();
        house = GameObject.FindGameObjectWithTag("House").GetComponent<PlayerItems>();
        garage = GameObject.FindGameObjectWithTag("Garage").GetComponent<PlayerItems>();

        textPlayerMoney.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + player.money.ToString();
        shopWindows.SetActive(false);
        pcWindows.SetActive(false);
        bedMenu.SetActive(false);
        buyButton.SetActive(false);
        sellButton.SetActive(false);
        useButton.SetActive(false);
        takeButton.SetActive(false);
        dropdown.value = 0;
        lastValue = dropdown.value;
        
    }


    void Update()
    {
        newValue = dropdown.value;

        if (lastValue != newValue)
        {
            if(dropdown.value == 0)
            {
                buyButton.SetActive(true);
                sellButton.SetActive(false);

                lastValue = newValue;
                ShowItems(shopList, shopClass, newItemsScale);
            }
            if (dropdown.value == 1)
            {
                buyButton.SetActive(false);
                sellButton.SetActive(true);

                switch (shopClass)
                {
                    case "Supermarket":
                        playerList.Clear();
                        for (int i = 0; i < refrigerator.playerItemsList.Count; i++)
                        {
                            playerList.Add(refrigerator.playerItemsList[i]);
                        }
                        break;
                    case "Furnitures":
                        playerList.Clear();
                        for (int i = 0; i < house.playerItemsList.Count; i++)
                        {
                            playerList.Add(house.playerItemsList[i]);
                        }
                        break;
                    case "Clothing store":
                        playerList.Clear();
                        for (int i = 0; i < closet.playerItemsList.Count; i++)
                        {
                            playerList.Add(closet.playerItemsList[i]);
                        }
                        break;
                    case "Cars Shop":
                        playerList.Clear();
                        for (int i = 0; i < garage.playerItemsList.Count; i++)
                        {
                            playerList.Add(garage.playerItemsList[i]);
                        }
                        break;
                }

                ShowItems(playerList, shopClass, newItemsScale);
                lastValue = newValue;
            }
        }
    }

    /* Next function (ShowItems) is calle evetytime that the player interact with a store, your refrigerator or your closet. This gameobjects send to this function your name,
     an array with all items that this contain and a vector 3 with the correct scale for the items icons*/
    
    public void ShowItems(List<Item> allItems, string name, Vector3 itemScale)
    {
        if (dropdown.value == 0) 
        {
            shopListAux.Clear();

            for (int i = 0; i < allItems.Count; i++)
            {
                shopListAux.Add(allItems[i]);
            }

            shopList.Clear();

            for (int i = 0; i < shopListAux.Count; i++)
            {
                shopList.Add(shopListAux[i]);
            }
        } 

        newItemsScale = itemScale;

        // clear the list where the allItems items will keeped
        currentShopItems.Clear();

        // keep all allitems elements in the list
        foreach (Item i in allItems)
        {
            currentShopItems.Add(i);
        }

        //show the items windows
        shopWindows.SetActive(true);

        // momently, disable all items buttons
        for (int i = 0; i < buttons.transform.childCount; i++)
        {
            GameObject child = buttons.transform.GetChild(i).gameObject;
            child.SetActive(false);
        }

        if (name == "Refrigerator" || name == "Closet") dropdownContainer.SetActive(false);
        else dropdownContainer.SetActive(true);

        int colorIndex = 0; //use for set the correct UI color (white for refrigerator, brown for closet, and blue for the rest of stores)

        // if player is in your refrigerator
        if (name == "Refrigerator")
        {
            // colorIndex no chage because here the colorIndex need be 0

            // show the correct button for this case
            buyButton.SetActive(false);
            takeButton.SetActive(true);
            useButton.SetActive(false);
        }

        // if player is in your closet
        else if (name == "Closet")
        {
            colorIndex = 1;
            // show the correct button for this case
            buyButton.SetActive(false);
            takeButton.SetActive(false);
            useButton.SetActive(true);
        }

        //if player is in stores
        else
        {
            colorIndex = 2;
            // show the correct button for this case

            if (dropdown.value == 0)
            {
                buyButton.SetActive(true);
                sellButton.SetActive(false);
            }
            else if (dropdown.value == 1)
            {
                buyButton.SetActive(false);
                sellButton.SetActive(true);
            }
            takeButton.SetActive(false);
            useButton.SetActive(false);

            //In this case, the next variable is use during shoppings.
            shopClass = name;
        }

        // finally, set the colors of the UI
        for (int i = 0; i < borderColors.Length; i++)
        {
            uiBorders[i].GetComponent<Image>().color = borderColors[colorIndex];
            uiInteriors[i].GetComponent<Image>().color = interiorColors[colorIndex];
            uiTitle.GetComponent<Image>().color = titleColors[colorIndex];
        }

        // refresh title name with the name of current gameobject interaction
        shopName.GetComponent<TMPro.TextMeshProUGUI>().text = name;

        // finally, need to make appear an item button for each element in the list
        for (int i = 0; i < currentShopItems.Count; i++)
        {
            // keep a button
            GameObject child = buttons.transform.GetChild(i).gameObject;
            // keep the item icon of this button
            GameObject spriteOfChild = child.transform.GetChild(1).gameObject;
            //button is active
            child.SetActive(true);
            //put the correct sprite in the icon
            spriteOfChild.GetComponent<SpriteRenderer>().sprite = currentShopItems[i].icon;
            // set the icon with your correct scale
            spriteOfChild.transform.localScale = itemScale;
        }
    }

    public void ShowPC()
    {
        pcWindows.SetActive(true);
    }

    public void ClosePc()
    {
        pcWindows.SetActive(false);
    }

    public void ShowBedOptions()
    {
        bedMenu.SetActive(true);
    }

    public void CloseBedOptions()
    {
        bedMenu.SetActive(false);
    }

    public void SetItemsInfo(int id)
    {
        buttonSelected = id;

        // if player is in your refrigerator
        if (name == "Refrigerator")
        {
            itemName.GetComponent<TMPro.TextMeshProUGUI>().text = currentShopItems[id].name;
            itemDetails.GetComponent<TMPro.TextMeshProUGUI>().text = currentShopItems[id].description;
        }

        // if player is in your closet
        else if (name == "Closet")
        {
            itemName.GetComponent<TMPro.TextMeshProUGUI>().text = currentShopItems[id].name;
            itemDetails.GetComponent<TMPro.TextMeshProUGUI>().text = currentShopItems[id].description;
        }

        //if player is in stores
        else
        {
            itemName.GetComponent<TMPro.TextMeshProUGUI>().text = currentShopItems[id].name;
            itemDetails.GetComponent<TMPro.TextMeshProUGUI>().text = currentShopItems[id].description;
            itemPrice.GetComponent<TMPro.TextMeshProUGUI>().text = "$ " + currentShopItems[id].price.ToString();
        }
    }

    public void Buy()
    {
        if(player.money >= currentShopItems[buttonSelected].price)
        {
            player.money -= currentShopItems[buttonSelected].price;
            textPlayerMoney.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + player.money.ToString();

            switch (shopClass)
            {
                case "Supermarket":
                    AddFood();
                    break;
                case "Furnitures":
                    AddFurniture();
                    break;
                case "Clothing store":
                    AddClothes();
                    break;
                case "Hairdressing":
                    ChangeHairStyle();
                    break;
                case "Cars Shop":
                    AddCar();
                    break;
            }
        }
        else
        {
            Alert("You have not enought money.");
        }
    }

    public void Sell()
    {
        player.money += currentShopItems[buttonSelected].price;
        textPlayerMoney.GetComponent<TMPro.TextMeshProUGUI>().text = "$" + player.money.ToString();

        switch (shopClass)
        {
            case "Supermarket":
                RemoveFood();
                break;
            case "Furnitures":
                RemoveFurniture();
                break;
            case "Clothing store":
                RemoveClothes();
                break;
            case "Cars Shop":
                RemoveCar();
                break;
        }
    }

    

    public void CloseShop()
    {
        if (alertPanel.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("AlertPanel_Idle"))
        {
            itemName.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            itemDetails.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            itemPrice.GetComponent<TMPro.TextMeshProUGUI>().text = "";
            dropdown.value = 0;
            lastValue = 0;
            buyButton.SetActive(true);
            sellButton.SetActive(false);
            shopWindows.SetActive(false);
        }
    }

    public void CloseAlert()
    {
        alertPanel.GetComponent<Animator>().Play("AlertPanel_Hide");
        gameObject.GetComponent<Canvas>().sortingOrder = 0;
    }

    public void Alert(string alert)
    {
        gameObject.GetComponent<Canvas>().sortingOrder = 2;
        alertPanel.GetComponent<Animator>().Play("AlertPanel_Show");
        alertPanel.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = alert;
    }

    private void ChangeHairStyle()
    {
        Alert("Congratulations! You have a new hair style.");
    }

    private void AddFood()
    {
        refrigerator.AddNewItem(currentShopItems[buttonSelected]);
    }

    private void RemoveFood()
    {
        refrigerator.QuitItem(currentShopItems[buttonSelected]);
    }

    private void AddClothes()
    {
        closet.AddNewItem(currentShopItems[buttonSelected]);
    }

    private void RemoveClothes()
    {
        closet.QuitItem(currentShopItems[buttonSelected]);
    }

    private void AddFurniture()
    {
        player.SetObject(buttonSelected, "Furniture", true);
        house.AddNewItem(currentShopItems[buttonSelected]);
    }

    private void RemoveFurniture()
    {
        player.SetObject(buttonSelected, "Furniture", false);
        house.QuitItem(currentShopItems[buttonSelected]);
    }

    private void AddCar()
    {
        player.SetObject(buttonSelected, "Car", true);
        garage.AddNewItem(currentShopItems[buttonSelected]);
    }

    private void RemoveCar()
    {
        player.SetObject(buttonSelected, "Car", false);
        garage.QuitItem(currentShopItems[buttonSelected]);
    }

    public void Teleport()
    {
        player.transform.position = nextDestiny;
        GameObject vcam = GameObject.FindGameObjectWithTag("Virtual Camera");
        vcam.transform.position = nextDestiny;
    }

    public void Dress()
    {
        if (currentShopItems[buttonSelected].clotheType == "torso")
        {
            player.bodyParts[2].GetComponent<SpriteRenderer>().sprite = player.allTorsosFront[currentShopItems[buttonSelected].index];
            player.bodyParts[3].GetComponent<SpriteRenderer>().sprite = player.allRightArms[currentShopItems[buttonSelected].index];
            player.bodyParts[4].GetComponent<SpriteRenderer>().sprite = player.allLeftArms[currentShopItems[buttonSelected].index];
            player.torsoIndex = currentShopItems[buttonSelected].index;
        }
        else
        {
            player.bodyParts[5].GetComponent<SpriteRenderer>().sprite = player.allLegs[currentShopItems[buttonSelected].index];
            player.bodyParts[6].GetComponent<SpriteRenderer>().sprite = player.allLegs[currentShopItems[buttonSelected].index];
        }
    }
    public void Job()
    {
        Alert("You've had a rough day. Time to rest and eat something");
        player.needJob = false;
        player.angry = true;
        player.tired = true;
    }

    public void EatAndDrink()
    {
        Alert("You feel satiated. Now you can sleep");
        player.angry = false;
    }

    public void Sleep()
    {
        if (player.needJob)
        {
            Alert("You must work before you rest");
        }
        else if (player.angry)
        {
            Alert("You must eat something before sleeping");
        }
        else
        {
            CloseBedOptions();
            GetComponent<Animator>().Play("TransitionPanel_NewDay");
        }
    }

    public void NewDay()
    {
        player.tired = false;
        player.needJob = true;
        player.money += 100;
        Alert("You have received your pay for your work (+$100)");
    }




}

[Serializable]
public struct Item
{
    public Sprite icon;
    public string name;
    public string description;
    public string clotheType;
    public int index;
    public int price;
}
