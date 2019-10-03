using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_FallDistance : MonoBehaviour
{
    public WallScroll ws;
    private Text label;
    public float distance;
    public int TILESIZE = 16;

    public Color highscoreColor;
    public int highScore;

    // Start is called before the first frame update
    

    void Start()
    {
        label = GetComponent<Text>();
        highScore = ((int)PlayerPrefs.GetFloat("HighScore", 0));
        

        // Update is called once per frame
    }
    void Update()
    {
        distance = ws.distance * (20 * TILESIZE) / TILESIZE;
        int distanceInt = (int)distance;
        label.text = distanceInt.ToString() + "m";

        if (distance > ((int)PlayerPrefs.GetFloat("HighScore", 0)))
        {
            PlayerPrefs.SetFloat("HighScore", distance);
            label.color = highscoreColor;
        }
        

  
    }
   

}
