using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    public Item[] playerItems;
    public List<Item> playerItemsList = new List<Item>();
    public int itemCount;
    private int totalItems;
    [SerializeField] private string thisName;

    CanvasController canvas;

    
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasController>();

        switch (gameObject.tag)
        {
            case "Refrigerator": totalItems = 30; break;
            case "Closet": totalItems = 30; break;
            case "House": totalItems = 3; break;
            case "Garage": totalItems = 6; break;
        }
        playerItems = new Item[totalItems]; /*ACA TA EL TEMA*/
        itemCount = 0;
    }

   
    void Update()
    {

    }

    public void AddNewItem(Item newItem)
    {
        if (playerItemsList.Count < totalItems)
        {
            playerItemsList.Add(newItem);

            GetComponent<VendorNPC>().thisVendorList.Add(newItem);
        }
        else
        {
            canvas.Alert("Your " + thisName + " is full");
        }
    }

    public void QuitItem(Item itemToQuit)
    {
        playerItemsList.Remove(itemToQuit);
        GetComponent<VendorNPC>().thisVendorList.Remove(itemToQuit);
        canvas.ShowItems(playerItemsList, canvas.shopClass, canvas.newItemsScale);
    }
}
