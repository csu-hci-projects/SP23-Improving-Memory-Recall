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
        textcontrol.randQuestion=-1;
        Q1Script.set="no";
        Q2Script.set="no";
        Q3Script.set="no";
        Q4Script.set="no";
        onClick.Invoke();
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
