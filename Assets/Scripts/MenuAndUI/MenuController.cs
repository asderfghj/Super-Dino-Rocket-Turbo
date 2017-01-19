using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
	private GameObject MainMenu;
	private GameObject OptionsMenu;
	private GameObject volslide;
	private Slider slide;

    void Start()
    {
		MainMenu = GameObject.Find ("MainMenu");
		OptionsMenu = GameObject.Find("OptionsMenu");
		volslide = GameObject.Find ("VolSlider");
		slide = volslide.GetComponent<Slider> ();
		slide.value = PlayerPrefs.GetFloat ("volume");
		OptionsMenu.SetActive(false);

		//sets the default scores
        if(PlayerPrefs.HasKey("Score1") != true)
        {
            PlayerPrefs.SetInt("Score1", 10000);
        }

        if(PlayerPrefs.HasKey("Name1") != true)
        {
            PlayerPrefs.SetString("Name1", "MJD");
        }

        if(PlayerPrefs.HasKey("Score2") != true)
        {
            PlayerPrefs.SetInt("Score2", 5000);
        }

        if (PlayerPrefs.HasKey("Name2") != true)
        {
            PlayerPrefs.SetString("Name2", "RAB");
        }

        if (PlayerPrefs.HasKey("Score3") != true)
        {
            PlayerPrefs.SetInt("Score3", 2000);
        }

        if (PlayerPrefs.HasKey("Name3") != true)
        {
            PlayerPrefs.SetString("Name3", "GRU");
        }

        if(PlayerPrefs.HasKey("Tscore") != true)
        {
            PlayerPrefs.SetInt("Tscore", 0);
        }
    }

	  
	//When the start button is pressed, load the Game scene.   
	public void OnStartClicked()
	{
		SceneManager.LoadScene ("Game");
	}

	//opens the options menu
	public void OnOptClick()
	{
		MainMenu.SetActive (false);
		OptionsMenu.SetActive (true);
	}

	//closes the program
	public void OnExitClicked()
	{
		Application.Quit ();
	}

	//returns to the main menu from the options menu
	public void OnBackClicked()
	{
		MainMenu.SetActive (true);
		OptionsMenu.SetActive (false);
	}

	//resets the high scores
	public void OnReset()
	{
		PlayerPrefs.SetInt("Score1", 0);
		PlayerPrefs.SetInt("Score2", 0);
		PlayerPrefs.SetInt("Score3", 0);
		PlayerPrefs.SetString("Name1", "***");
		PlayerPrefs.SetString("Name2", "***");
		PlayerPrefs.SetString("Name3", "***");
	}

	//changes the volume
	public void Onslide()
	{
		PlayerPrefs.SetFloat ("volume", slide.value);
	}
}
