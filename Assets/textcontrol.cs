using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class textcontrol : MonoBehaviour
{
    private TMP_Text m_TextComponent;
    public static List<string> questions = new List<string>() {"Question 1: ", "Question 2: ", "Question 3: ", "Question 4: ", "Question 5: ","Question 6: ", "Question 7: ", "Question 8: ", "Question 9: ", "Question 10: ", "Question 11: ", "Question 12: "};
    public static List<string> defenitions = new List<string>() {"D1","D2", "D3","D4","D5", "D6","D7","D8", "D9","D10","D11", "D12"};
    public static int randQuestion=-1;
    public static string selectedAnswer;
    public static string choiceselected="no";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(randQuestion==-1){
        randQuestion=Random.Range(0,5);
        }
        if(randQuestion>-1){
        m_TextComponent = GetComponent<TMP_Text>();
        m_TextComponent.text = questions [randQuestion];
        }
        if (choiceselected=="yes"){
            choiceselected="no";
            if (defenitions[randQuestion]==selectedAnswer){
                Debug.Log("Correct");
            }
            else{
                Debug.Log("Nop");
            }
        }
        
    }
}
