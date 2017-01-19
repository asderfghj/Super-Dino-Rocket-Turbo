using UnityEngine;
using System.Collections;

public class healthpackcol : MonoBehaviour {

    public AudioSource colsound;
    public SpriteRenderer sprite;
    public BoxCollider2D col;
    private bool pickedup = false;

    public void update()
    {
		//destroys the object if it has been picked up and the sound effect is not playing
        if (pickedup && !colsound.isPlaying)
        {
            Destroy(gameObject);
        }
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
            colsound.Play();
            PlayerController playerController = other.gameObject.GetComponent<PlayerController> ();
			//activates the heal function in player controller
			playerController.Heal();
            pickedup = true;
            sprite.enabled = false;
            col.enabled = false;
		}
	}

}
