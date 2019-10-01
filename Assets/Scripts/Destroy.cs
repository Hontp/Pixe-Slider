using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public float WaitToDestroy = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObjectDelayed();
    }



    void DestroyObjectDelayed()
    {
        if(transform.position.y > 0f)
        {
            Destroy(gameObject);
        }
    }


}
