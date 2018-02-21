using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Animator anim;
    GameObject Player;
    Rigidbody2D playerRB;
    CircleCollider2D playerSword;
    public bool bodyContact;
    public bool feetContact;
    public float movespeed;
    public float maxspeed;
    public float jumpforce;

    int FloorLayer;

    private bool to_jump;
    private bool to_crouch;
    private bool facingRight;
    private bool to_attack;

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator>();
        Player = gameObject.GetComponent<GameObject>();
        playerRB = gameObject.GetComponent<Rigidbody2D>();
        playerSword = transform.Find("Sword").GetComponent<CircleCollider2D>();
        to_jump = false;
        to_crouch = false;
        facingRight = true;
        to_attack = false;
	}

    // Update is called once per frame
    private void Update ()
    {
        animate();
        if (Input.GetButtonDown("P1Jump") && feetContact)
        {
            to_jump = true;
        }
        to_crouch = Input.GetButton("P1Crouch") && feetContact;
        if (Input.GetButtonDown("P1Attack") && feetContact)
        {
            to_attack = true;
        }
    }

    void FixedUpdate () {
        gameObject.GetComponent<Health>().Blocking = to_crouch;
        playerSword.enabled = false;
        if (!to_crouch)
        {
            float MoveHor = Input.GetAxisRaw("P1Horizontal");
            Vector2 movement = new Vector2(MoveHor * movespeed, 0);
            playerRB.AddForce(movement);
            if (playerRB.velocity.x > maxspeed)
            {
                playerRB.velocity = new Vector2(maxspeed, playerRB.velocity.y);
            }
            if (playerRB.velocity.x < -maxspeed)
            {
                playerRB.velocity = new Vector2(-maxspeed, playerRB.velocity.y);

            }
            if (to_jump)
            {
                playerRB.AddForce(new Vector2(playerRB.velocity.x, jumpforce));
                to_jump = false;
            }
            if (to_attack)
            {
                playerSword.enabled = true;
                to_attack = false;
            }
        }
    }

	// Animating function for Left Player
	void animate() {
        if (!feetContact)
        {
            anim.SetInteger("Jump", 1);
        } else
        {
            anim.SetInteger("Jump", 0);
        }
        if (to_crouch)
        {
            anim.SetInteger("Crouching", 1);
        } else
        {
            anim.SetInteger("Crouching", 0);
        }
        if (feetContact && playerRB.velocity.x != 0)
        {
            anim.SetInteger("Walk", 1);
        } else
        {
            anim.SetInteger("Walk", 0);
        }
        if (facingRight && Input.GetAxisRaw("P1Horizontal") < 0 || !facingRight && Input.GetAxisRaw("P1Horizontal") > 0)
        {
            facingRight = !facingRight;
            Vector2 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
		animateAttack();
	}

	void animateAttack () {
		if (Input.GetButtonDown("P1Attack")) {
			anim.SetInteger("Attack", 1);
		}
		if (Input.GetButtonUp("P1Attack")) {
			anim.SetInteger("Attack", 0);
		}
	}
}
