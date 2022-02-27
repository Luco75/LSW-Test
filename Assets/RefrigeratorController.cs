using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefrigeratorController : MonoBehaviour
{
    public Item[] playerFood;
    private int foodCount;
    [SerializeField] private string thisName;

    CanvasController canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasController>();
        playerFood = new Item[canvas.buttons.transform.childCount];
        foodCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddNewFood(Item newFood)
    {
        if(foodCount < playerFood.Length)
        {
            
            playerFood[foodCount] = newFood;
            foodCount++;

            GetComponent<VendorNPC>().thisVendorItems = new Item[foodCount];
            for (int i = 0; i < foodCount; i++)
            {
                GetComponent<VendorNPC>().thisVendorItems[i] = playerFood[i];
            }
        }
        else
        {
            canvas.Alert("Your "+ thisName + " is full");
        }
    }
}
