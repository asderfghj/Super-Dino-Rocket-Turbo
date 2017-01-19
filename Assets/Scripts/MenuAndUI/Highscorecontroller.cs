using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Highscorecontroller : MonoBehaviour 
{

    private GameObject hsman;
    public InputField initials;
    private GameObject confirm;
	private GameObject submitButton;
	private GameObject ScoreText;
	private Text sText;

	void Start ()
    {
        hsman = GameObject.Find("HighscoreEnter");
        confirm = GameObject.Find("Submitted");
		submitButton = GameObject.Find ("SubmitButton");
		ScoreText = GameObject.Find ("ScoreText");
		sText = ScoreText.GetComponent<Text> ();
		confirm.SetActive (false);
		hsman.SetActive (false);

		sText.text = "Your Score: " + PlayerPrefs.GetInt("Tscore");

		//checks whether the player score is above the lowest score on the leaderboard
        if(PlayerPrefs.GetInt("Tscore") > PlayerPrefs.GetInt("Score3"))
        {
            hsman.SetActive(true);
        } 
	}

	//
    public void OnSubmitClicked()
    {
		//determines where on the leaderboard you will appear 
        if(initials.text.Length > 0)
        {
            if(PlayerPrefs.GetInt("Tscore") > PlayerPrefs.GetInt("Score1"))
            {
                PlayerPrefs.SetInt("Score3", PlayerPrefs.GetInt("Score2"));
                PlayerPrefs.SetString("Name3", PlayerPrefs.GetString("Name2"));
                PlayerPrefs.SetInt("Score2", PlayerPrefs.GetInt("Score1"));
                PlayerPrefs.SetString("Name2", PlayerPrefs.GetString("Name1"));
                PlayerPrefs.SetInt("Score1", PlayerPrefs.GetInt("Tscore"));
                PlayerPrefs.SetString("Name1", initials.text);
            }
            else if(PlayerPrefs.GetInt("Tscore") > PlayerPrefs.GetInt("Score2"))
            {
                PlayerPrefs.SetInt("Score3", PlayerPrefs.GetInt("Score2"));
                PlayerPrefs.SetString("Name3", PlayerPrefs.GetString("Name2"));
                PlayerPrefs.SetInt("Score2", PlayerPrefs.GetInt("Tscore"));
                PlayerPrefs.SetString("Name2", initials.text);
            }
            else if(PlayerPrefs.GetInt("Tscore") > PlayerPrefs.GetInt("Score3"))
            {
                PlayerPrefs.SetInt("Score3", PlayerPrefs.GetInt("Tscore"));
                PlayerPrefs.SetString("Name3", initials.text);
            }
            confirm.SetActive(true);
			submitButton.SetActive (false);
        }
    }

    public void OnRetryClicked()
    {
		//reloads the game
        SceneManager.LoadScene("Game");
    }

    public void OnMenuClicked()
    {
		//sends player to menu
        SceneManager.LoadScene("Menu");
    }

}
