using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;

    private Rigidbody2D playerRb;
    //private BoxCollider2D playerBC;
    private Animator animator;

    private float horizontal;
    private bool triggerJump = false;
    public bool isGrounded = false;

    private AudioSource footsteps;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;

        playerRb = GetComponent<Rigidbody2D>();
        //playerBC = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        footsteps = GetComponent<AudioSource>();
    }

    // for input
    private void Update()
    {
        // movement input
        horizontal = Input.GetAxis("Horizontal");

        // jump input
        triggerJump = Input.GetKey(KeyCode.W);

        PlayFootsteps();
    }

    // for physics
    void FixedUpdate()
    {
        // movement left/right
        playerRb.velocity = new Vector2(horizontal * speed, playerRb.velocity.y);

        // flip direction
        flipDirection();

        // jump
        if (triggerJump && isGrounded)
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // set parameters
        SetParameters();
    }

    private void flipDirection()
    {
        float newScaleX;
        bool directionChange = false;

        if (playerRb.velocity.x > 0)
        {
            newScaleX = Mathf.Abs(transform.localScale.x);
            directionChange = true;
        }
        else if (playerRb.velocity.x < 0)
        {
            newScaleX = Mathf.Abs(transform.localScale.x) * -1;
            directionChange = true;
        }
        else newScaleX = transform.localScale.x;

        if (directionChange)
            transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void SetParameters()
    {
        animator.SetFloat("Speed", Mathf.Abs(playerRb.velocity.x));
    }

    private void PlayFootsteps()
    {
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) && !footsteps.isPlaying && isGrounded)
            footsteps.Play();
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) && footsteps.isPlaying && isGrounded)
            footsteps.UnPause();
        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) && footsteps.isPlaying)
            footsteps.Pause();
        if (!isGrounded && footsteps.isPlaying)
            footsteps.Pause();
    }
}
