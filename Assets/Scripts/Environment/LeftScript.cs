using UnityEngine;
using System.Collections;

public class LeftScript : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other)
	{
		//stops the player from going off screen
		if (other.gameObject.tag == "Player") 
		{
			PlayerController playerController = other.gameObject.GetComponent<PlayerController> ();
			playerController.setleftCol (true);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			//allows the player to move left again after colliding with this boundary
			PlayerController playerController = other.gameObject.GetComponent<PlayerController> ();
			playerController.setleftCol (false);
		}

	}
}
