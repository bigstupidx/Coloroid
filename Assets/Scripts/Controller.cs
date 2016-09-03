using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Controller : MonoBehaviour {

	private GameObject ballMover;
	internal ShakeCamera CameraObj;
	#if CW_Admob
	internal AdManager AdController;
	#endif
	#if CW_Leaderboard
	internal LeaderboardManager Leaderboard;
	#endif
	internal AudioSource Source;
	internal int score;
	internal int Highscore;
	internal int Sound;
	private bool menu;
	private int selectedLevel = 0;
	//This is a constant float. We will use it to reset the dial's speed when restarting the game. 
	//The value should be the same as on the dial script
	int a;
	public GameObject MenuCanvas;
	public GameObject GameCanvas;
	public GameObject TapCanvas;
	public GameObject GameOverCanvas;
	public GameObject PlayBtn;
	public GameObject GameOverPanel;
	public GameObject ReturnToGameBtn;
	public GameObject YesNoPanel;
	public Text ScoreText;
	public Text FinalScoreText;
	public Text HighScoreText;
	public Text MenuTopScore;
	public Button soundButton;
	public Sprite Mute;
	public Sprite SoundOn;
	public AudioClip CorrectColor;
	public AudioClip WrongColor;
	public string GameLink;
	public string FbLink;
	public Color[] colorList;
	public GameObject[] Circles;

	// Use this for initialization
	void Start ()
	{
		//PlayerPrefs.DeleteAll();
		//Get the audio source component
		Source = GetComponent<AudioSource> ();

		//Get the sound state( 1 - Sound on. 0 - Sound off)
		Sound = PlayerPrefs.GetInt ("Sound", 1);

		//Update the sound settings
		if (Sound == 0) {
			AudioListener.pause = true;
			Source.Stop ();
			soundButton.GetComponent<Image> ().sprite = Mute;
		} else { 
			if (Sound == 1) {
				AudioListener.pause = false;
				Source.Stop ();
				soundButton.GetComponent<Image> ().sprite = SoundOn;
			} else {
				PlayerPrefs.SetInt ("Sound", 1);
				AudioListener.pause = false;
				Source.Stop ();
				soundButton.GetComponent<Image> ().sprite = SoundOn;
			}
		}

		//Get the camera shake script
		if (CameraObj == null)    CameraObj =(ShakeCamera)FindObjectOfType(typeof(ShakeCamera));

		//Get the dial controller
		if (ballMover == null)    ballMover = GameObject.FindGameObjectWithTag("Ball");

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
		if (Input.GetKeyDown (KeyCode.Escape) && (menu == false) && !ballMover.GetComponent<BallMove> ().GetGameOver ()) {
			print ("ShowGameOverPanel");
			ShowGameOverPanel (false);
			//Home ();
		}

		if (Input.GetKeyDown (KeyCode.Escape) && menu == true) {
			YesNoPanel.SetActive (true);
		}
	}

	public void QuitGame() {
		print ("Quit");
		Application.Quit ();
	}

	public void DisabledYesNoPanel() {
		YesNoPanel.SetActive (false);
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
	public void StartGame()
	{
		ballMover.GetComponent<BallMove>().SetArraySize(2);
		ballMover.GetComponent<BallMove> ().SetBallSpeed (2.0f);
		//Activate the correct circle based on difficulty selected above

		for(int c=0; c<Circles.Length;c++) {
			if (c == 0) {
				Circles [c].SetActive (true);
			} else {
				Circles [c].SetActive (false);
			}
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
		score=0;

		//Refresh the circle blocks color
		GameObject[] blocks;
		int a = GameObject.FindGameObjectsWithTag("CirclePart").Length;
		blocks = new GameObject[a];
		blocks = GameObject.FindGameObjectsWithTag("CirclePart");
		foreach (GameObject b in blocks) {
			b.GetComponent<CircleBlock> ().SetColor ();
		}

		//Show dial
		ballMover.GetComponent<BallMove>().ShowDial();

		//Change dial color
		ballMover.GetComponent<BallMove>().ChangeDialColor();

		menu=false;
	}

	public Color ReturnColorFromColorList(int colorNumber) {
		return colorList [colorNumber];
	}

	//Update the score counter
	public void UpdateScore()
	{
		score +=1;
		ScoreText.text=score.ToString("0");
		ScoreText.gameObject.GetComponent<Animation>().Play();

		//Play Sound
		Source.PlayOneShot(CorrectColor);
		CheckCorrectLevel ();
	}

	public void CheckCorrectLevel() {
		print ("check score");
		switch(score) {
		case 5: // lvl2
			selectedLevel = 1;
			ballMover.GetComponent<BallMove> ().SetArraySize (3);
			ChangeLevel ();
			break;
		case 15: // lvl3
			selectedLevel = 2;
			ballMover.GetComponent<BallMove> ().SetArraySize (4);
			ChangeLevel ();
			break;
		case 30: // lvl4
			selectedLevel = 3;
			ballMover.GetComponent<BallMove>().SetArraySize(5);
			ChangeLevel ();
			break;
		case 60: // lvl5
			selectedLevel = 4;
			ballMover.GetComponent<BallMove>().SetArraySize(6);
			ChangeLevel ();
			break;
		case 100: // lvl6
			selectedLevel = 5;
			ballMover.GetComponent<BallMove>().SetArraySize(8);
			ChangeLevel ();
			break;
		case 150: // lvl7
			selectedLevel = 6;
			ballMover.GetComponent<BallMove>().SetArraySize(10);
			ChangeLevel ();
			break;
		}
	}

	public void ChangeLevel() {
		ballMover.GetComponent<BallMove>().SetGameOver(true);
		for(int c=0; c<Circles.Length;c++)
		{
			if (c == selectedLevel) {
				Circles [c].SetActive (true);
			} else {
				print (c);
				Circles [c].SetActive (false);
			}
		}

		ShuffleColors();
		//Refresh the circle blocks color
		GameObject[] blocks;
		int a = GameObject.FindGameObjectsWithTag("CirclePart").Length;
		blocks = new GameObject[a];
		blocks = GameObject.FindGameObjectsWithTag("CirclePart");
		foreach (GameObject b in blocks) {
			b.GetComponent<CircleBlock> ().SetColor ();
		}

		//Show dial
		ballMover.GetComponent<BallMove>().ShowDial();

		//Change dial color
		ballMover.GetComponent<BallMove>().ChangeDialColor();

		menu=false;
	}

	public void ShowGameOverPanel(bool showGameOver) {
		ballMover.GetComponent<BallMove>().SetGameOver(true);
		ballMover.GetComponent<BallMove> ().HideBall(true);
		GameOverCanvas.SetActive(true);
		GameOverPanel.GetComponent<RectTransform> ().localScale = Vector3.zero;
		StartCoroutine (GameOverPanel.GetComponent<ActivateOnEnable> ().RunAnimation());
		TapCanvas.SetActive(false);
		ScoreText.gameObject.SetActive(false);

		a=PlayerPrefs.GetInt("Score",0);

		if(a<score)
		{
			a=score;
			PlayerPrefs.SetInt("Score",a);
		}

		//Display the highscore
		HighScoreText.text=a.ToString();

		//Display the score
		FinalScoreText.text=score.ToString();

		if (showGameOver) {
			//ReturnToGameBtn.GetComponent<Button>().interactable = false;
			ReturnToGameBtn.SetActive (false);
			GameOver ();
		} else {
			//ReturnToGameBtn.GetComponent<Button>().interactable = true;
			ReturnToGameBtn.SetActive (true);
		}
	}

	public void UnPause() {
		ballMover.GetComponent<BallMove>().SetGameOver(false);
		ScoreText.gameObject.SetActive(true);
		TapCanvas.SetActive(true);
		ballMover.GetComponent<BallMove>().HideBall(false);
		GameOverCanvas.SetActive(false);
	}

	//Game over
	public void GameOver()
	{
		//Play Sound
		Source.PlayOneShot(WrongColor);
		GameCanvas.SetActive(false);
		//Set the GameOver bool to true

		//Start camera shake
		CameraObj.StartShake();

		//Post the score to the Google Play Leaderboard
		#if CW_Leaderboard
		Leaderboard.PostScore(a);
		#endif

		#if CW_Admob
		AdController.ShowInterstitial();
		#endif
	}

	//Show the game main menu
	public void Home() {
		//Hide the game over canvas
		GameOverCanvas.SetActive(false);
		//Hide the menu over canvas
		MenuCanvas.SetActive(false);

		//Hide the game canvas
		GameCanvas.SetActive(false);

		//Hide the tap canvas
		TapCanvas.SetActive(false);

		a=PlayerPrefs.GetInt("Score",0);
		MenuTopScore.text = a.ToString ();

		//Show the menu over canvas
		MenuCanvas.SetActive(true);
		PlayBtn.GetComponent<RectTransform> ().localScale = Vector3.zero;
		StartCoroutine (PlayBtn.GetComponent<ActivateOnEnable> ().RunAnimation());
		//Set the GameOver bool to true
		menu=true;
	}

	//Reload the current level
	public void Retry()
	{
		StartGame();
	}

	//Call this to redirect the user to the store
	public void RateUs()
	{
		Application.OpenURL(GameLink);
	}
		
	public void FacebookLike()
	{
		Application.OpenURL(FbLink);
	}
}