using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorNPC : MonoBehaviour
{
    [SerializeField] private string thisVendorName; // contain the name of the store
    public Item[] thisVendorItems; // contain the items of the each vendor
    public List<Item> thisVendorList = new List<Item>(); // contain the items of the each vendor
    [SerializeField] private Vector3 thisItemsScale; // contain the scale needed for the items image
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
            canvas.ShowItems(thisVendorList, thisVendorName, thisItemsScale);
        }
    }

}
