using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour {
	public float ballSpeed = 2.0f;
	public bool turnBall = false; 

	private GameObject gameController;
	private Animation anim;
	private int colorIndex;
	private int currentColor=0;
	private int currentBlockColor=0;
	private int arraySize=0;
	private bool match=false;
    private bool gameOver=false;
	public GameObject instructText;

	// Use this for initialization
	void Awake () {
		print (ballSpeed);
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		anim= GetComponent<Animation>();

		//Set GameOver bool to true
		gameOver=true;

		//Show Instruction
		instructText.SetActive(true);

		currentBlockColor=0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!gameOver) {
			if (!turnBall) {
				transform.Translate (0, ballSpeed * Time.deltaTime, 0);
			} else {
				transform.Translate (0, -ballSpeed * Time.deltaTime, 0);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "CirclePart") {
			currentBlockColor = coll.gameObject.GetComponent<CircleBlock> ().GetColorIndex ();
			if (currentBlockColor == currentColor) {
				print ("update score");
				ballSpeed += 0.009f;
				ChangeDialColor ();
				gameController.GetComponent<Controller> ().UpdateScore ();
				anim.Play();
			} else {
				gameController.GetComponent<Controller> ().ShowGameOverPanel (true);
			}

			if (turnBall) {
				turnBall = false;
			} else {
				turnBall = true;			
			}
		}
	}
		
	public void ChangeDialColor() {
		//Pick a random color
		colorIndex=Random.Range(0,arraySize);
		//Check if the color chosen above is the same as the current color.
		if (currentColor == colorIndex) {
			ChangeDialColor ();
		} else {
			if (gameController == null) {
				gameController = GameObject.FindGameObjectWithTag ("GameController");
			}
			this.gameObject.GetComponent<SpriteRenderer>().color = gameController.GetComponent<Controller>().ReturnColorFromColorList(colorIndex);
			//Set the chosen color as the current color
			currentColor=colorIndex;
		}
	}

	//Hides the dial
	public void HideBall(bool hideBall) {
		if (hideBall) {
			gameObject.SetActive (false);
		} else {
			gameObject.SetActive (true);
		}
	}

	//Shows the dial
	public void ShowDial()
	{
		gameObject.SetActive(true);
		transform.position=Vector3.zero;
		transform.Rotate (0,0,Random.Range(0.0f,361.0f));
		transform.rotation=Quaternion.Euler(Vector3.zero);
		currentColor=0;
		currentBlockColor=0;
		instructText.SetActive(true);
	}

	public void SetArraySize(int arraySize) {
		this.arraySize = arraySize;
	}

	public void SetBallSpeed(float ballSpeed) {
		this.ballSpeed = ballSpeed;
	}

	public void SetGameOver(bool gameOver) {
		this.gameOver = gameOver;
		instructText.SetActive(false);
	}

	public bool GetGameOver() {
		return gameOver;
	}
}
