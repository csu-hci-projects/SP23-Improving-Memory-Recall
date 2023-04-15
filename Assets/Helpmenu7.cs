using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helpmenu7 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (textcontrol.shouldExit == 7)
        {
            SceneManager.LoadScene("Results");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
