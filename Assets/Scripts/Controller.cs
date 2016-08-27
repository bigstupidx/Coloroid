using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum Level
{
	Easy,
	Medium,
	Hard
}

[RequireComponent(typeof(AudioSource))]
public class Controller : MonoBehaviour {

	internal Level Diff = Level.Easy;
	internal BallMove ballMover;
	internal ShakeCamera CameraObj;
	#if CW_Admob
	internal AdManager AdController;
	#endif
	#if CW_Leaderboard
	internal LeaderboardManager Leaderboard;
	#endif
	internal AudioSource Source;
	internal int Score;
	internal int Highscore;
	internal int Sound;
	internal bool menu;
	internal int SelectedLevel;
	//This is a constant float. We will use it to reset the dial's speed when restarting the game. 
	//The value should be the same as on the dial script
	int a;

	[Tooltip("The Menu Canvas")]
	public GameObject MenuCanvas;

	[Tooltip("The Game Canvas")]
	public GameObject GameCanvas;

	[Tooltip("The Tap Canvas")]
	public GameObject TapCanvas;

	[Tooltip("The Game Over Canvas")]
	public GameObject GameOverCanvas;

	[Space(20)]

	[Range(1,3)]
	[Tooltip("The initial dial speed for the easy level")]
	public float EasyDialSpeed = 3;

	[Range(1,3)]
	[Tooltip("The initial dial speed for the medium level")]
	public float MediumDialSpeed = 2;

	[Range(1,3)]
	[Tooltip("The initial dial speed for the hard level")]
	public float HardDialSpeed = 1.5f;

	[Space(20)]

	[Tooltip("The score text")]
	public Text ScoreText;

	[Tooltip("The final score text")]
	public Text FinalScoreText;

	[Tooltip("The highscore text")]
	public Text HighScoreText;

	[Tooltip("The sound button")]
	public Button soundButton;

	[Space(20)]

	[Tooltip("The image to display when the game sound is on mute")]
	public Sprite Mute;

	[Tooltip("The image to display when the game sound is on")]
	public Sprite SoundOn;

	[Tooltip("The soundclip that play when the player matches the correct color")]
	public AudioClip CorrectColor;

	[Tooltip("The soundclip that play when the player matches the wrong color")]
	public AudioClip WrongColor;

	[Tooltip("Link to the store listing")]
	public string GameLink;

	[Tooltip("Link to your publisher page")]
	public string MoreGames;

	[Space(20)]

	[Tooltip("A list of all the colors used in the game.")]
	public Color[] colorList;

	[Tooltip("The different circles we have")]
	public GameObject[] Circles;

	// Use this for initialization
	void Start () 
	{
		//PlayerPrefs.DeleteAll();
		//Get the audio source component
		Source=GetComponent<AudioSource>();

		//Get the sound state( 1 - Sound on. 0 - Sound off)
		Sound=PlayerPrefs.GetInt("Sound",1);

		//Update the sound settings
		if(Sound==0)
		{
			AudioListener.pause=true;
			Source.Stop();
			soundButton.GetComponent<Image>().sprite=Mute;
		}
		else if (Sound==1)
		{
			AudioListener.pause=false;
			Source.Stop();
			soundButton.GetComponent<Image>().sprite=SoundOn;
		}
		else
		{
			PlayerPrefs.SetInt("Sound",1);
			AudioListener.pause=false;
			Source.Stop();
			soundButton.GetComponent<Image>().sprite=SoundOn;
		}

		//Get the camera shake script
		if (CameraObj == null)    CameraObj =(ShakeCamera)FindObjectOfType(typeof(ShakeCamera));

		//Get the dial controller
		if (ballMover == null)    ballMover =(BallMove)FindObjectOfType(typeof(BallMove));

		//Get the ad manager
		#if CW_Admob
		if (AdController == null)    AdController =(AdManager)FindObjectOfType(typeof(AdManager));
		#endif

		//Get the leaderboard manager
		#if CW_Leaderboard
		if (Leaderboard == null)    Leaderboard =(LeaderboardManager)FindObjectOfType(typeof(LeaderboardManager));
		#endif

		//Show main menu
		Home();
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape) && menu==false && ballMover.GameOver)
			Home();
		else if(Input.GetKeyDown(KeyCode.Escape) && menu==true)
			Application.Quit();
	}

	//Shuffle the color list
	void ShuffleColors()
	{
		// Go through all the colors and shuffle them
		for (int index = 0 ; index < colorList.Length ; index++ )
		{
			// Hold the color in a temporary variable
			Color tempNumber = colorList[index];

			//Choose a random index from the color
			int randomIndex = UnityEngine.Random.Range( index, colorList.Length);

			// Assign a random color from the random index above
			colorList[index] = colorList[randomIndex];

			// Assign the temporary int to the random colour we chose
			colorList[randomIndex] = tempNumber;
		}
	}

	public void ToggleSound()
	{
		//Get sound state
		Sound=PlayerPrefs.GetInt("Sound",1);

		//Mute or unmute depending on the current state
		if(Sound==0)
		{
			AudioListener.pause=false;
			Source.Stop();
			PlayerPrefs.SetInt("Sound",1);
			soundButton.GetComponent<Image>().sprite=SoundOn;
		}
		else if (Sound==1)
		{
			AudioListener.pause=true;
			Source.Stop();
			PlayerPrefs.SetInt("Sound",0);
			soundButton.GetComponent<Image>().sprite=Mute;
		}	
	}

	//Start the game
	public void StartGame(int difficulty)
	{
		//Set the selected level. We will use we retrying the game to load the same level
		SelectedLevel=difficulty;

		//Get selected level and set the maximum number of color available for selection from the color list
		if(difficulty==0)
		{
			ballMover.ArraySize=3;
			Diff=Level.Easy;
		}
		if(difficulty==1)
		{
			ballMover.ArraySize=4;
			Diff=Level.Medium;
		}
		if(difficulty==2)
		{
			ballMover.ArraySize=6;
			Diff=Level.Hard;
		}

		//Activate the correct circle based on difficulty selected above
		for(int c=0; c<Circles.Length;c++)
		{
			if(c==difficulty)
				Circles[c].SetActive(true);
			else
				Circles[c].SetActive(false);
		}

		//Shuffle the colorList
		ShuffleColors();

		//Hide the game over canvas
		GameOverCanvas.SetActive(false);

		//Hide the menu over canvas
		MenuCanvas.SetActive(false);

		//Show the game canvas
		GameCanvas.SetActive(true);

		//Show the tap canvas
		TapCanvas.SetActive(true);

		//Show score text
		ScoreText.gameObject.SetActive(true);
		ScoreText.text="0";

		//Reset score counter
		Score=0;

		//Refresh the circle blocks color
		GameObject[] blocks;
		int a = GameObject.FindGameObjectsWithTag("Block").Length;
		blocks = new GameObject[a];
		blocks = GameObject.FindGameObjectsWithTag("Block");
		foreach(GameObject block in blocks)
			block.GetComponent<CircleBlock>().SetColor();

		//Show dial
		ballMover.ShowDial();

		//Reset the dial's initial speed
		if(Diff==Level.Easy)
			ballMover.InitialSpeed=EasyDialSpeed;
		else if(Diff==Level.Medium)
			ballMover.InitialSpeed=MediumDialSpeed;
		else if(Diff==Level.Hard)
			ballMover.InitialSpeed=HardDialSpeed;

		//Change dial color
		ballMover.ChangeDialColor();

		menu=false;
	}

	//Update the score counter
	public void UpdateScore()
	{
		Score +=1;
		ScoreText.text=Score.ToString("0");
		ScoreText.gameObject.GetComponent<Animation>().Play();

		//Play Sound
		Source.PlayOneShot(CorrectColor);
	}

	//Game over
	public void GameOver()
	{
		//Play Sound
		Source.PlayOneShot(WrongColor);

		//Hide the dial
		ballMover.HideDial();

		//Set the GameOver bool to true
		ballMover.GameOver=true;

		//Start camera shake
		CameraObj.StartShake();

		//Show the game over canvas
		GameOverCanvas.SetActive(true);

		//Hide the game canvas
		GameCanvas.SetActive(false);

		//Hide the tap canvas
		TapCanvas.SetActive(false);

		//Hide score text
		ScoreText.gameObject.SetActive(false);

		//Get the highscore
		if(Diff==Level.Easy)
			a=PlayerPrefs.GetInt("EasyHighscore",0);
		if(Diff==Level.Medium)
			a=PlayerPrefs.GetInt("MediumHighscore",0);
		if(Diff==Level.Hard)
			a=PlayerPrefs.GetInt("HardHighscore",0);

		//Compare the current score and the highscore
		if(a<Score)
		{
			a=Score;

			if(Diff==Level.Easy)
				PlayerPrefs.SetInt("EasyHighscore",a);
			if(Diff==Level.Medium)
				PlayerPrefs.SetInt("MediumHighscore",a);
			if(Diff==Level.Hard)
				PlayerPrefs.SetInt("HardHighscore",a);

			//Post the score to the Google Play Leaderboard
			#if CW_Leaderboard
			Leaderboard.PostScore(a);
			#endif
		}

		//Display the highscore
		HighScoreText.text=a.ToString();

		//Display the score
		FinalScoreText.text=Score.ToString();

		#if CW_Admob
		AdController.ShowInterstitial();
		#endif
	}

	//Show the game main menu
	public void Home()
	{
		//Hide the game over canvas
		GameOverCanvas.SetActive(false);

		//Hide the menu over canvas
		MenuCanvas.SetActive(false);

		//Hide the game canvas
		GameCanvas.SetActive(false);

		//Hide the tap canvas
		TapCanvas.SetActive(false);

		//Show the menu over canvas
		MenuCanvas.SetActive(true);

		//Set the GameOver bool to true
		ballMover.GameOver=true;

		menu=true;
	}

	//Reload the current level
	public void Retry()
	{
		StartGame(SelectedLevel);
	}

	//Call this to redirect the user to the store
	public void RateUs()
	{
		Application.OpenURL(GameLink);
	}
		
	public void Portfolio()
	{
		Application.OpenURL(MoreGames);
	}
}