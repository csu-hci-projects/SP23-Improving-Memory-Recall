using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadOptions : MonoBehaviour
{
    public Text text;
    public static Font myFont;
    public static bool bold;
    public static bool italicize;
    public static Color colorChoice;

    // Start is called before the first frame update
    void Start()
    {
        setTextColor();
        setTextFont();
        setTextStyle();
    }

    public void setTextFont()
    {
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

}
