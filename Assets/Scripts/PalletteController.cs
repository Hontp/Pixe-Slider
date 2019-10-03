using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletteController : MonoBehaviour
{
    public GameObject background = null;
    public GameObject leftSpike = null;
    public GameObject rightSpike = null;

    public List<SpriteRenderer> bgRender = null;

    public List<Color> color;

    public WallScroll myScroll;

    public static Color currentColor;
    // Start is called before the first frame update
    void Start()
    {

        currentColor = color[0];

        if (background != null)
        {
            bgRender.Add(background.GetComponent<SpriteRenderer>());

            foreach ( Transform  renderer in background.transform)
            {
                bgRender.Add(renderer.GetComponent<SpriteRenderer>());
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (myScroll.distance * 20.0f >= 250.0f && myScroll.distance * 20.0f < 500.0f)
        {
            for (int i = 0; i < bgRender.Count; i++)
            {
                bgRender[i].color = color[1];
                currentColor = color[1];


                //find all the existing hazards and change thier color
                HazardController[] hazards = FindObjectsOfType<HazardController>();
                foreach (HazardController h in hazards)
                {
                    h.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color[1];
                    h.transform.GetChild(1).GetComponent<SpriteRenderer>().color = color[1];
                }

            }
        }
        else if (myScroll.distance * 20.0f >= 500.0f && myScroll.distance * 20.0f < 750.0f)
        {
            for (int i = 0; i < bgRender.Count; i++)
            {
                bgRender[i].color = color[2];
                currentColor = color[2];


                //find all the existing hazards and change thier color
                HazardController[] hazards = FindObjectsOfType<HazardController>();
                foreach (HazardController h in hazards)
                {
                    h.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color[2];
                    h.transform.GetChild(1).GetComponent<SpriteRenderer>().color = color[2];
                }

            }

        }
        else if (myScroll.distance * 20.0f >= 750.0f && myScroll.distance * 20.0f < 1000.0f)
        {
            for (int i = 0; i < bgRender.Count; i++)
            {
                bgRender[i].color = color[3];
                currentColor = color[3];


                //find all the existing hazards and change thier color
                HazardController[] hazards = FindObjectsOfType<HazardController>();
                foreach (HazardController h in hazards)
                {
                    h.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color[3];
                    h.transform.GetChild(1).GetComponent<SpriteRenderer>().color = color[3];
                }

            }

        }
        else if (myScroll.distance * 20.0f > 1000.0f)
        {
            for (int i = 0; i < bgRender.Count; i++)
            {
                bgRender[i].color = color[4];
                currentColor = color[4];


                //find all the existing hazards and change thier color
                HazardController[] hazards = FindObjectsOfType<HazardController>();
                foreach (HazardController h in hazards)
                {
                    h.transform.GetChild(0).GetComponent<SpriteRenderer>().color = color[4];
                    h.transform.GetChild(1).GetComponent<SpriteRenderer>().color = color[4];
                }

            }

        }

    }
}
