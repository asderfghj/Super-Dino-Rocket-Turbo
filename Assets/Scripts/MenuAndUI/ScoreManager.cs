using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	private Text scoretext;
	private int scorenum;

	void Start()
	{
		scoretext = GetComponent<Text> ();
		scorenum = 0;
	}

	void Update()
	{
		//displays the score on the screen
		scoretext.text = "Score: " + scorenum;
		PlayerPrefs.SetInt ("Tscore", scorenum);
	}

	public int getscore()
	{
		return scorenum;
	}

	public void addscore(int add)
	{
		scorenum = scorenum + add;
	}

}
