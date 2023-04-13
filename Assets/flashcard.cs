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

    public Question[] ques = new Question[48];
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
        ques[12] = new Question("Sycophant", "A person who acts obsequiously toward someone important in order to gain advantage.");
        ques[13] = new Question("Obfuscate", "Render obscure, unclear, or unintelligible.");
        ques[14] = new Question("Mawkish", "Sentimental in a feeble or sickly way.");
        ques[15] = new Question("Scintillating", "Sparkling or shining brightly.");
        ques[16] = new Question("Garrulous", "Excessively or pointlessly talkative.");
        ques[17] = new Question("Syncretism", "The amalgamation(combination) or attempted amalgamation of different religions, cultures, or schools of thought.");
        ques[18] = new Question("Parochial", "Having a limited or narrow outlook or scope; provincial.");
        ques[19] = new Question("Sardonic", "Mocking or cynical in a humorous or sarcastic way.");
        ques[20] = new Question("Quixotic", "Overly idealistic or unrealistic; impractical.");
        ques[21] = new Question("Puerile", "Childish, silly, or trivial.");
        ques[22] = new Question("Profligate", "Recklessly extravagant or wasteful in the use of resources.");
        ques[23] = new Question("Pleonasm", "The use of more words than are necessary to convey meaning.");
        //Set 3
        ques[24] = new Question("Word25", "Def25");
        ques[25] = new Question("Word26", "Def26");
        ques[26] = new Question("Word27", "Def27");
        ques[27] = new Question("Word28", "Def28");
        ques[28] = new Question("Word29", "Def29");
        ques[29] = new Question("Word30", "Def30");
        ques[30] = new Question("Word31", "Def31");
        ques[31] = new Question("Word32", "Def32");
        ques[32] = new Question("Word33", "Def33");
        ques[33] = new Question("Word34", "Def34");
        ques[34] = new Question("Word35", "Def35");
        ques[35] = new Question("Word36", "Def36");
        //Set 4
        ques[36] = new Question("Word37", "Def37");
        ques[37] = new Question("Word38", "Def38");
        ques[38] = new Question("Word39", "Def39");
        ques[39] = new Question("Word40", "Def40");
        ques[40] = new Question("Word41", "Def41");
        ques[41] = new Question("Word42", "Def42");
        ques[42] = new Question("Word43", "Def43");
        ques[43] = new Question("Word44", "Def44");
        ques[44] = new Question("Word45", "Def45");
        ques[45] = new Question("Word46", "Def46");
        ques[46] = new Question("Word47", "Def47");
        ques[47] = new Question("Word48", "Def48");


        distancePerTime = r.localScale.x / flipTime;
        cardText.text = ques[cardNum].question;

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
                    cardText.text = ques[cardNum].correctAnswer;
                }
                else
                {
                    faceSide = 0;
                    cardText.text = ques[cardNum].question;
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
        if(cardNum >= ques.Length)
        {
            cardNum = 0;
        }
        else if ((float)cardNum / (float)12 == 1.0 || (float)cardNum / (float)24 == 1.0 || (float)cardNum / (float)36 == 1.0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        cardText.text = ques[cardNum].question;
    }

    public void FlipCard()
    {
        timeCount = 0;
        isFlipping = true;
        isShrinking = -1;
    }
}


