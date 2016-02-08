using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private Animator _animator;
    private bool _canJump = false;
    private int _jumpCount = 0;

    public float Speed;
    public float JumpForce;



	// Use this for initialization
	void Start ()
	{
	    _animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetAxis("Horizontal") != 0)
	    {
	        _animator.SetBool("IsWalking", true);
            transform.position += new Vector3(Input.GetAxis("Horizontal")*Speed,0,0);
	    }
	    else
	    {
	        _animator.SetBool("IsWalking", false);
	    }

	    if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
	    {
	        if (_canJump || _jumpCount < 2)
	        {
	            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpForce));
	            _jumpCount++;
	        }

	    }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        _canJump = true;
        _jumpCount = 0;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _canJump = false;
    }
}
