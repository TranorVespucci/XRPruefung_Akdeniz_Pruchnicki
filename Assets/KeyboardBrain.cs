using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardBrain : MonoBehaviour
{
    private string currentText = "DefaultText";
    public TMPro.TextMeshPro tmp;
    private GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        go = new GameObject("The ROOT");
        go.transform.position = Vector3.zero;
        //GameObject.Instantiate(go);
        UpdateTextDisplay();
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
        currentText = "";
        UpdateTextDisplay();
    }

    public void EnterKey()
    {
        //TODO all the magic
        ClearText();
        UpdateTextDisplay();
    }

    public void ClearSpawnedObjects()
    {
        UnityEngine.Transform[] gameObjects = go.GetComponentsInChildren<Transform>();
        foreach (Transform t in gameObjects)
        {
            Destroy(t.gameObject);
        }
    }
}
