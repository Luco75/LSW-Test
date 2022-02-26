using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed; //Used for move character
    private Rigidbody2D rb2d; //the rigibody of the character
    public int money; //is the money of the player


    void Start()
    {
        //create intance of the rigibody2D
        rb2d = GetComponent<Rigidbody2D>();    
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
}
