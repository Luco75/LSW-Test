using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Vector3 destiny; // place when the player will teleport
    CanvasController canvas;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvas.nextDestiny = destiny;
            canvas.GetComponent<Animator>().Play("TransitionPanel_Teleport");
        }
    }
}
