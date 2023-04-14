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
        ques[12] = new Question("Word13", "Def13");
        ques[13] = new Question("Word14", "Def14");
        ques[14] = new Question("Word15", "Def15");
        ques[15] = new Question("Word16", "Def16");
        ques[16] = new Question("Word17", "Def17");
        ques[17] = new Question("Word18", "Def18");
        ques[18] = new Question("Word19", "Def19");
        ques[19] = new Question("Word20", "Def20");

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
        if (cardNum >= ques.Length)
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


