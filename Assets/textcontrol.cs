using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;
public class textcontrol : MonoBehaviour
{
    private TMP_Text m_TextComponent;
    public static List<string> questions = new List<string>() {"Question 1: ", "Question 2: ", "Question 3: ", "Question 4: ", "Question 5: ","Question 6: ", "Question 7: ", "Question 8: ", "Question 9: ", "Question 10: ", "Question 11: ", "Question 12: "};
    public static List<string> defenitions = new List<string>() {"D1","D2", "D3","D4","D5", "D6","D7","D8", "D9","D10","D11", "D12"};
    public static List<int> order = new List<int>() {0,0,0,0,0,0,0,0,0,0,0,0};
    public static List<int> randomList = new List<int>(){0,1,2,3,4,5,6,7,8,9,10,11};
    public static int randQuestion=0;
    public static string selectedAnswer;
    public static string choiceselected="no";
    public static int numCorrect=0;
    public static long totalTime=0;
    public static Stopwatch stopwatch=new Stopwatch();
    // Start is called before the first frame update
    void Start()
    {
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
