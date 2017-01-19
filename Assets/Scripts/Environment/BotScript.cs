using UnityEngine;
using System.Collections;

public class BotScript : MonoBehaviour
{

	private void OnTriggerEnter2D(Collider2D other)
	{
		//stops the player from going off screen
		if (other.gameObject.tag == "Player") 
		{
			PlayerController playerController = other.gameObject.GetComponent<PlayerController> ();
			playerController.setbotCol (true);
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
		//allows the player to move down again after colliding with this boundary
		if (other.gameObject.tag == "Player") 
		{
			PlayerController playerController = other.gameObject.GetComponent<PlayerController> ();
			playerController.setbotCol (false);
		}

	}
}
