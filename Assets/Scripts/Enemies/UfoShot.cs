using UnityEngine;
using System.Collections;

public class UfoShot : MonoBehaviour {

	// Update is called once per frame
	void Update () 
	{
		transform.Translate(0.2f, 0f, 0f, Space.Self);

		if (transform.position.x > 30 || transform.position.x < -30
			|| transform.position.y > 30 || transform.position.y < -30)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			PlayerController playerController = other.gameObject.GetComponent<PlayerController> ();
			// Register damage with player
			playerController.Damage ();
			// Make this object disappear
			GameObject.Destroy (gameObject);
		}
	
	}
}
