using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class NextButton : MonoBehaviour , IPointerClickHandler
{
    public UnityEvent onClick;
    public void OnPointerClick(PointerEventData pointerEventData){ 
        if(textcontrol.randQuestion==textcontrol.randomList.Count-1){
            //next thing to do.
            Application.Quit();
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
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
