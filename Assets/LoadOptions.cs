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

    public static bool optimalSettings;

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
        }
    }

    public void setTextFont()
    {
        if(myFont == null)
        {
            text.font = optimalFont;
        }
        text.font = myFont;
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
    }
}
