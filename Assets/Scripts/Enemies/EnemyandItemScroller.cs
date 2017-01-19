using UnityEngine;
using System.Collections;

public class EnemyandItemScroller : MonoBehaviour 
{
	public int scrollSpeed = 0;
	public int scorevalue;
    private AudioSource soundclip;

    private void Start()
    {
        soundclip = GetComponent<AudioSource>();

    }

	private void Update()
	{
		transform.Translate(new Vector2(scrollSpeed, 0) * Time.deltaTime);
	}

	private void OnBecameInvisible()
    {

        if (soundclip == null)
        {
            Destroy(gameObject);
        }
        else if (!soundclip.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
