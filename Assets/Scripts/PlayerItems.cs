using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
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

    /*
        the second parameter of ShowItems() determinate the colors of the UI. when player sell an object in a store, need conserve the store UI, for this
        use canvas.shopclass, but when it eat, canvas.showclass = the last store that visit and this make that refrigerator UI change after eat the first food.
        for solve this when eat use EatFood() that use thisVendorName and not canvas.showclass how second parameter of ShowItems().
     */

    public void EatFood(Item itemToQuit)
    {
        playerItemsList.Remove(itemToQuit);
        VendorNPC thisVendor = GetComponent<VendorNPC>();
        thisVendor.thisVendorList.Remove(itemToQuit);
        canvas.ShowItems(playerItemsList, thisVendor.thisVendorName, thisVendor.thisItemsScale);
    }
}
