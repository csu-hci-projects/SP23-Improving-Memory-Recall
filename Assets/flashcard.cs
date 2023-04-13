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
    public RectTransform r;
    public Text cardText;

    public Question[] ques = new Question[20];

    public float flipTime = 0.15f;
    private int faceSide = 0; //0=front, 1=back
    private int isShrinking = -1; // -1 = get smaller, 1 = get bigger
    private bool isFlipping = false;
    private int cardNum = 0;
    private float distancePerTime;
    private float timeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Set 1
        ques[0] = new Question("Word1", "Def1");
        ques[1] = new Question("Word2", "Def2");
        ques[2] = new Question("Word3", "Def3");
        ques[3] = new Question("Word4", "Def4");
        ques[4] = new Question("Word5", "Def5");
        ques[5] = new Question("Word6", "Def6");
        ques[6] = new Question("Word7", "Def7");
        ques[7] = new Question("Word8", "Def8");
        ques[8] = new Question("Word9", "Def9");
        ques[9] = new Question("Word10", "Def10");
        ques[10] = new Question("Word11", "Def11");
        ques[11] = new Question("Word12", "Def12");
        //Set 2
        ques[12] = new Question("Word13", "Def13");
        ques[13] = new Question("Word14", "Def14");
        ques[14] = new Question("Word15", "Def15");
        ques[15] = new Question("Word16", "Def16");
        ques[16] = new Question("Word17", "Def17");
        ques[17] = new Question("Word18", "Def18");
        ques[18] = new Question("Word19", "Def19");
        ques[19] = new Question("Word20", "Def20");
        ques[20] = new Question("Word21", "Def21");
        ques[21] = new Question("Word22", "Def22");
        ques[22] = new Question("Word23", "Def23");
        ques[23] = new Question("Word24", "Def24");
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
        cardNum = 0;
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
        if (cardNum >= ques.Length || cardNum/12==1 || cardNum/24==1 || cardNum/36==1)
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


