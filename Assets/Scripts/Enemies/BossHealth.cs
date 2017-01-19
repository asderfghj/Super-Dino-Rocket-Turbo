using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour 
{

	private Rigidbody2D rb;
	private int scoreValue;
	private int health = 50;
	private int y;
	private BossScroller scroller;
	private PolygonCollider2D polycol;
	private BossShoot shooter;
	private GameObject scoretext;
	private ScoreManager scorer;
    private GameObject LevelManager;
    private Level1Gen levelman;

	public void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
		scroller = GetComponent<BossScroller> ();
		polycol = GetComponent<PolygonCollider2D> ();
		shooter = GetComponent<BossShoot> ();
		scoretext = GameObject.Find ("ScoreText");
		scorer = scoretext.GetComponent<ScoreManager> ();
        LevelManager = GameObject.Find("levelmanager");
        levelman = LevelManager.GetComponent<Level1Gen>();

        scoreValue = 1000;
	}

	//lowers the boss's health when hit by the player
	public void damage()
	{
		health = health - 1;
	}

	//increases the boss's speed based on it's health (the lower the health, the faster it goes)
	private void Update()
	{
		y = scroller.getYSpeed ();
		if (health < 25 && health > 5)
		{
			shooter.setshotspeed (30);
			if (y > 0) 
			{
				scroller.setYSpeed (8);
			} 
			else if (y < 0) 
			{
				scroller.setYSpeed (-8);
			}
		}
		else if (health < 5 && health > 0) 
		{
			shooter.setshotspeed(20);
			if (y > 0) 
			{
				scroller.setYSpeed (12);
			} 
			else if (y < 0) 
			{
				scroller.setYSpeed (-12);
			}
		} 
		else if (health == 0) 
		{
			
			die();
		}
	}

	//triggers the boss's dying animation 
	private void die()
	{
		scroller.setXSpeed (-1);
		scroller.setYSpeed (0);
		polycol.enabled = false;
		scroller.setdie ();
		rb.isKinematic = false;
	}

	//destroys the boss when it goes off screen
	void OnBecameInvisible()
	{
		scorer.addscore (scoreValue);
        levelman.bossdie();
		Destroy (gameObject);
	}
}
