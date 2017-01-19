using UnityEngine;
using System.Collections;

public class TopScript : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other)
	{
		//stops the player from going any further up
		if (other.gameObject.tag == "Player") 
		{
			PlayerController playerController = other.gameObject.GetComponent<PlayerController> ();
			playerController.settopCol (true);
		} 
		//changes the boss's direction
		else if (other.gameObject.tag == "Boss")
		{
			BossScroller scroller = other.gameObject.GetComponentInParent<BossScroller> ();
			if (scroller.getdie () != true) 
			{
				int y = scroller.getYSpeed ();
				scroller.setYSpeed (y * -1);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		//allows the player to go up again after colliding with the bound
		if (other.gameObject.tag == "Player") 
		{

			PlayerController playerController = other.gameObject.GetComponent<PlayerController> ();
			playerController.settopCol (false);
		}
	
	}

}
