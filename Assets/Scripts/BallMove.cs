using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour {
	public float ballSpeed = 2.0f;
	public bool turnBall = false; 

	private GameObject gameController;
	private int colorIndex;
	private int currentColor=0;
	private int currentBlockColor=0;
	private int arraySize=0;
	private bool match=false;
	private Animation anim;
    private bool gameOver=false;
	public GameObject instructText;

	// Use this for initialization
	void Start () {
		//Get the animation component
		anim=GetComponent<Animation>();
	
		if (gameController == null) {
			gameController = GameObject.FindGameObjectWithTag ("GameController");
		}

		//Set GameOver bool to true
		gameOver=true;

		//Show Instruction
		//instructText.SetActive(true);

		currentBlockColor=0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!turnBall) {
			transform.Translate (0, ballSpeed * Time.deltaTime, 0);
		} else {
			transform.Translate (0, -ballSpeed * Time.deltaTime, 0);
		}

		if(currentColor==currentBlockColor)
			match=true;
		else
			match=false;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "CirclePart") {
			currentBlockColor = coll.gameObject.GetComponent<CircleBlock> ().GetColorIndex ();
			if (currentBlockColor == currentColor) {
				print ("update score");
				ChangeDialColor ();
			} else {
				print ("game over");
			}
			//StartCoroutine (BallScale());
			if (turnBall) {
				turnBall = false;
			} else {
				turnBall = true;			
			}
		}
	}

	/*IEnumerator BallScale() {
		iTween.ScaleTo (gameObject, iTween.Hash("scale", new Vector3(0.15f,0.15f,0.15f),"time", 0.25f, "easetype", iTween.EaseType.linear));
		yield return new WaitForSeconds(0.15f);
		iTween.ScaleTo (gameObject, iTween.Hash("scale", new Vector3(0.13f,0.13f,0.13f),"time", 0.25f, "easetype", iTween.EaseType.linear));
	}*/

	public void ChangeDialColor() {
		//Pick a random color
		colorIndex=Random.Range(0,arraySize);
		//Check if the color chosen above is the same as the current color.
		if(currentColor==colorIndex)
			ChangeDialColor();
		else
		{
			if (gameController == null) {
				gameController = GameObject.FindGameObjectWithTag ("GameController");
			}
			this.gameObject.GetComponent<SpriteRenderer>().color = gameController.GetComponent<Controller>().ReturnColorFromColorList(colorIndex);
			//Set the chosen color as the current color
			currentColor=colorIndex;
		}
	}

	//Hides the dial
	public void HideDial()
	{
		gameObject.SetActive(false);
	}

	//Shows the dial
	public void ShowDial()
	{
		gameObject.SetActive(true);
		transform.position=Vector3.zero;
		transform.rotation=Quaternion.Euler(Vector3.zero);
		currentColor=0;
		currentBlockColor=0;
		//instructText.SetActive(true);
	}

	//Change rotation based on whether we are moving clockwise or anticlockwise right now
	/*public void ChangeRotation()
	{
		if(!gameOver)
		{
			if(match)
			{
				//Update the current score
				gameController.GetComponent<Controller>().UpdateScore();

				//Play animation
				anim.Play();

				//Change dial color
				ChangeDialColor();
			}
			else
				gameController.GetComponent<Controller>().GameOver();
		}
		else
		{
			//Set a random rotation (clockwise or anitclockwise)
			instructText.SetActive(false);
			gameOver=false;
		}
	}*/

	public void SetArraySize(int arraySize) {
		this.arraySize = arraySize;
	}
}
