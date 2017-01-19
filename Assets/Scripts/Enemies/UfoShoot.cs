using UnityEngine;
using System.Collections;

public class UfoShoot : MonoBehaviour 
{

	public GameObject bullet;
	private int counter = 0;

	// Use this for initialization
	void FixedUpdate () 
	{
		
		counter++;
		if (counter % 50 == 0)
		{
			shoot ();
		}
	}
	
	// Update is called once per frame


	private void shoot ()
	{
		//checks the rotation (if the player has shot a UFO it spins, this stops the bullets from firing while the UFO falling off screen) 
		if (transform.rotation.z == 0)
		{
			if (counter == 50)
			{
				Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, 45));
				Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, 135));
				Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, 225));
				Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, 315));
			} 
			else if (counter == 100) 
			{
				Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, 0));
				Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, 90));
				Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, 180));
				Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, 270));
				counter = 0;
			}
		}
		//ensures the UFO will not shoot again after the player has killed it.
		else
		{
			counter = 101;
		}
	}
}
