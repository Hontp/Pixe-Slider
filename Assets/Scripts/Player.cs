using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 startTouchPos;

    public float swipeTolerance;
    public float jumpSpeed;

    public bool touchingWallRight;
    public bool touchingWallLeft;

    public float minjumpSpeed;
    public float maxjumpSpeed;

    public float minSwipe;
    public float maxSwipe;

    public float friction;

    public float gravityWallSlideModifier;

    public float startTouchTime;

    public float swipeTimeCutOff;

    public bool dead;

    public float ledgeBoost = 1f;

    private float prevYVelocity;

    enum playerState {SLIDING, JUMPING, BRAKING};
    //playerState state = playerStat.SLIDING;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public ParticleSystem partLeftSlide;
    public ParticleSystem partRightSlide;

    public WallScroll ws;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!dead){
        #region gameplaycode
        if(Input.touchCount > 0 && Input.touchSupported && false)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                
            }

            if(touch.phase == TouchPhase.Stationary)
            {
                ws.pixelsPerTick -= friction;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                startTouchPos = touch.position;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                if (Mathf.Abs(touch.deltaPosition.x) > swipeTolerance)
                {
                    if (Mathf.Abs(touch.deltaPosition.x) < minjumpSpeed)
                    {
                        if (touch.deltaPosition.x > 0)
                        {
                            if (touchingWallLeft)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * minjumpSpeed * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);

                                touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                            }
                        }
                        else
                        {
                            if (touchingWallRight)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * -minjumpSpeed * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                            }
                        }

                    }
                    else
                    {

                        if (touch.deltaPosition.x > 0)
                        {
                            if (touchingWallLeft)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * touch.deltaPosition * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                            }
                        }
                        else
                        {
                            if (touchingWallRight)
                            {
                                rb.velocity = new Vector2(rb.velocity.x, 0f);
                                rb.AddForce(Vector2.right * touch.deltaPosition * Time.deltaTime * jumpSpeed, ForceMode2D.Impulse);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                            }
                        }
                    }

                }
            }
        }
        else
        {

            if (Input.GetMouseButtonDown(0) && (touchingWallLeft || touchingWallRight))
            {
                startTouchTime = Time.time;
                startTouchPos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0) && (touchingWallLeft || touchingWallRight))
            {
                
                ws.pixelsPerTick -=  friction;

            }


            if (Input.GetMouseButtonUp(0) && (touchingWallLeft || touchingWallRight))
            {
                // only takes into consideration a horizontal swipe (possibly change) 
                float deltaPosition = Input.mousePosition.x - startTouchPos.x;

                float swipeTime = Time.time - startTouchTime;
                float swipeSpeed = deltaPosition / swipeTime;
                
                // check if the start of the swipe was performed recently
                if(swipeTime < swipeTimeCutOff)
                {
                    Debug.Log("SWIPE TIME "+swipeTime+ "    deltaPosition" + deltaPosition);

                    if (deltaPosition > 0)
                    {
                        if (touchingWallLeft)
                        {
                            //rb.velocity = new Vector2(rb.velocity.x, 0f);
                            //limit the max speed
                            if(swipeSpeed > maxSwipe)
                            {
                                swipeSpeed = maxjumpSpeed;
                            }
                            if(swipeSpeed < minSwipe)
                            {
                                swipeSpeed = minjumpSpeed;
                            }

                            float force = swipeSpeed * jumpSpeed;
                            //rb.AddForce(Vector2.right * swipeSpeed * Time.deltaTime * jumpSpeed + new Vector2( -rb.velocity.y * gravityWallSlideModifier, 0), ForceMode2D.Impulse);
                            rb.AddForce(Vector2.right * force * Time.deltaTime, ForceMode2D.Impulse);
                            Debug.Log(swipeSpeed + "    "  + force);
                            touchingWallLeft = false;
                            touchingWallRight = false;
                            rb.gravityScale = 2.5f;
                        }
                    }
                    else if(deltaPosition < 0)
                    {
                            if (touchingWallRight)
                            {

                                if (swipeSpeed < -maxSwipe)
                                {
                                    swipeSpeed = -maxjumpSpeed;
                                }
                                if (swipeSpeed > -minSwipe)
                                {
                                    swipeSpeed = -minjumpSpeed;
                                }



                            float force = swipeSpeed * jumpSpeed;
                                Debug.Log(force);
                                rb.AddForce(Vector2.right * force * Time.deltaTime,ForceMode2D.Impulse);
                            Debug.Log(swipeSpeed + "    " + force);
                            touchingWallLeft = false;
                                touchingWallRight = false;
                                rb.gravityScale = 2.5f;
                        }
                    }
                    
                }

                
            }

        }
        prevYVelocity = rb.velocity.y;
        #endregion
        }
        #region fx
            // Smoke trails only on if the player is sliding on wall
            var rightem = partRightSlide.emission;
            var leftem = partLeftSlide.emission;
            rightem.rateOverTime = touchingWallRight && !dead ? 4 : 0;
            leftem.rateOverTime = touchingWallLeft && !dead ? 4 : 0;
            

        #endregion
    }




    void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.transform.CompareTag("death"))
        {
            sr.enabled = false;
            dead = true;
            ws.gravity = 0;
            ws.speed = 0;
            ws.gravityVel = 0f;
            ws.minFallSpeed = 0f;
            ws.pixelsPerTick = 0;
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("leftWall"))
        {
            touchingWallLeft = true;
            //ws.speed -= rb.velocity.y;
            rb.gravityScale = 0f;
            ws.gravity = 0f;
            ws.gravityVel = 0f;
            rb.velocity = new Vector2(0, ws.speed*16);
            
        }
        if (collision.transform.CompareTag("rightWall"))
        {
            touchingWallRight = true;
            //ws.speed -= rb.velocity.y;
            rb.gravityScale = 0f;
            ws.gravity =0f;
            ws.gravityVel = 0f;
            rb.velocity = new Vector2(0, ws.speed*16);
            
        }

        if (collision.transform.CompareTag("ceil"))
        {
            rb.gravityScale = 0f;
            ws.gravity = 0f;
            ws.gravityVel = 0f;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            
        }

        if(collision.transform.CompareTag("floor"))
        {
            ws.pixelsPerTick += -rb.velocity.y;
            rb.gravityScale = 0f;
            ws.gravity = 2.5f;

            
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
