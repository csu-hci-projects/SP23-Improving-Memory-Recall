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

    // Start is called before the first frame update
    void Start()
    {
        if (optimalSettings)
        {
            text.fontSize = 60;
            text.color = optimalFontcolor;
            text.fontStyle = FontStyle.Normal;
            background.color = optimalBackgroundColor;
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
        MixedSettings=usrSettings;
        for(int i =0; i<Mathf.Ceil(numOptions/2); i++){
            int k =Random.Range(0,4);
            MixedSettings[i]=optSettings[i];
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
    }

    public void setMusicType()
    {
        usrSettings.Add(MusicType);
    }
}
