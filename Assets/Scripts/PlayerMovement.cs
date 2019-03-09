using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float movement;

    Rigidbody2D rB2D;

    public float jumpVelocity = 3f;

    public float speed = 1.333f;

    bool isCrouch = false;

    bool isAir = false;

    bool isManaEmpty = false;

    public Animator animator;

    public ShieldController shieldControll;

    public ManaBar manabar;
    
    SpriteRenderer SR;


	// Use this for initialization
	void Start () {

        SR = GetComponent<SpriteRenderer>();

        rB2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        Movement();

        Animation();
    }

    //------------------ Służy do obliczeń itp odnośnie controlera postaci------------------
    void Movement()
    {
        if (isCrouch == true)
        {
            movement = 0;
            jumpVelocity = 0;
        }
        else
        {
            jumpVelocity = 2.9f;
        }

        movement = Input.GetAxisRaw("Horizontal");

        if (movement > 0)
        {
            SR.flipX = false;

        }
        else if (movement < 0)
        {
            SR.flipX = true;
        }

        this.transform.position += new Vector3(movement * speed * Time.deltaTime, 0, 0);
    }

    //------------------skrypt do animowania postaci------------------
    void Animation()
    {
        if (rB2D.velocity.y > 0.1f)
        {
            animator.SetBool("IsJump", true);
            isAir = true;
        }
        else if(rB2D.velocity.y < -0.1f)
        {
            animator.SetBool("IsFall", true);
            animator.SetBool("IsJump", false);
            isAir = true;
        }
        else if(rB2D.velocity.y == 0)
        {
            animator.SetBool("IsFall", false);
            animator.SetBool("IsJump", false);
            isAir = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rB2D.velocity.y == 0)
            {
                rB2D.AddForce(transform.up * jumpVelocity, ForceMode2D.Impulse);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if(isManaEmpty == true)
            {
                speed = 1.333f;
                animator.SetBool("IsCrouch", false);
                isCrouch = false;
                shieldControll.Disable();
                return;
            }
            if (isAir == true) { return; }
            manabar.ShieldWhenS();
            speed = 0;
            animator.SetBool("IsCrouch", true);
            isCrouch = true;
            animator.SetFloat("Speed", 0);
            shieldControll.Enable();
            if(manabar.mana.manaAmount <= 2)
            {
                isManaEmpty = true;
            }
            return;
        }
        else
        {
            if(manabar.mana.manaAmount >= 2)
            {
                isManaEmpty = false;
            }
            speed = 1.333f;
            animator.SetBool("IsCrouch", false);
            isCrouch = false;
            shieldControll.Disable();
        }

        animator.SetFloat("Speed", Mathf.Abs(movement));
    }
    
}