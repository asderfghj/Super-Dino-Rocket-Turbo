using UnityEngine;
using System.Collections;

public class Level1Gen : MonoBehaviour {

	private uint counter = 0;
	public GameObject mine;
	public GameObject UFO;
	public GameObject boss;
	public GameObject heal;
	public GameObject shield;
	public GameObject upgrade;
	private GameObject scorer;
	private ScoreManager score;
	private bool bossactive;

	void Start()
	{
		scorer = GameObject.Find ("ScoreText");
		score = scorer.GetComponent<ScoreManager> ();
	}


	void FixedUpdate () 
	{
		counter++;
		//will spawn at least one enemy every 35 miliseconds
		if (counter % 35 == 0 && !bossactive) 
		{
			//the difficulty increases based on the number of points the player has
			if (score.getscore () < 1000) 
			{
				Instantiate (mine, new Vector3 ((transform.position.x + Random.Range (-1.0f, 1.0f)), Random.Range (-4.0f, 4.0f), 0), Quaternion.identity);
			} 
			else if (score.getscore () >= 1000 && score.getscore () < 5000) 
			{
				Instantiate (mine, new Vector3 ((transform.position.x + Random.Range (-1.0f, 1.0f)), Random.Range (-4.0f, 4.0f), 0), Quaternion.identity);
				randomenemy ();
			} 
			else if (score.getscore () >= 5000 && score.getscore () < 10000)
			{
				Instantiate (UFO, new Vector3 ((transform.position.x + Random.Range (-1.0f, 1.0f)), Random.Range (-4.0f, 4.0f), 0), Quaternion.identity);
				randomenemy ();
			} 
			//at 10,000 points a boss enemy will spawn and stop everything else from spawning 
			else if (score.getscore () >= 10000 && score.getscore () < 11000) 
			{
				Instantiate (boss, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				bossactive = true;
			} 
			//after the player has defeated the boss 3 enemies will spawn every 35 miliseconds
			else if (score.getscore() >= 11000) 
			{
				randomenemyadvance ();
				randomenemyadvance ();
				randomenemyadvance ();
			}
		} 
		//spawns items every second
		if (counter % 100 == 0) 
		{
			itemspawn ();
		}

	}

	//gives the player a chance to get an item
	void itemspawn()
	{
		if (Random.Range (0, 4) == 2) 
		{
			int spawnchance = Random.Range (0, 100);
			if (spawnchance >= 0 && spawnchance < 33) 
			{
				Instantiate (heal, new Vector3 ((transform.position.x + Random.Range (-1.0f, 1.0f)), Random.Range (-4.0f, 4.0f), 0), Quaternion.identity);	
			} 
			else if (spawnchance >= 33 && spawnchance < 66) 
			{
				Instantiate (upgrade, new Vector3 ((transform.position.x + Random.Range (-1.0f, 1.0f)), Random.Range (-4.0f, 4.0f), 0), Quaternion.identity);
			}
			else if (spawnchance >= 66 && spawnchance < 100) 
			{
				Instantiate (shield, new Vector3 ((transform.position.x + Random.Range (-1.0f, 1.0f)), Random.Range (-4.0f, 4.0f), 0), Quaternion.identity);
			}
		} 
	}

	//selects a random enemy to spawn
	void randomenemy()
	{
		if (Random.Range (0, 10) < 5)
		{
			Instantiate (mine, new Vector3 ((transform.position.x + Random.Range(-1.0f, 1.0f)), Random.Range (-4.0f, 4.0f), 0), Quaternion.identity);
		} 
		else 
		{
			Instantiate (UFO, new Vector3 ((transform.position.x + Random.Range(-1.0f, 1.0f)), Random.Range (-4.0f, 4.0f), 0), Quaternion.identity);
		}
	}

	//selects a random enemy (this activates after the player has defeated the first boss, has a small chance to spawn another boss)
	void randomenemyadvance()
	{
		int enspawn = Random.Range (0, 100);
		if (enspawn >= 0 && enspawn < 50) 
		{
			Instantiate (mine, new Vector3 ((transform.position.x + Random.Range (-1.0f, 1.0f)), Random.Range (-4.0f, 4.0f), 0), Quaternion.identity);
		} 
		else if (enspawn >= 50 && enspawn < 94)
		{
			Instantiate (UFO, new Vector3 ((transform.position.x + Random.Range (-1.0f, 1.0f)), Random.Range (-4.0f, 4.0f), 0), Quaternion.identity);
		} 
		else 
		{
			Instantiate (boss, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
			bossactive = true;
		}
	}

	//activates when the boss is killed (allows other enemies to spawn again on the randomenemyadvance function
    public void bossdie()
    {
        bossactive = false;
    }
    
}
