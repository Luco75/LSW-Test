using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public string p1Name;
    public bool male;
    public bool npc;

    [Header("All skins in the game")]
    public Sprite[] allHairsBoyFront;
    public Sprite[] allHairsBoyBack;
    public Sprite[] allHairsBoyLateral;
    public Sprite[] allHairsGirlFront;
    public Sprite[] allHairsGirlBack;
    public Sprite[] allHairsGirlLateral;
    public Sprite[] allHeads;
    public Sprite[] allTorsosFront;
    public Sprite[] allTorsosLateral;
    public Sprite[] allTorsosBack;
    public Sprite[] allRightArms;
    public Sprite[] allLeftArms;
    public Sprite[] allLegs;

    [Header("Skins selected for this character")]
    public Sprite[] thisSkin;

    [Header("Parts of the body with SpriteRenderers")]
    public GameObject[] bodyParts;

    public int torsoIndex;

    [SerializeField] private float moveSpeed; //Used for move character
    
    public int money; //is the money of the player

    [SerializeField] private GameObject tv, sofa, library;
    [SerializeField] private GameObject blueCar, greenCar, redCar, redPickup, bluePickup, greenPickup;
    [SerializeField] private bool hasTv, hasSofa, hasLibrary;
    [SerializeField] private bool hasBlueCar, hasGreenCar, hasRedCar, hasRedPickup, hasBluePickup, hasGreenPickup;
    [HideInInspector]
    public bool angry, tired, needJob;

    GameController gameController;

    private Rigidbody2D rb2d; //the rigibody of the character
    private Animator animator; //the rigibody of the character
    
    void Start()
    {
        animator = GetComponent<Animator>();

        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i].GetComponent<SpriteRenderer>().sprite = thisSkin[i];
        }

        if (npc)
        {
            return;
        }

        torsoIndex = 0;
        
        //create intance of the rigibody2D
        rb2d = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("Game Controller").GetComponent<GameController>();
        
        p1Name = gameController.playerName;
        male = gameController.playerIsMale;
        angry = false;
        tired = false;
        needJob = true;

        // check if house objects are aviable and hide if not are 
        SetPlayerObjects(library, hasLibrary);
        SetPlayerObjects(sofa, hasSofa);
        SetPlayerObjects(tv, hasTv);

        // check if cars are aviable and hide if not are
        SetPlayerObjects(blueCar, hasBlueCar);
        SetPlayerObjects(greenCar, hasGreenCar);
        SetPlayerObjects(redCar, hasRedCar);
        SetPlayerObjects(redPickup, hasRedPickup);
        SetPlayerObjects(bluePickup, hasBluePickup);
        SetPlayerObjects(greenPickup, hasGreenPickup);
        
    }
    
    void Update()
    {
        animator.SetBool("male", male);

        if (npc)
        {
            return;
        }

        animator.SetFloat("speed", rb2d.velocity.magnitude);
        animator.SetFloat("speed X", Mathf.Abs(rb2d.velocity.x));
        animator.SetFloat("speed Y", rb2d.velocity.y);
        
        // Call Movement function
        Movement();
        if (male)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Lateral Move"))
            {
                bodyParts[2].GetComponent<SpriteRenderer>().sprite = allTorsosLateral[torsoIndex];
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Up Move"))
            {
                bodyParts[2].GetComponent<SpriteRenderer>().sprite = allTorsosBack[torsoIndex];
            }
            else
            {
                bodyParts[2].GetComponent<SpriteRenderer>().sprite = allTorsosFront[torsoIndex];
            }
        }
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Lateral Move Female"))
            {
                bodyParts[2].GetComponent<SpriteRenderer>().sprite = allTorsosLateral[torsoIndex];
            }
            else if(animator.GetCurrentAnimatorStateInfo(0).IsName("Up Move Female"))
            {
                bodyParts[2].GetComponent<SpriteRenderer>().sprite = allTorsosBack[torsoIndex];
            }
            else
            {
                bodyParts[2].GetComponent<SpriteRenderer>().sprite = allTorsosFront[torsoIndex];
            }
        }
        
    }

    private void Movement()
    {
        // obtain Horizontal axis value
        float h = Input.GetAxis("Horizontal");
        //obtain Vertical axis value
        float v = Input.GetAxis("Vertical");

        //multiply the axis value for movement speed and add this to rigibody2D velocity
        rb2d.velocity = new Vector2(h * moveSpeed, v * moveSpeed);

        //when walk to left, invert the x scale to can use the same animation clip
        if (rb2d.velocity.x > 0.01f) transform.localScale = new Vector3(1f, 1f, 1f);
        else if (rb2d.velocity.x < - 0.01f) transform.localScale = new Vector3(-1f, 1f, 1f);

        if (rb2d.velocity.y > 0.01f) bodyParts[1].GetComponent<SpriteRenderer>().sprite = allHeads[2];
        else if (rb2d.velocity.y < -0.01f) bodyParts[1].GetComponent<SpriteRenderer>().sprite = allHeads[0];
    }

    public void SetObject(int index, string objectName, bool hasBought)
    {
        if (objectName == "Furniture")
        {
            switch (index)
            {
                case 0:
                    library.SetActive(hasBought);
                    hasLibrary = hasBought;
                    break;
                case 1:
                    sofa.SetActive(hasBought);
                    hasSofa = hasBought;
                    break;
                case 2:
                    tv.SetActive(hasBought);
                    hasTv = hasBought;
                    break;
            }
        }
        else if (objectName == "Car")
        {
            switch (index)
            {
                case 0:
                    blueCar.SetActive(hasBought);
                    hasBlueCar = hasBought;
                    break;
                case 1:
                    greenCar.SetActive(hasBought);
                    hasGreenCar = hasBought;
                    break;
                case 2:
                    redCar.SetActive(hasBought);
                    hasRedCar = hasBought;
                    break;
                case 3:
                    redPickup.SetActive(hasBought);
                    hasRedPickup = hasBought;
                    break;
                case 4:
                    bluePickup.SetActive(hasBought);
                    hasBluePickup = hasBought;
                    break;
                case 5:
                    greenPickup.SetActive(hasBought);
                    hasGreenPickup = hasBought;
                    break;
            }
        }
    }

    public void SetPlayerObjects(GameObject anObject, bool hasThisObject)
    {
        if (hasThisObject) anObject.SetActive(true);
        else anObject.SetActive(false);
    }
}
