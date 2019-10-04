using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Vector2 startTouchPos;

    public float swipeMultiplier;

    //public float jumpSpeed;

    public bool touchingWallRight;
    public bool touchingWallLeft;

    public float friction;

   // public float gravityWallSlideModifier;

    public float startTouchTime;

    public float swipeTimeCutOff;

    //public float ledgeBoost = 1f;

    public float cliffGrabVelocityDampen = 0.75f;

    private float prevYVelocity;

    public float camOffset;

    public Sprite[] playerPoses;

    public float cameraLerpTime;

    public float playerGravity;

    public float force;

    public enum playerState {SLIDING, JUMPING, READYJUMP, DEATH};
   // public float climbingSpeed;
    public playerState state = playerState.SLIDING;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public ParticleSystem partLeftSlide;
    public ParticleSystem partRightSlide;

    public WallScroll ws;
    public GameObject blood;


    [Header("SFX")]
    public AudioClip jump,wallHit,die,slow;
    private AudioSource audioSource;
   // UI_FallDistance distanceScore; 

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.flipX = !sr.flipX;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (state != playerState.DEATH)
        {
            #region gameplaycode
            if (Input.touchCount > 0 && Input.touchSupported && false)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    startTouchTime = Time.time;
                    startTouchPos = touch.position;
                }

                if (touch.phase == TouchPhase.Stationary)
                {
                    //  Debug.Log("velocity y = " + rb.velocity.y);
                    ws.gravityVel = ws.gravityVel * friction;

                    //rb.velocity = new Vector2(0,rb.velocity.y * friction );
                    state = playerState.READYJUMP;
                }

                if (touch.phase == TouchPhase.Moved)
                {

                }

                if (touch.phase == TouchPhase.Ended)
                {
                    // only takes into consideration a horizontal swipe (possibly change) 
                    float deltaPosition = Camera.main.ScreenToWorldPoint(Vector2.right * (touch.position.x - startTouchPos.x)).x;

                    float swipeTime = Time.time - startTouchTime;
                    //float swipeSpeed = deltaPosition / swipeTime;
                    float swipeSpeed = swipeMultiplier * deltaPosition / swipeTime;
                    state = playerState.SLIDING;
                    // check if the start of the swipe was performed recently
                    if (swipeTime < swipeTimeCutOff)
                    {

                        Debug.Log("SWIPE TIME " + swipeTime + "    deltaPosition" + deltaPosition);

                        if (deltaPosition > 0)
                        {
                            if (touchingWallLeft)
                            {
                                state = playerState.JUMPING;
                                audioSource.PlayOneShot(jump);

                                //rb.AddForce(Vector2.right * swipeSpeed * Time.deltaTime * jumpSpeed + new Vector2( -rb.velocity.y * gravityWallSlideModifier, 0), ForceMode2D.Impulse);
                                rb.AddForce(Vector2.right * force / swipeTime, ForceMode2D.Impulse);
                                Debug.Log(swipeSpeed + "    " + force);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                //rb.gravityScale = 2.5f;
                                ws.gravity = playerGravity;
                            }
                        }
                        else if (deltaPosition < 0)
                        {
                            if (touchingWallRight)
                            {
                                state = playerState.JUMPING;
                                audioSource.PlayOneShot(jump);

                                Debug.Log(force);
                                rb.AddForce(Vector2.left * force / swipeTime, ForceMode2D.Impulse);
                                Debug.Log(swipeSpeed + "    " + force);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                //rb.gravityScale = 2.5f;
                                ws.gravity = playerGravity;
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

                    //  Debug.Log("velocity y = " + rb.velocity.y);
                    ws.gravityVel = ws.gravityVel * friction;

                    //rb.velocity = new Vector2(0,rb.velocity.y * friction );
                    state = playerState.READYJUMP;
                }


                if (Input.GetMouseButtonUp(0) && (touchingWallLeft || touchingWallRight))
                {
                    // only takes into consideration a horizontal swipe (possibly change) 
                    float deltaPosition = Camera.main.ScreenToWorldPoint(Vector2.right * (Input.mousePosition.x - startTouchPos.x)).x;

                    float swipeTime = Time.time - startTouchTime;
                    //float swipeSpeed = deltaPosition / swipeTime;
                    float swipeSpeed = deltaPosition / swipeTime;
                    state = playerState.SLIDING;
                    // check if the start of the swipe was performed recently
                    if (swipeTime < swipeTimeCutOff)
                    {

                        //Debug.Log("SWIPE TIME " + swipeTime + "    deltaPosition" + deltaPosition);

                        if (deltaPosition > 0)
                        {
                            if (touchingWallLeft)
                            {
                                state = playerState.JUMPING;
                                audioSource.PlayOneShot(jump);
                                rb.AddForce(Vector2.right * force/swipeTime, ForceMode2D.Impulse);
                               // Debug.Log(swipeSpeed + "    " + force);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                //rb.gravityScale = 2.5f;
                                ws.gravity = playerGravity;
                            }
                        }
                        else if (deltaPosition < 0)
                        {
                            if (touchingWallRight)
                            {
                                state = playerState.JUMPING;

                                audioSource.PlayOneShot(jump);
                                //Debug.Log(force);
                                rb.AddForce(Vector2.left * force / swipeTime, ForceMode2D.Impulse);
                                //Debug.Log(swipeSpeed + "    " + force);
                                touchingWallLeft = false;
                                touchingWallRight = false;
                                //rb.gravityScale = 2.5f;
                                ws.gravity = playerGravity;
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
        
        if(state != playerState.READYJUMP)
        {
        rightem.rateOverTime = touchingWallRight && state != playerState.DEATH ? 8 : 0;
        leftem.rateOverTime = touchingWallLeft && state != playerState.DEATH ? 8 : 0;
        }
        else
        {
             rightem.rateOverTime = touchingWallRight && state != playerState.DEATH ? 32 : 0;
            leftem.rateOverTime = touchingWallLeft && state != playerState.DEATH ? 32 : 0;

        }

        #endregion

        #region Player State
        switch (state)
        {
            case playerState.SLIDING:
                sr.sprite = playerPoses[0];
                break;
            case playerState.READYJUMP:
                sr.sprite = playerPoses[1];
                //if(!audioSource.isPlaying)
                //audioSource.PlayOneShot(slow);
                break;
            case playerState.JUMPING:
                sr.sprite = playerPoses[2];
                break;
            case playerState.DEATH:
                sr.sprite = playerPoses[3];
                break;
        }
        #endregion
    }




    private void LateUpdate()
    {
        //transform.position = new Vector2(transform.position.x,)
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x,Mathf.Lerp(Camera.main.transform.position.y, transform.position.y+(ws.speed) + camOffset, Time.deltaTime * cameraLerpTime),Camera.main.transform.position.z);
    }



    void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.transform.CompareTag("death"))
        {
            rb.bodyType = RigidbodyType2D.Static;
           // sr.enabled = false;

            state = playerState.DEATH;
            audioSource.PlayOneShot(die);
            sr.sprite = playerPoses[3];

            ws.gravity = 0;
            ws.speed = 0;
            ws.gravityVel = 0f;
            ws.minFallSpeed = 0f;
            ws.pixelsPerTick = 0;
            transform.position = collider.transform.position;
            Instantiate(blood, transform);
            
            Invoke("restart", 1.5f);
            PlayerPrefs.Save();
           
            
        }

        
    }

    void restart()
    {
        SceneManager.LoadScene("MainMenu1");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("leftWall"))
        {
            audioSource.PlayOneShot(wallHit);
            touchingWallLeft = true;
            //ws.speed -= rb.velocity.y;

            ws.gravity = 0f;
            ws.gravityVel *= cliffGrabVelocityDampen;
            
            // TODO:
           // rb.velocity = new Vector2(0, rb.velocity.y* cliffGrabVelocityDampen);

            state = playerState.SLIDING;
            sr.flipX = !sr.flipX; 
            
        }
        if (collision.transform.CompareTag("rightWall"))
        {
            audioSource.PlayOneShot(wallHit);
            touchingWallRight = true;
            //ws.speed -= rb.velocity.y;
            //rb.gravityScale = 0f;
            ws.gravity = 0f;
            ws.gravityVel *= cliffGrabVelocityDampen;

            // TODO:
            //rb.velocity = new Vector2(0, rb.velocity.y* cliffGrabVelocityDampen);


            state = playerState.SLIDING;
            sr.flipX = !sr.flipX;
            
        }

        if (collision.transform.CompareTag("ceil"))
        {
            
            ws.gravity = 0f;
            ws.gravityVel = 0f;
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            
        }

        if(collision.transform.CompareTag("floor"))
        {
           
            rb.gravityScale = 0f;
            //ws.gravity = 2.5f;

            
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}
