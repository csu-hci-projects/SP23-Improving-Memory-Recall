using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;
public class textcontrol : MonoBehaviour
{
    private TMP_Text m_TextComponent;
    public static List<string> questions = new List<string>(){"","","","","","","","","","","",""};
    public static List<string> defenitions = new List<string>(){"","","","","","","","","","","",""};
    public static List<int> order = new List<int>() {0,0,0,0,0,0,0,0,0,0,0,0};
    public static List<int> randomList = new List<int>(){0,1,2,3,4,5,6,7,8,9,10,11};
    public static int randQuestion=0;
    public static string selectedAnswer;
    public static string choiceselected="no";
    public static int numCorrect=0;
    public static long totalTime=0;
     public static int shouldExit=0;
     public static int index=0;
    public static Stopwatch stopwatch=new Stopwatch();
    // Start is called before the first frame update
    void Start()
    {
        
        if(invisScript.intarr[textcontrol.index]==1){
            flashcard.queCurrent=flashcard.ques;
        }
        else if(invisScript.intarr[textcontrol.index]==2){
            flashcard.queCurrent=flashcard.ques2;
        }
        else if(invisScript.intarr[textcontrol.index]==3){
            flashcard.queCurrent=flashcard.ques3;
        }
        else if(invisScript.intarr[textcontrol.index]==4){
            flashcard.queCurrent=flashcard.ques;
        }
        for(int j =0; j<12; j++){
            questions[j]=flashcard.queCurrent[j].question;
        }
        for(int k =0; k<12; k++){
            defenitions[k]=flashcard.queCurrent[k].correctAnswer;
        }
        stopwatch.Start();
        int n = randomList.Count;  
        while (n > 1) {  
            n--;  
            int k = Random.Range(0, n + 1);  
            int value = randomList[k];  
            randomList[k] = randomList[n];  
            randomList[n] = value;  
        }  
        for(int i =0; i<questions.Count; i++){
            
            int randInt  = Random.Range(1, 4);
            order[i]=(randInt);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        m_TextComponent = GetComponent<TMP_Text>();
        m_TextComponent.text = questions [randomList[randQuestion]];
        
        
    }
}
