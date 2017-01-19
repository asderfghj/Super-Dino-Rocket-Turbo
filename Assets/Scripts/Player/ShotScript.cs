using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

    public AudioSource hit;
	private GameObject scoretext;
	private ScoreManager scorer;
    private bool isHit = false;

	void Start () 
	{
		scoretext = GameObject.Find ("ScoreText");
		scorer = scoretext.GetComponent<ScoreManager> ();
	}

	void Update () 
	{
		//makes the bullet move
		transform.Translate(0.5f, 0f, 0f, Space.Self);
        if (transform.position.x > 10)
		{
			Destroy(gameObject);
		}
		else if(isHit == true && !hit.isPlaying)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") 
		{
			//when a bullet hits an enemy, the enemy will spin and fall off screen
			Rigidbody2D enrb = other.gameObject.GetComponent<Rigidbody2D> ();
			EnemyandItemScroller ensc = other.gameObject.GetComponent<EnemyandItemScroller> ();
			PolygonCollider2D enpc = other.gameObject.GetComponent<PolygonCollider2D> ();
			enpc.enabled = false;
			ensc.scrollSpeed = 0;
			enrb.isKinematic = false;
			enrb.AddTorque(-700f);
			scorer.addscore (ensc.scorevalue);
            hit.Play();
            isHit = true;
		}
		else if (other.gameObject.tag == "Boss") 
		{
			//when a bullet hits a boss, the boss' health is lowered 
			BossHealth bhelf = other.gameObject.GetComponent<BossHealth> ();
			bhelf.damage ();
			isHit = true;
		}
	}

}
