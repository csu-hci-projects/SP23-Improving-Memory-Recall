using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEditor;
using UnityEngine.UI;
using System;

public class ResultsScript : MonoBehaviour
{
    public Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/Resources/testResults.txt";
        string content = File.ReadAllText(path);
        textBox.text = content;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
