using UnityEngine;
using System.Collections;

public class BossScroller : MonoBehaviour 
{

	private int XSpeed = -10;
	private int YSpeed = 0;
	private bool die = false;

	private void Update()
	{
		transform.Translate(new Vector2(XSpeed, YSpeed) * Time.deltaTime);
	}

	public void setXSpeed(int _XSpeed)
	{
		XSpeed = _XSpeed;
	}

	public void setYSpeed(int _YSpeed)
	{
		YSpeed = _YSpeed;
	}

	public int getYSpeed()
	{
		return YSpeed;
	}

	public void setdie()
	{
		die = true;
	}

	public bool getdie()
	{
		return die;
	}
}
