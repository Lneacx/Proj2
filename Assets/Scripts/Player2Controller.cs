using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {

    Animator anim;
    GameObject Player;
    Rigidbody2D playerRB;
    public bool bodyContact;
    public bool feetContact;
    public float movespeed;
    public float maxspeed;
    public float jumpforce;

    int FloorLayer;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Player = gameObject.GetComponent<GameObject>();
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animate();
        float MoveHor = Input.GetAxisRaw("P2Horizontal");
        Vector2 movement = new Vector2(MoveHor * movespeed, 0);
        movement = movement * Time.deltaTime;

        if (Input.GetButtonDown("P2Crouch") || Input.GetButton("P2Crouch"))
        {
            gameObject.GetComponent<Health>().Blocking = true;
        }
        else
        {
            gameObject.GetComponent<Health>().Blocking = false;
        }

        if (feetContact && !gameObject.GetComponent<Health>().Blocking)
        {
            playerRB.AddForce(movement);
            if (playerRB.velocity.x > maxspeed)
            {
                playerRB.velocity = new Vector2(maxspeed, playerRB.velocity.y);
            }
            if (playerRB.velocity.x < -maxspeed)
            {
                playerRB.velocity = new Vector2(-maxspeed, playerRB.velocity.y);

            }
            if (Input.GetButtonDown("P2Jump") && canJump())
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
                playerRB.AddForce(new Vector2(0, jumpforce));
            }
        }
    }

    // Animating function for Left Player
    void animate()
    {
        animateWalking();
        animateJumping();
        animateCrouching();
        animateAttack();
    }

    void animateWalking()
    {
        if (Input.GetButton("P2Horizontal"))
        {
            anim.SetInteger("Walk", 1);
        }
        if (Input.GetButtonUp("P2Horizontal"))
        {
            anim.SetInteger("Walk", 0);
        }
    }

    void animateJumping()
    {
        if (Input.GetButtonDown("P2Jump"))
        {
            anim.SetInteger("Jump", 1);
        }
        if (Input.GetButtonUp("P2Jump"))
        {
            anim.SetInteger("Jump", 0);
        }
    }

    void animateCrouching()
    {
        if (Input.GetButtonDown("P2Crouch"))
        {
            anim.SetInteger("Crouching", 1);
        }
        if (Input.GetButtonUp("P2Crouch"))
        {
            anim.SetInteger("Crouching", 0);
        }
    }

    void animateAttack()
    {
        if (Input.GetButtonDown("P2Attack"))
        {
            anim.SetInteger("Attack", 1);
        }
        if (Input.GetButtonUp("P2Attack"))
        {
            anim.SetInteger("Attack", 0);
        }
    }

    bool canJump()
    {
        return feetContact == true && bodyContact == false;
    }
}
