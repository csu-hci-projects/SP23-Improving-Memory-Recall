using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadOptions : MonoBehaviour
{
    public Text text;
    public Image background;
    public static Font myFont;
    public static bool bold;
    public static bool italicize;
    public static Color colorChoice;
    public static Color backgroundColor;
    public static int textFontSize;
    public static string MusicType;

    public static float numOptions=5;
    public static bool optimalSettings;
    public static List<string> MixedSettings = new List<string>();
    public static List<string> usrSettings = new List<string>();
    public static List<string> optSettings = new List<string>(){"Color.red", "Font/NimbusRomNo9L-Reg", "Fontstyle.Normal","60","Color.yellow", "Classical"};
    public static Font optimalFont = Resources.Load<Font>("Font/NimbusRomNo9L-Reg");
    public static bool optimalBold = false;
    public static bool optimalItalic = false;
    public static Color optimalBackgroundColor = Color.yellow;
    public static Color optimalFontcolor = Color.red;
    public static Color usrFontcolor;
    public static Font usrFont;
    public static FontStyle usrStyle;
    public static int usrFontSize;
    public static Color usrBackgroundColor;
    public static string usrMusic;
    public static int[] arr1 = new int[6];
    // Start is called before the first frame update
    void Start()
    {
        if(textcontrol.index==0){
        optimalFont=text.font;
        }
        if (optimalSettings)
        {
            
        }
        else
        {
            setTextColor();
            setTextFont();
            setTextStyle();
            setTextSize();
            setBackgroundColor();
            setMusicType();
        }

        for(int i =0; i<Mathf.Ceil(numOptions/2); i++){
        int k =Random.Range(0,5);
        arr1[i]=k;
        }
         if(textcontrol.index==2){
            Debug.Log("made it optimal");
            text.fontSize = 60;
            text.color = optimalFontcolor;
            text.fontStyle = FontStyle.Normal;
            background.color = optimalBackgroundColor;
            text.font=optimalFont;
            setMusicType2("Classical");
        }
        else if(textcontrol.index==5){
            Debug.Log("made it mixed");
            text.fontSize = 60;
            text.color = optimalFontcolor;
            text.fontStyle = FontStyle.Normal;
            background.color = optimalBackgroundColor;
            text.font=optimalFont;
      
            setMusicType2("Classical");
            for(int j=0; j<2;j++){
                
                if(arr1[j]==0){
                    text.color=(usrFontcolor);
                    
                }
                else if(arr1[j]==1){
                    text.font=(usrFont);
         
                }
                else if(arr1[j]==2){
                    text.fontStyle=(usrStyle);
         
                }
                else if(arr1[j]==3){
                   text.fontSize =(usrFontSize);
     
                }
                else if(arr1[j]==4){
                   background.color =(usrBackgroundColor);

                }
                else if(arr1[j]==5){
                    setMusicType2(usrMusic);
                }
            }
            
        }
       
        
    }

    public void setTextFont()
    {
        if (myFont == null) { }
            //DO NOT REMOVE, making it so font won't change if Font button isn't pressed. 
        else
        {
            text.font = myFont;
        }
        
        usrSettings.Add(text.font.ToString());
        usrFont=text.font;
    }

    public void setTextColor()
    {
        if (colorChoice == null)
        {
            text.color = Color.black;
        }
        else
        {
            text.color = colorChoice;
        }
        usrSettings.Add(text.color.ToString());
        usrFontcolor=text.color;
    }
    public void setTextStyle()
    {
        if (italicize && bold)
        {
            text.fontStyle = FontStyle.BoldAndItalic;
        }

        else if (italicize && !bold)
        {
            text.fontStyle = FontStyle.Italic;
        }

        else if (!italicize && bold)
        {
            text.fontStyle = FontStyle.Bold;
        }
        usrSettings.Add(text.fontStyle.ToString());
        usrStyle=text.fontStyle;

    }

    public void setTextSize()
    {
        if (textFontSize == 0)
        {
            text.fontSize = 60;
        }
        else
        {
            text.fontSize = textFontSize;
        }
        usrSettings.Add(text.fontSize.ToString());
        usrFontSize=text.fontSize;
    }

    public void setBackgroundColor()
    {
        if(backgroundColor == null)
        {
            background.color = Color.white;
        }
        else
        {
            background.color = backgroundColor;
        }
        usrSettings.Add(background.color.ToString());
        usrBackgroundColor=background.color;
    }

    public void setMusicType()
    {
        usrSettings.Add(MusicType);
        usrMusic=MusicType;
    }
       
   public void setMusicType2(string music)
    {
        usrSettings[5]=(music);

    }



   
    
}
