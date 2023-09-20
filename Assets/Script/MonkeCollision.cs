using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonkeCollision : MonoBehaviour
{
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        text = FindObjectOfType<TextMeshPro>();
        text.text = "Place the Monkey into the cage";
    }

    void Update()
    {
        
    }
}