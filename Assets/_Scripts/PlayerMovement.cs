using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private Animator _animator;
    private bool _canJump = false;
    private int _jumpCount = 0;
    private Vector3 _startPosition;
    private AudioSource _jumpSound;
    private AudioSource _pickupSound;
    
    public int Score = 0;

    public float Speed;
    public float JumpForce;



	// Use this for initialization
	void Start ()
	{
	    _animator = GetComponent<Animator>();
        _startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	    _jumpSound = GetComponents<AudioSource>()[0];
        
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
                _jumpSound.Play();
	        }

	    }

        CheckRotation();

	    if (transform.position.y < -30)
	    {
	        Reset();
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

    private void Reset()
    {
        transform.eulerAngles = new Vector3(0,0,0);
        transform.position = _startPosition;
    }

    private void CheckRotation()
    {
        
        if (transform.eulerAngles.z > 60 && transform.eulerAngles.z < 300)
        {
            GetComponent<Rigidbody2D>().Sleep();
            if (transform.eulerAngles.z <= 180)
            {
                transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(transform.eulerAngles.z, 1, 0.05f));
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, Mathf.Lerp(transform.eulerAngles.z, 359, 0.05f));
            }
        }
    }
}
