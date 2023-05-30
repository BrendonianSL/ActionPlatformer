using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	//Creates Animator for script to manipulate
	public Animator animator;
	//Creates Rigidbody for script to manipulate
	public Rigidbody2D rb;
	//Determines RunSpeed of character
	public float runSpeed = 40f;
	//Variable for horizontalMove
	float horizontalMove = 0f;
	//Determines if character is currently jumping
	bool jump = false;
	//Determines if character is currently crouching
	bool crouch = false;

	private bool doubleJump;
	bool HardLanding;

	void Start()
    {
		
    }
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		//If jump button is held down then execute this statement
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			Debug.Log("Jump is" + jump + "Inside Jump Function");
			animator.SetBool("IsJumping", true);
			animator.SetBool("IG", false);
		}

		if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
			
        }

		//Statement checks that if key is held down, it will change speed until it is up.
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			runSpeed = 50f;
		} else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			runSpeed = 40f;
		}

	}

	public void OnLanding ()
	{
		jump = false;
		animator.SetFloat("yVelocity", 0);
		Debug.Log("Jump is " + jump + " Inside OnLanding");
		animator.SetBool("IsJumping", false);
		Debug.Log(animator.GetFloat("yVelocity"));
		animator.SetBool("IG", true);
		
		if(HardLanding == true)
        {
			animator.SetTrigger("Landing");
			HardLanding = false;
        }
	}

    public void OnCrouching (bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		
		animator.SetFloat("yVelocity", rb.velocity.y);

		//Statement checks if Jump is false and yvelocity is showing us falling
		if (animator.GetBool("IsJumping") == false && animator.GetFloat("yVelocity") < -5)
		{
			Debug.Log("Both became true");
			Debug.Log(animator.GetFloat("yVelocity"));
			Debug.Log(animator.GetBool("IsJumping"));
			animator.SetTrigger("Falling");
		}
		if (animator.GetBool("IsJumping") == false && animator.GetFloat("yVelocity") < -20)
		{
			HardLanding = true;
			Debug.Log("HardLanding is " + HardLanding + "Inside New Function");
		}
	}
}
