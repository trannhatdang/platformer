using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static Player instance;
	[SerializeField] Rigidbody2D rb;
	[SerializeField] float Horizontal = 0.0f;
	[SerializeField] float Vertical = 0.0f;
	[SerializeField] float Speed = 0.0f;
	[SerializeField] float JumpPower = 0.0f;
	bool facingleft = true;
	[SerializeField] float velocityY = 0.0f;
	[SerializeField] Animator anim;
	
	void Awake()
	{
		if(instance && instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			instance = this;
		}
	}

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	void Update()
	{
	    Horizontal = Input.GetAxisRaw("Horizontal");

	    //MOVEMENT
	    velocityY = rb.velocity.y;
	    rb.AddForce(new Vector2(Horizontal * Speed * Time.fixedDeltaTime,0));
	    if(Input.GetKeyDown(KeyCode.Space))
	    {
		    rb.AddForce(new Vector2(0, JumpPower));
	    }

	    if(Horizontal > 0 && !facingleft)
	    {
		    this.gameObject.transform.Rotate(0, -180, 0);
		    facingleft = true;
	    }
	    else if(Horizontal < 0 && facingleft) 
	    {
		    this.gameObject.transform.Rotate(0, 180, 0);
		    facingleft = false;
	    }


	    //ANIM
	    anim.SetFloat("Horizontal", Mathf.Abs(Horizontal));
	    if(velocityY > 0.5f)
	    {
		    anim.SetBool("Jump", true);
		    anim.SetBool("Fall", false);
		    anim.SetBool("Land", false);
	    }
	    else if(velocityY < -0.5f)
	    {
		    anim.SetBool("Fall", true);
		    anim.SetBool("Jump", false);
		    anim.SetBool("Land", false);
	    }
	    else if(Mathf.Abs(velocityY) < 0.5f)
	    {
		    anim.SetBool("Land", true);
		    anim.SetBool("Jump", false);
		    anim.SetBool("Fall", false);
	    }

	}
}
