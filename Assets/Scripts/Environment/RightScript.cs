using UnityEngine;
using System.Collections;

public class RightScript : MonoBehaviour {

	private GameObject boss;

	private void OnTriggerEnter2D(Collider2D other)
	{
		//stops the player from going out of bounds
		if (other.gameObject.tag == "Player") 
		{

			PlayerController playerController = other.gameObject.GetComponent<PlayerController> ();
			playerController.setrightCol (true);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		//allows the player to go right after colliding with the bound
		if (other.gameObject.tag == "Player") 
		{
			PlayerController playerController = other.gameObject.GetComponent<PlayerController> ();
			playerController.setrightCol (false);
		} 
		//stops the boss from going any further right and makes the boss go up
		else if (other.gameObject.tag == "Boss")
		{
			BossScroller scroller = other.gameObject.GetComponent<BossScroller> ();

			scroller.setXSpeed (0);
			scroller.setYSpeed (4);
		}

	}

}
