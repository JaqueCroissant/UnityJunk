using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour
{

    private AudioSource _coinSound;
    private PlayerMovement _player;
    

    // Use this for initialization
    void Start ()
	{
        _player = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;

        _coinSound = GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>()[1];
	}
	
	// Update is called once per frame
	void Update () {
        
        _player.GetComponentsInChildren<TextMesh>()[0].text = "Score: " + _player.Score;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _player.Score++;
        if (_coinSound.isPlaying)
        {
            _coinSound.Stop();
        }
        _coinSound.Play();
        Destroy(this.gameObject);
    }
}
