using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private int id;
    CanvasController canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<CanvasController>();
        id = transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendInfoToCanvas()
    {
        canvas.SetItemsInfo(id);
    }
}
