using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public WallScroll ws;
    private ParticleSystem ps;
    public Rigidbody2D player;

    public int TILESIZE = 16;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        main.startSpeed = ws.scrollAmount + ws.y / (TILESIZE/2);

        var emission = ps.emission;
        emission.rateOverTime = ws.scrollAmount + ws.y * 10;
        emission.rateOverDistance = -player.velocity.y * 10;
    }
}
