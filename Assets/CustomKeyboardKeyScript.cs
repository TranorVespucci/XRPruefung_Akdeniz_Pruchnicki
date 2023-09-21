using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomKeyboardKeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    private KeyboardBrain brain;
    public char inputChar;
    void Start()
    {
        brain = transform.parent.parent.GetComponent<KeyboardBrain>();
        GetComponentInChildren<TMPro.TextMeshPro>().text = inputChar.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TapKey()
    {
        //send signal to brain
        brain.AppendChar(inputChar);
    }
}
