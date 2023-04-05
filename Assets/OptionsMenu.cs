using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public Font myFont;
    public bool bold = false;
    public bool italicize = false;
    public Color color = new Color(0,0,0);

    public void fontType(Font font) { myFont = font; }
    public void fontItalicized() { italicize = !italicize; Debug.Log("ITALICIZE"); }
    public void fontBold() { bold = !bold; Debug.Log("BOLD"); }
    public void fontColor(string colorName) 
    {
        if (colorName == "Red")
            color = new Color(1, 0, 0);
            Debug.Log("RED");
        if (colorName == "Blue")
            color = new Color(0, 0, 1);
            Debug.Log("BLUE");
        if (colorName == "Yellow")
            color = new Color(0, 1, 1);
            Debug.Log("YELLOW");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

}
