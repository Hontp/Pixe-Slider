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
            main.startSpeed = 0;

            var emission = ps.emission;
           
            emission.rateOverDistance = Mathf.Abs(player.velocity.x)/4;
        }
        else
        {
            var emission = ps.emission;

            var renderer = GetComponent<ParticleSystemRenderer>();
            renderer.flip = new Vector3(1f,0f,0f);

            emission.rateOverDistance = 0f;
        }
    }
}
