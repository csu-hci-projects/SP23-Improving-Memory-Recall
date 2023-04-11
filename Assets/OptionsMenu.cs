using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public void fontType(Font font) { LoadOptions.myFont = font; }
    public void fontItalicized() { LoadOptions.italicize = true; Debug.Log("ITALICIZE"); }
    public void fontBold() { LoadOptions.bold = true; Debug.Log("BOLD"); }
    public void fontSize(int fontSize) { LoadOptions.textFontSize = fontSize; }
    public void optimized() { LoadOptions.optimalSettings = true; }

    public void fontColor(string colorName) 
    {
        if (colorName == "Red")
        {
            LoadOptions.colorChoice = Color.red;
            Debug.Log("RED");
        }
        else if (colorName == "Blue") {
            LoadOptions.colorChoice = Color.blue;
            Debug.Log("BLUE");
        }
        else if (colorName == "Yellow"){
            LoadOptions.colorChoice = Color.yellow;
            Debug.Log("YELLOW");
        }
    }

    public void backgroundColor(string colorName)
    {
        if(colorName == "Yellow")
        {
            LoadOptions.backgroundColor = Color.yellow;
        }
        else if(colorName == "Red")
        {
            LoadOptions.backgroundColor = Color.red;
        }
        else if(colorName == "Grey")
        {
            LoadOptions.backgroundColor = Color.grey;
        }
    }

}
