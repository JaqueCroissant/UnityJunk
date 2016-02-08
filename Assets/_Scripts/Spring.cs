using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour
{

    public float JumpForce;

    private GameObject _player;

	// Use this for initialization
	void Start () {
	    _player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        _player.GetComponent<Rigidbody2D>().Sleep();
        _player.GetComponent<Rigidbody2D>().AddForce(new Vector3(0,JumpForce,0));
    }
}
