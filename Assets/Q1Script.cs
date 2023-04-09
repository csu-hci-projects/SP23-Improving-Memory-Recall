using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;

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
        textcontrol.selectedAnswer=m_TextComponent.text;
        textcontrol.choiceselected="yes";
        onClick.Invoke();
    }
    private TMP_Text m_TextComponent;
    
    // Start is called before the first frame update
    void Start()
    {
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
