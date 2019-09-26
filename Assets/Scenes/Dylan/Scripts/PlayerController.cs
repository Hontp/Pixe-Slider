using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float SwipeTolerance;
    public float Jump;
    public float wallCheckDistance;
    public float maxWallSlideVelocity;

    private bool isWallSliding = false;

    public Transform WallCheck;

    private RaycastHit2D wallCheckHit;

    public Rigidbody2D rb;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wallCheckHit = Physics2D.Raycast(WallCheck.position, WallCheck.right, wallCheckDistance);

        if (wallCheckHit)
        {
            Debug.Log("Hitting the wall");
        }

        if (isWallSliding)
        {
            if(rb.velocity.y < maxWallSlideVelocity)
            {
                rb.velocity = new Vector2(rb.velocity.x, -maxWallSlideVelocity);
            }
        }

    }

    void Update()
    {
        if (wallCheckHit && rb.velocity.y <= 0)
        {
            isWallSliding = true;
        }
    }

    void Gravity()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
