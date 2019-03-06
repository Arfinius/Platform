using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Vector3 movement;

    Rigidbody2D rB2D;

    public float jumpVelocity = 2f;

    public float speed = 1.333f;

    SpriteRenderer SR;

	// Use this for initialization
	void Start () {

        movement = new Vector3(0.0f, 0.0f, 0.0f);

        SR = GetComponent<SpriteRenderer>();

        rB2D = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        

        movement.x = Input.GetAxisRaw("Horizontal");

        transform.position += (movement * speed * Time.deltaTime);


        if(Input.GetKeyDown(KeyCode.Space))
        { 
            if(rB2D.velocity.y == 0)
            {
                rB2D.AddForce(transform.up * jumpVelocity, ForceMode2D.Impulse);
            }
        }

        


        if(movement.x > 0)
        {
            SR.flipX = false;

        }
        else if(movement.x < 0)
        {
            SR.flipX = true;
        }
        
        
	}
}
