using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed; //Used for move character
    
    public int money; //is the money of the player

    [SerializeField] private GameObject tv, sofa, library;
    [SerializeField] private GameObject blueCar, greenCar, redCar, redPickup, bluePickup, greenPickup;
    private bool hasTv, hasSofa, hasLibrary;
    private bool hasBlueCar, hasGreenCar, hasRedCar, hasRedPickup, hasBluePickup, hasGreenPickup;

    private Rigidbody2D rb2d; //the rigibody of the character
    
    void Start()
    {
        //create intance of the rigibody2D
        rb2d = GetComponent<Rigidbody2D>();

        // check if house objects are aviable
        SetPlayerObjects(library, hasLibrary);
        SetPlayerObjects(sofa, hasSofa);
        SetPlayerObjects(tv, hasTv);

        // check if cars are aviable
        SetPlayerObjects(blueCar, hasBlueCar);
        SetPlayerObjects(greenCar, hasGreenCar);
        SetPlayerObjects(redCar, hasRedCar);
        SetPlayerObjects(redPickup, hasRedPickup);
        SetPlayerObjects(bluePickup, hasBluePickup);
        SetPlayerObjects(greenPickup, hasGreenPickup);
    }

    void SetPlayerObjects(GameObject anObject, bool hasThisObject)
    {
        if (hasThisObject) anObject.SetActive(true);
        else anObject.SetActive(false);
    }
    
    void Update()
    {
        // Call Movement function
        Movement();
    }

    private void Movement()
    {
        // obtain Horizontal axis value
        float h = Input.GetAxis("Horizontal");
        //obtain Vertical axis value
        float v = Input.GetAxis("Vertical");

        //multiply the axis value for movement speed and add this to rigibody2D velocity
        rb2d.velocity = new Vector2(h * moveSpeed, v * moveSpeed);
    }

    public void BuyObject(int index, string objectName)
    {
        if(objectName == "Furniture")
        {
            switch (index)
            {
                case 0:
                    library.SetActive(true);
                    hasLibrary = true;
                    break;
                case 1:
                    sofa.SetActive(true);
                    hasSofa = true;
                    break;
                case 2:
                    tv.SetActive(true);
                    hasTv = true;
                    break;
            }
        }
        else if(objectName == "Car")
        {
            switch (index)
            {
                case 0:
                    blueCar.SetActive(true);
                    hasBlueCar = true;
                    break;
                case 1:
                    greenCar.SetActive(true);
                    hasGreenCar = true;
                    break;
                case 2:
                    redCar.SetActive(true);
                    hasRedCar = true;
                    break;
                case 3:
                    redPickup.SetActive(true);
                    hasRedPickup = true;
                    break;
                case 4:
                    bluePickup.SetActive(true);
                    hasBluePickup = true;
                    break;
                case 5:
                    greenPickup.SetActive(true);
                    hasGreenPickup = true;
                    break;
            }
        }
    }
}
