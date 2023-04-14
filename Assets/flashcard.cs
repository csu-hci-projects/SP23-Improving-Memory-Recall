using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Question
{
    public string question;
    public string correctAnswer;
    public Question( string q, string c)
    {
        question = q;
        correctAnswer = c;
    }
}
public class flashcard : MonoBehaviour
{
    public static int[] order = new int[11];
    public RectTransform r;
    public Text cardText;
    public static int first;
    public static Question[] queCurrent=new Question[12];
    public static Question[] ques = new Question[12];
    public static Question[] ques2 = new Question[12];
    public static Question[] ques3 = new Question[12];
    public static Question[] ques4 = new Question[12];
    public int[] startpoint = { 0, 12, 24, 36 };

    public float flipTime = 0.15f;
    private int faceSide = 0; //0=front, 1=back
    private int isShrinking = -1; // -1 = get smaller, 1 = get bigger
    private bool isFlipping = false;
    public int cardNum = 0;

    private float distancePerTime;
    private float timeCount = 0;

    public void SetCardNum(int i)
    {
        cardNum = startpoint[i];
    }

    // Start is called before the first frame update
    void Start()
    {   
        if(invisScript.intarr[textcontrol.index]==1){
            queCurrent=ques;
        }
        else if(invisScript.intarr[textcontrol.index]==2){
            queCurrent=ques2;
        }
        else if(invisScript.intarr[textcontrol.index]==3){
            queCurrent=ques3;
        }
        else if(invisScript.intarr[textcontrol.index]==4){
            queCurrent=ques;
        }
        //Set 1 - Zachary's
        ques[0] = new Question("Eutectic", "Homogeneous solid mixture of at least two types of atoms or molecules that form a superlattice (usually a mix of alloys).");
        ques[1] = new Question("Alkaline", "An aqueous solution with a pH greater than 7.");
        ques[2] = new Question("Valence", "Number of electrons needed to fill the outermost electron shell.");
        ques[3] = new Question("Titration", "Process of adding a known volume and concentration of one solution to another to determine the concentration of the second solution.");
        ques[4] = new Question("Positron", "The antimatter counterpart to an electron, which has a charge of +1.");
        ques[5] = new Question("Alkoxide", "An organic functional group formed when a hydrogen atom is removed from the hydroxyl group of an alcohol when it is reacted with a metal.");
        ques[6] = new Question("Bitumen", "Natural mixture of polycyclic aromatic hydrocarbons (PAHs).");
        ques[7] = new Question("Seaborgium", "Radioactive transition metal with element symbol Sg and atomic number 106.");
        ques[8] = new Question("Calorimeter", "Instrument designed to measure heat flow of a chemical reaction or physical change.");
        ques[9] = new Question("Thiol", "An organic sulfur compound consisting of an alkyl or aryl group and a sulfur-hydrogen group; R-SH.");
        ques[10] = new Question("Ketone", "Compound containing a carbonyl functional group (C=O) between two groups of atoms");
        ques[11] = new Question("Miscible", "Soluble or able to be mixed to form a solution, typically applied to fluids.");
        //Set 2 - Jay's
        ques2[0] = new Question("Sycophant", "A person who acts obsequiously toward someone important in order to gain advantage.");
        ques2[1] = new Question("Obfuscate", "Render obscure, unclear, or unintelligible.");
        ques2[2] = new Question("Mawkish", "Sentimental in a feeble or sickly way.");
        ques2[3] = new Question("Scintillating", "Sparkling or shining brightly.");
        ques2[4] = new Question("Garrulous", "Excessively or pointlessly talkative.");
        ques2[5] = new Question("Syncretism", "The amalgamation(combination) or attempted amalgamation of different religions, cultures, or schools of thought.");
        ques2[6] = new Question("Parochial", "Having a limited or narrow outlook or scope; provincial.");
        ques2[7] = new Question("Sardonic", "Mocking or cynical in a humorous or sarcastic way.");
        ques2[8] = new Question("Quixotic", "Overly idealistic or unrealistic; impractical.");
        ques2[9] = new Question("Puerile", "Childish, silly, or trivial.");
        ques2[10] = new Question("Profligate", "Recklessly extravagant or wasteful in the use of resources.");
        ques2[11] = new Question("Pleonasm", "The use of more words than are necessary to convey meaning.");
        //Set 3
        ques3[0] = new Question("Word25", "Def25");
        ques3[1] = new Question("Word26", "Def26");
        ques3[2] = new Question("Word27", "Def27");
        ques3[3] = new Question("Word28", "Def28");
        ques3[4] = new Question("Word29", "Def29");
        ques3[5] = new Question("Word30", "Def30");
        ques3[6] = new Question("Word31", "Def31");
        ques3[7] = new Question("Word32", "Def32");
        ques3[8] = new Question("Word33", "Def33");
        ques3[9] = new Question("Word34", "Def34");
        ques3[10] = new Question("Word35", "Def35");
        ques3[11] = new Question("Word36", "Def36");
        //Set 4
        ques4[0] = new Question("Word37", "Def37");
        ques4[1] = new Question("Word38", "Def38");
        ques4[2] = new Question("Word39", "Def39");
        ques4[3] = new Question("Word40", "Def40");
        ques4[4] = new Question("Word41", "Def41");
        ques4[5] = new Question("Word42", "Def42");
        ques4[6] = new Question("Word43", "Def43");
        ques4[7] = new Question("Word44", "Def44");
        ques4[8] = new Question("Word45", "Def45");
        ques4[9] = new Question("Word46", "Def46");
        ques4[10] = new Question("Word47", "Def47");
        ques4[11] = new Question("Word48", "Def48");


        distancePerTime = r.localScale.x / flipTime;
        cardText.text = queCurrent[cardNum].question;

    }

    // Update is called once per frame
    void Update()
    {
        if (isFlipping)
        {
            Vector3 v = r.localScale;
            v.x += isShrinking * distancePerTime * Time.deltaTime;
            r.localScale = v;

            timeCount += Time.deltaTime;
            if((timeCount >= flipTime) && (isShrinking < 0))
            {
                isShrinking = 1;
                timeCount = 0;
                if (faceSide == 0)
                {
                    faceSide = 1;
                    cardText.text = queCurrent[cardNum].correctAnswer;
                }
                else
                {
                    faceSide = 0;
                    cardText.text = queCurrent[cardNum].question;
                }
            }
            else if ((timeCount >= flipTime) && (isShrinking == 1))
            {
                isFlipping = false;
            }
        }
    }
    public void NextCard()
    {
        faceSide = 0;
        cardNum++;
        if(cardNum >= queCurrent.Length)
        {
            textcontrol.index++;
            SceneManager.LoadScene("Game");
        }
        cardText.text = queCurrent[cardNum].question;
    }

    public void FlipCard()
    {
        timeCount = 0;
        isFlipping = true;
        isShrinking = -1;
    }
}