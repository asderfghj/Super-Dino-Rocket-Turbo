using UnityEngine;
using System.Collections;

public class BossShoot : MonoBehaviour 
{

	private int shotspeed = 50;
	private int counter;
	public GameObject bullet;

	// Update is called once per frame
	void FixedUpdate () 
	{
		//limits when the boss can shoot
		counter++;
		if (counter % shotspeed == 0)
		{
			shoot ();
		}
	}

	private void shoot()
	{
		//instantiates bullets depending on the health
		Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, 180));
		if (shotspeed <= 30) 
		{
			Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, 205));
			Instantiate (bullet, transform.position, Quaternion.Euler (0, 0, 155));
		} 
		counter = 0;
	}

	public void setshotspeed(int _shotspeed)
	{
		shotspeed = _shotspeed;
	}
}
