using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private int id;
    CanvasController canvas;

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasController>();
        id = transform.GetSiblingIndex();
    }

    void Update()
    {
        
    }

    public void SendInfoToCanvas()
    {
        canvas.SetItemsInfo(id);
    }
}
