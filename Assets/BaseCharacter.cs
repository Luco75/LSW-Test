using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
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
    public GameObject[] bodyParts;

    // Start is called before the first frame update
    void Start()
    {
        bodyParts[0].GetComponent<SpriteRenderer>().sprite = allHairsBoyFront[3];
        bodyParts[1].GetComponent<SpriteRenderer>().sprite = allHeads[0];
        bodyParts[2].GetComponent<SpriteRenderer>().sprite = allTorsosFront[3];
        bodyParts[3].GetComponent<SpriteRenderer>().sprite = allRightArms[3];
        bodyParts[4].GetComponent<SpriteRenderer>().sprite = allLeftArms[3];
        bodyParts[5].GetComponent<SpriteRenderer>().sprite = allLegs[3];
        bodyParts[6].GetComponent<SpriteRenderer>().sprite = allLegs[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
