using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardBrain : MonoBehaviour
{
    private string currentText = "DefaultText";
    public TMPro.TextMeshPro tmp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateTextDisplay()
    {
        tmp.text = currentText; //this is slow. I think
    }

    public void AppendChar(char incoming)
    {
        currentText += incoming;
        UpdateTextDisplay();
    }

    public void Backspace()
    {
        currentText = currentText.Remove(currentText.Length - 1);
        UpdateTextDisplay();
    }

    public void ClearText()
    {
        currentText = currentText.Remove(0);
        UpdateTextDisplay();
    }

    public void EnterKey()
    {
        //TODO all the magic
        ClearText();
    }
}
