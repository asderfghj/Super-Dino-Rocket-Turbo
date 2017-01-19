using UnityEngine;
using UnityEngine.UI;

/*
 * On screen HUD to display current health.
 */
public class PlayerHud : MonoBehaviour
{
	private GameObject player;
	private PlayerController playerController;
	private GameObject Heart1;
	private GameObject HalfHeart1;
	private GameObject Heart2;
	private GameObject HalfHeart2;
	private GameObject Heart3;
	private GameObject HalfHeart3;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	    playerController = player.GetComponent<PlayerController>();
		Heart1 = GameObject.Find ("Heart1");
		HalfHeart1 = GameObject.Find ("HalfHeart1");
		Heart2 = GameObject.Find ("Heart2");
		HalfHeart2 = GameObject.Find ("HalfHeart2");
		Heart3 = GameObject.Find ("Heart3");
		HalfHeart3 = GameObject.Find ("HalfHeart3");
		HalfHeart1.SetActive (false);
		HalfHeart2.SetActive (false);
		HalfHeart3.SetActive (false);
	}

	private void Update()
	{
		//displays the player health on the canvas
        if (playerController.GetHealth() >= 6)
        {
            Heart3.SetActive(true);
            HalfHeart3.SetActive(false);
            Heart2.SetActive(true);
            HalfHeart2.SetActive(false);
            Heart1.SetActive(true);
            HalfHeart1.SetActive(false);
        }
		if (playerController.GetHealth () == 5) 
		{
            Heart3.SetActive(false);
            HalfHeart3.SetActive(true);
            Heart2.SetActive(true);
            HalfHeart2.SetActive(false);
            Heart1.SetActive(true);
            HalfHeart1.SetActive(false); ;
		} 

		else if (playerController.GetHealth () == 4) 
		{
            HalfHeart3.SetActive(false);
            Heart2.SetActive(true);
            HalfHeart2.SetActive(false);
            Heart1.SetActive(true);
            HalfHeart1.SetActive(false);
        } 

		else if (playerController.GetHealth () == 3) 
		{
            Heart2.SetActive(false);
            HalfHeart2.SetActive(true);
            Heart1.SetActive(true);
            HalfHeart1.SetActive(false);
        }

		else if (playerController.GetHealth () == 2) 
		{
            HalfHeart2.SetActive(false);
            Heart1.SetActive(true);
            HalfHeart1.SetActive(false);
        }

		else if (playerController.GetHealth () == 1) 
		{
            Heart1.SetActive(false);
            HalfHeart1.SetActive(true);
        }

		else if (playerController.GetHealth () == 0) 
		{
            HalfHeart1.SetActive(false);
        }
	}

}
