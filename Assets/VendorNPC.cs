using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorNPC : MonoBehaviour
{
    [SerializeField] private string thisVendorName; // contain the name of the store
    public List<Item> thisVendorList = new List<Item>(); // contain the items of the each vendor
    [SerializeField] private Vector3 thisItemsScale; // contain the scale needed for the items image
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

}
