using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEditor;
public class ResultsScript : MonoBehaviour
{
    private TMP_Text m_TextComponent;
    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/Resources/testResults.txt";
        StreamReader reader = new StreamReader(path); 
        m_TextComponent.text= reader.ReadToEnd();
        reader.Close();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
