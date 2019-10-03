using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    int highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore = (int)PlayerPrefs.GetFloat("HighScore", 0);
        GetComponent<Text>().text = "HIGHSCORE: " + highscore.ToString() + "m";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
