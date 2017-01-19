using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
	private PolygonCollider2D pc;
	public GameObject burger;
    private GameObject shield;
	private Animator animator;
    private AudioSource wilhelm;
    private SpriteRenderer shieldsprite;
	private int count;
	private int health;
	private bool powerupactive = false;
	private bool shieldactive = false;
	private bool topcol = false;
	private bool botcol = false;
	private bool leftcol = false;
	private bool rightcol = false;
	private float speed = 7.0f;

	private void Start()
	{
        shield = GameObject.Find("Shield");
        shieldsprite = shield.GetComponent<SpriteRenderer>();
		pc = GetComponent<PolygonCollider2D> ();
        health = 6;
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
        wilhelm = GetComponent<AudioSource>();
	}

	
	public void Damage()
	{
		//nullifies damage if player has a sheild
		if (shieldactive) 
		{
			shieldactive = false;

            shieldsprite.enabled = false;
        }
		//lowers player health by 1 if hit
		else 
		{
			health -= 1;
			powerupactive = false;
		}
		//activates the death animation if the player is at 0 health
		if(health < 1)
		{
			rb.isKinematic = false;
			pc.enabled = false;
            animator.SetInteger("animstate", 2);
            wilhelm.Play();
            enabled = false;
        }
	}

	//adds 2 health to the player 
	public void Heal()
	{
		health += 2;
		if (health > 6) 
		{
			health = 6;
		}
	}
		
	public int GetHealth()
	{
		return health;
	}

	public void settopCol(bool _topcol)
	{
		topcol = _topcol;
	}

	public void setbotCol(bool _botcol)
	{
		botcol = _botcol;
	}

	public void setleftCol(bool _leftcol)
	{
		leftcol = _leftcol;
	}

	public void setrightCol(bool _rightcol)
	{
		rightcol = _rightcol;
	}

	public void activatepowerup()
	{
		powerupactive = true;
	}

	public void activateshield()
	{
        shieldsprite.enabled = true;
        shieldactive = true;
	}

	private void FixedUpdate()
	{ 
		float vertstrans = Input.GetAxis ("Vertical") * speed;
		float hoztrans = Input.GetAxis ("Horizontal") * speed;
		vertstrans *= Time.deltaTime;
		hoztrans *= Time.deltaTime;

		//movement 
		if (Input.GetAxis("Vertical") > 0) 
		{
			if (!topcol) 
			{
				animator.SetInteger ("animstate", 1);
				transform.Translate (0, vertstrans, 0);
			} 
		}

		if (Input.GetAxis("Vertical") < 0) 
		{
			if (!botcol) 
			{
				animator.SetInteger ("animstate", 2);
				transform.Translate (0, vertstrans, 0);
			}
		}
			
		if (Input.GetAxis("Vertical") == 0) 
		{
			animator.SetInteger ("animstate", 0);
		}


		if (Input.GetAxis ("Horizontal") > 0) 
		{
			if (!rightcol) 
			{
				transform.Translate (hoztrans, 0, 0);
				animator.SetInteger ("animstate", 0);
			} 

		}

		if (Input.GetAxis ("Horizontal") < 0) 
		{
			if (!leftcol) 
			{
				transform.Translate (hoztrans, 0, 0);
				animator.SetInteger ("animstate", 0);
			} 

		}


		if (Input.GetAxis("Fire1") > 0)
		{
			//shooting when powerup is not active
			if (count % 15 == 0 && !powerupactive)
			{
				shoot ();
				count = 0;
			} 
			//shooting when powerup is active (slows down the firing rate)
			else if (count % 20 == 0 && powerupactive) 
			{
				shoot ();
				count = 0;
			}
		}
		count++;
	}

	private void shoot()
	{
		//if the powerup is not active 1 bullet will fire 
		if (powerupactive == false) 
		{
			Instantiate (burger, new Vector3 (transform.position.x, (transform.position.y) - 0.2f, 0), Quaternion.identity);
		} 
		//if it is active 3 bullets will fire (at different angles) 
		else 
		{
			Instantiate (burger, new Vector3 (transform.position.x, (transform.position.y) - 0.2f, 0), Quaternion.Euler(0f, 0f, 11.25f));
			Instantiate (burger, new Vector3 (transform.position.x, (transform.position.y) - 0.2f, 0), Quaternion.identity);
			Instantiate (burger, new Vector3 (transform.position.x, (transform.position.y) - 0.2f, 0), Quaternion.Euler(0f, 0f, -11.25f));
		}
	}

	private void OnBecameInvisible()
	{
		//loads the game over scene on player death
		SceneManager.LoadScene ("GameOver");
		Destroy (gameObject);
	}


}
