using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorNPC : MonoBehaviour
{
    [SerializeField] private Item[] thisVendorItems; // contain the items of the each vendor
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
            canvas.ShowItems(thisVendorItems, "Cars Shop");
        }
    }

}
