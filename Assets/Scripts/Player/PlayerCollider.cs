using UnityEngine;


public class PlayerCollider : MonoBehaviour
{
    private bool m_readyToKill = false;
    private SpriteRenderer sprite;
	public AudioSource hit;

	private void Start()
	{
        sprite = GetComponent<SpriteRenderer>();
	}

    void Update()
    {
		if (m_readyToKill && !hit.isPlaying) 
		{
			GameObject.Destroy (this.gameObject);
		}
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		//makes the player take damage and destroys the enemy
		if (other.gameObject.tag == "Player") 
		{
            hit.Play();
			Debug.Log ("soundplay");
			PlayerController playerController = other.gameObject.GetComponent<PlayerController> ();
			// Register damage with player
			playerController.Damage ();
            sprite.enabled = false;
            m_readyToKill = true;
		}
  	}
}
