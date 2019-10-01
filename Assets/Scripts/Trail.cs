using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public WallScroll ws;
    private ParticleSystem ps;
    public Rigidbody2D player;

    public Player p;

    public int TILESIZE = 16;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(p.state == Player.playerState.JUMPING)
        {
            var main = ps.main;
            main.startSpeed = ws.speed * (320f/16f);

            var emission = ps.emission;
           
            emission.rateOverDistance = Mathf.Abs(player.velocity.x)/2;
            var renderer = GetComponent<ParticleSystemRenderer>();
            
            renderer.flip = player.velocity.x < 0 ? new Vector3(1f,0f,0f) : new Vector3(0f,0f,0f);
            
        }
        else
        {
            var emission = ps.emission;

            
            emission.rateOverDistance = 0f;
        }
    }
}
