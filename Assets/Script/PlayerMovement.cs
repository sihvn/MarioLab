using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float maxSpeed = 20;
    private Rigidbody2D marioBody;

    public float upSpeed = 10;
    private bool onGroundState = true;

    // global variables
    private SpriteRenderer marioSprite;
    private bool faceRightState = true;

    public GameObject enemies;
    public JumpOverGoomba jumpOverGoomba;
    public GameObject inGameScene;
    public GameObject gameOverScene;
    public Animator marioAnimator;
    public AudioSource marioAudio;
    public AudioSource marioDeath;
    public AudioSource enemyDeath;
    public float deathImpulse = 45;
    public Transform gameCamera;

    GameObject Goomba;


    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7);
    public MarioAction marioActions;
    public GameManager gameManager;
    public Sprite GoombaFlat;

    Vector3 prevPosition;
    Vector3 velocity;

    // state
    [System.NonSerialized]
    public bool alive = true;
    private bool moving = false;
    private bool jumpedState = false;


    // Start is called before the first frame update
    void Start()
    {
        marioActions = new MarioAction();
        marioActions.gameplay.Enable();
        // Set to be 30 FPS
        Application.targetFrameRate = 30;
        marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>();

        marioAnimator.SetBool("onGround", onGroundState);
        prevPosition = transform.position;

    }
    void PlayDeathImpulse()
    {
        marioBody.AddForce(Vector2.up * deathImpulse, ForceMode2D.Impulse);
    }

    void GameOverScene()
    {
        // stop time
        Time.timeScale = 0.0f;
        gameManager.GameOver();

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Goomba = other.gameObject;
            //     //Debug.Log("Collided with goomba!");

            //     // play death animation
            //     // marioAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
            //     Vector3 contactPoint = other.
            if (velocity.y < 0)
            {
                enemyDeath.PlayOneShot(enemyDeath.clip);
                other.gameObject.GetComponent<SpriteRenderer>().sprite = GoombaFlat;
                gameManager.IncreaseScore(1);
                // other.gameObject.SetActive(false);
                Invoke("ActivateObject", 0.2f);
            }
            else
            {
                marioAnimator.Play("Mario_die");
                marioDeath.PlayOneShot(marioDeath.clip);
                alive = false;
            }

        }

    }
    void ActivateObject()
    {
        Goomba.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        marioAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));
        Vector3 currentPosition = transform.position;
        velocity = (currentPosition - prevPosition) / Time.deltaTime;
        prevPosition = currentPosition;
    }
    void FlipMarioSprite(int value)
    {
        if (value == -1 && faceRightState)
        {
            faceRightState = false;
            marioSprite.flipX = true;
            if (marioBody.velocity.x > 0.05f)
                marioAnimator.SetTrigger("onSkid");

        }

        else if (value == 1 && !faceRightState)
        {
            faceRightState = true;
            marioSprite.flipX = false;
            if (marioBody.velocity.x < -0.05f)
                marioAnimator.SetTrigger("onSkid");
        }
    }
    public void Jump()
    {
        if (alive && onGroundState)
        {
            // jump
            marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;
            jumpedState = true;
            // update animator state
            marioAnimator.SetBool("onGround", onGroundState);

        }
    }
    public void JumpHold()
    {
        if (alive && jumpedState)
        {
            // jump higher
            marioBody.AddForce(Vector2.up * upSpeed * 30, ForceMode2D.Force);
            jumpedState = false;

        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if ((col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("Enemies") || col.gameObject.CompareTag("Obstacles")) && !onGroundState)
        if (((collisionLayerMask & (1 << col.transform.gameObject.layer)) > 0) & !onGroundState)
        {
            onGroundState = true;
            // update animator state
            marioAnimator.SetBool("onGround", onGroundState);
        }
    }


    // FixedUpdate may be called once per frame. See documentation for details.
    void FixedUpdate()
    {
        if (alive && moving)
        {
            Move(faceRightState == true ? 1 : -1);
        }

    }
    void Move(int value)
    {

        Vector2 movement = new Vector2(value, 0);
        // check if it doesn't go beyond maxSpeed
        if (marioBody.velocity.magnitude < maxSpeed)
            marioBody.AddForce(movement * speed);
    }

    public void MoveCheck(int value)
    {
        if (value == 0)
        {
            moving = false;
        }
        else
        {
            FlipMarioSprite(value);
            moving = true;
            Move(value);
        }
    }
    public void RestartButtonCallback(int input)
    {
        Debug.Log("Restart!");
        // reset everything
        ResetGame();
        // resume time
        Time.timeScale = 1.0f;
    }

    public void ResetGame()
    {
        // reset position
        marioBody.transform.position = new Vector3(-4.0f, -3.43f, 0.0f);
        // reset sprite direction
        faceRightState = true;
        marioSprite.flipX = false;

        // reset animation
        marioAnimator.SetTrigger("gameRestart");
        alive = true;

        // reset camera position
        gameCamera.position = new Vector3(0, 0, -10);

    }

    void PlayJumpSound()
    {
        // play jump sound
        marioAudio.PlayOneShot(marioAudio.clip);
    }
}