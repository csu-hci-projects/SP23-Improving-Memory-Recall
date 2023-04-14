using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class invisScript : MonoBehaviour
{
    public static int[] intarr = new int[11];
    private string input;
    public TMP_InputField IF;
    public GameObject gameObject;
    public void hide(){
        gameObject.SetActive(false);

    }
   public void readString()
    {
        string text = IF.text;
        for (int i = 0; i < text.Length;i++)
        {
            intarr[i] = (int) text[i]-48;
        }
    }
}
