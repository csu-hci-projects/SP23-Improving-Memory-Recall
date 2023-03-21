using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class Q4Script : MonoBehaviour , IPointerClickHandler
{
    static List<string> defenitions=textcontrol.defenitions;
    public static string correctDef;
    public static int Q4Roll;
    public static string set = "no";
    public UnityEvent onClick;
    public void OnPointerClick(PointerEventData pointerEventData){
       
        textcontrol.selectedAnswer=m_TextComponent.text;
        textcontrol.choiceselected="yes";
        onClick.Invoke();
    }
    private TMP_Text m_TextComponent;
    
    // Start is called before the first frame update
    void Start()
    {
       Q4Roll=Random.Range(0,defenitions.Count);
       while(Q4Roll == Q1Script.Q1Roll | Q4Roll == Q2Script.Q2Roll | Q4Roll == Q3Script.Q3Roll){
            Q4Roll=Random.Range(0,defenitions.Count);
       }
    }

    // Update is called once per frame
    void Update()
    {
        if(set=="no"){
            correctDef="no";
            Q4Roll=Random.Range(0,defenitions.Count);
            while(Q4Roll == Q1Script.Q1Roll | Q4Roll == Q2Script.Q2Roll | Q4Roll == Q3Script.Q3Roll){
                Q4Roll=Random.Range(0,defenitions.Count);
            }
            set="yes";
        }
        if(Q4Roll > Q1Script.Q1Roll & Q4Roll > Q2Script.Q2Roll & Q4Roll > Q3Script.Q3Roll){
            correctDef = "yes";
        }
        m_TextComponent = GetComponent<TMP_Text>();
        if(textcontrol.randQuestion>-1){
            if(correctDef=="yes"){
                m_TextComponent.text = defenitions [textcontrol.randQuestion];
            }
            else{m_TextComponent.text = defenitions [Q4Roll];}}    
    }
}
