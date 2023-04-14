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
            queCurrent=ques4;
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
        //Set 3 - Jake's
        ques3[0] = new Question("Supersonic", "Referring to speeds that are faster than the speed of sound in the surrounding medium, typically associated with high-performance aircraft.");
        ques3[1] = new Question("Hypoxia", "A condition that occurs when the body is deprived of adequate oxygen supply, which can be a risk for pilots and astronauts at high altitudes or in space.");
        ques3[2] = new Question("Iridium", "A dense and corrosion-resistant metal used in aerospace applications, particularly in rocket engines and other high-temperature environments.");
        ques3[3] = new Question("Inertial Navigation System (INS)", "A self-contained navigation system that uses accelerometers and gyroscopes to determine an object's position, velocity, and attitude in space without relying on external signals.");
        ques3[4] = new Question("Reentry", "The process of returning a spacecraft or vehicle from space back to Earth, often involving high-speed and high-temperature interactions with the atmosphere.");
        ques3[5] = new Question("Cryogenic", "Referring to extremely low temperatures, typically below -150C (-238F), often used in aerospace applications for storage and transportation of propellants, such as liquid hydrogen or oxygen.");
        ques3[6] = new Question("Composite", "A material made by combining two or more different materials with distinct properties, often used in aerospace structures to achieve lightweight and high-strength characteristics.");
        ques3[7] = new Question("Hypergolic", "Referring to propellants or fuels that ignite spontaneously upon contact with each other, commonly used in spacecraft propulsion systems for reliable and quick ignition.");
        ques3[8] = new Question("Orbital Mechanics", "The study of the motion of objects, such as satellites or spacecraft, in orbit around celestial bodies, such as Earth or other planets.");
        ques3[9] = new Question("Scramjet", "A type of air-breathing jet engine that operates at hypersonic speeds, typically used for high-speed propulsion in experimental aircraft or missiles.");
        ques3[10] = new Question("Fly-by-Wire", "A flight control system that replaces conventional mechanical linkages with electronic signals, allowing for more precise and advanced control of aircraft or spacecraft.");
        ques3[11] = new Question("Active Noise Control", "A technology used in aerospace to reduce or cancel out noise and vibrations generated by engines or aerodynamic forces, enhancing comfort for passengers and reducing structural fatigue.");
        //Set 4
        ques4[0] = new Question("Ablation", "A process where the atmosphere melts and removes the surface material of an incoming meteorite.");
        ques4[1] = new Question("Achondrite", "A stone meteorite that contains none of the small glassy spheres commonly found in meteorites.");
        ques4[2] = new Question("Bolide", "A term used to describe an exceptionally bright meteor. they typically produce a sonic boom");
        ques4[3] = new Question("Declination", "The angular distance of an object in the sky from the celestial equator.");
        ques4[4] = new Question("Eccentricity ", "The measure of how an object's orbit differs from a perfect circle. eccentricity defines the shape of an object's orbit.");
        ques4[5] = new Question("Faculae", "Bright patches that are visible on the sun's surface, or photosphere.");
        ques4[6] = new Question("Heliopause", "The point in space at which the solar wind meets the interstellar medium or solar wind from other stars.");
        ques4[7] = new Question("Jansky", "The unit of strength of radio wave emission.");
        ques4[8] = new Question("Meridian", "An imaginary circle drawn through the north and south poles of the celestial equator.");
        ques4[9] = new Question("Lunation", "Lunar month or synodic month. the average time between successive new or full moons. ");
        ques4[10] = new Question("Kepler's second law", "A ray directed from the sun to a planet sweeps out equal areas in equal times.");
        ques4[11] = new Question("Granulation", "A pattern of small cells that be seen on the surface of the sun. they are caused by the convective motions of the hot gases inside the sun");


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