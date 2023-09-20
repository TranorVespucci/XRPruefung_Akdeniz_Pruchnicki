
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MonkeCollider : MonoBehaviour
{
    public TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        text.text = "the Monkey was placed into the cage";
    }
}
