using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighscoreDisplay : MonoBehaviour
{

	private Text scoreBoard;

	void Start () 
	{
		scoreBoard = GetComponent<Text>();

	}
	
	// displays the highscores
	void Update () 
	{
		scoreBoard.text = "1: " + PlayerPrefs.GetString("Name1") + " " + PlayerPrefs.GetInt("Score1") + " Points \n" +
			"\n" +
			"2: " + PlayerPrefs.GetString("Name2") + " " + PlayerPrefs.GetInt("Score2") + " Points \n" +
			"\n" +
			"3: " + PlayerPrefs.GetString("Name3") + " " + PlayerPrefs.GetInt("Score3") + " Points \n";
	}
}
