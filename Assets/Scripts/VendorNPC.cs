using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Initially this script controlled only the vendors but finally I decided to use it also for the interactions with the objects in the player's house 
(refrigerator, closet, bed and computer)
*/

public class VendorNPC : MonoBehaviour
{
    public string thisVendorName; // contain the name of the store
    public List<Item> thisVendorList = new List<Item>(); // contain the items of the each vendor
    public Vector3 thisItemsScale; // contain the scale needed for the items image
    [SerializeField] private ParticleSystem ps;
    CanvasController canvas;
    
    
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasController>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.tag == "PC")
            {
                canvas.ShowPC();
                ps.Stop();
            }
            else if(gameObject.tag == "Bed") 
            {
                canvas.ShowBedOptions();
                ps.Stop();
            }
            else
            {
                canvas.ShowItems(thisVendorList, thisVendorName, thisItemsScale);
                ps.Stop();
            }
        }
    }

    private void OnExitEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "PC")
            {
                canvas.ClosePc();
            }
            else if (gameObject.tag == "Bed")
            {
                canvas.CloseBedOptions();
            }
            else
            {
                canvas.CloseShop();
            }
        }
    }

}
