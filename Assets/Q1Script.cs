using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Diagnostics;
using UnityEditor;
using System.IO;
public class Q1Script : MonoBehaviour , IPointerClickHandler
{
    static int id = 1;
    static List<string> defenitions=textcontrol.defenitions;
    public static string correctDef;
    
    public static string set = "no";
    public static int Q1Roll;
    public UnityEvent onClick;
    public static int randVal;
    public void OnPointerClick(PointerEventData pointerEventData){
        textcontrol.stopwatch.Stop();
        textcontrol.totalTime+=textcontrol.stopwatch.ElapsedMilliseconds;
        textcontrol.selectedAnswer=m_TextComponent.text;
        textcontrol.choiceselected="yes";
        if(textcontrol.order [textcontrol.randomList[textcontrol.randQuestion]] ==id){
            textcontrol.numCorrect+=1;
           
        }
        else{
            textcontrol.numCorrect+=0;
            
        }
        
        if(textcontrol.randQuestion==textcontrol.randomList.Count-1){
        string path = "Assets/Resources/testResults.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(textcontrol.numCorrect+","+textcontrol.totalTime);
        writer.Close();
            //next thing to do.
            //Accuracy = textcontrol.numCorrect / number of defs.
            //Time taken = textcontrol.totalTime
        }
        else{
        textcontrol.randQuestion+=1;
        Q1Script.randVal= Random.Range(0,textcontrol.order.Count);
        Q2Script.randVal= Random.Range(0,textcontrol.order.Count);
        Q3Script.randVal= Random.Range(0,textcontrol.order.Count);
        Q4Script.randVal= Random.Range(0,textcontrol.order.Count);
        for(int i =0; i<textcontrol.questions.Count; i++){
            int randInt  = Random.Range(1, 4);
            textcontrol.order[i]=randInt;
        }
        textcontrol.stopwatch.Start();
        onClick.Invoke();
       
        }
    }
    private TMP_Text m_TextComponent;
    
    // Start is called before the first frame update
    void Start()
    {
        Stopwatch stopwatch = new Stopwatch();
           stopwatch.Start();
            randVal= Random.Range(0,textcontrol.order.Count);
    }

    // Update is called once per frame
    void Update()
    {
        while(randVal==Q4Script.randVal | randVal==Q2Script.randVal | randVal == Q3Script.randVal){
            randVal=Random.Range(0,textcontrol.order.Count);
        }
        while(randVal==textcontrol.randomList[textcontrol.randQuestion]){
            randVal=Random.Range(0,textcontrol.order.Count);
        }
        if(textcontrol.order[textcontrol.randomList[textcontrol.randQuestion]]==id){
            correctDef="yes";
        }
        
        else{
            correctDef="no";
        }
        m_TextComponent = GetComponent<TMP_Text>();
        if(textcontrol.randomList[textcontrol.randQuestion]>-1){
            if(correctDef=="yes"){
                m_TextComponent.text = defenitions [textcontrol.randomList[textcontrol.randQuestion]];
            }
            else{if(randVal != textcontrol.randomList[textcontrol.randQuestion]){
                m_TextComponent.text = defenitions [randVal];}
                else{m_TextComponent.text = defenitions [randVal ];}}   
    } 
    }
}
