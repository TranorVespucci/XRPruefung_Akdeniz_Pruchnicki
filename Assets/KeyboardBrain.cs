using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardBrain : MonoBehaviour
{
    private string currentText = "DefaultText";
    public TMPro.TextMeshPro tmp;
    private GameObject rootRef;
    public GameObject prefabSquid;
    public GameObject prefabFriends;
    public GameObject prefabDeer;
    public GameObject prefabMonkey;
    // Start is called before the first frame update
    void Start()
    {
        rootRef = new GameObject("The ROOT");
        rootRef.transform.position = Vector3.zero;
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
        EvaluateCommand();
        ClearText();
        UpdateTextDisplay();
    }



    public void ClearSpawnedObjects()
    {
        UnityEngine.Transform[] gameObjects = rootRef.GetComponentsInChildren<Transform>();
        foreach (Transform t in gameObjects)
        {
            Destroy(t.gameObject);
        }
        rootRef = Instantiate(rootRef);
        rootRef = new GameObject("The ROOT");
        rootRef.transform.position = Vector3.zero;
    }

    private void EvaluateCommand()
    {
        string[] words = this.currentText.Split(' ');
        if (words == null)
        {
            return;
        }
        GameObject selectedPrefab = null;
        Debug.Log("Enter Pressed");
        switch (words[0])
        {
            case "SQUID":
                selectedPrefab = this.prefabSquid;break;
            case "MONKEY":
                selectedPrefab = prefabMonkey;break;
            case "DEER":
                selectedPrefab = prefabDeer;break;
            case "FRIENDS":
                selectedPrefab = prefabFriends;break;
            default:
                break;
        }
        if (selectedPrefab != null)
        {
            int toSpawn = 1;
            if (words.Length > 1)
            {
                toSpawn = int.Parse(words[1]);
            }

            for (int i = 0; i < toSpawn; i++)
            {
                GameObject newest = GameObject.Instantiate(selectedPrefab);
                newest.transform.parent = rootRef.transform;
                newest.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1;
                newest.transform.Translate(0, i * 2, 0);
                newest.transform.LookAt(Camera.main.transform.position);
            }
        }
    }
}
