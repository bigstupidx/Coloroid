using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class BallMove : MonoBehaviour {
	public float ballSpeed = 2.0f;
	public bool turnBall = false; 

	internal Controller gameController;
	internal Transform thisTransform;
	internal int colorIndex;
	internal int currentColor=0;
	internal int currentBlockColor=0;
	internal int ArraySize=0;
	internal bool Match=false;
	internal SpriteRenderer DialRenderer;
	internal float InitialSpeed=2;
	internal float MaxSpeed;
	internal Animation Anim;
	internal bool GameOver=false;
	internal bool Clockwise=false;

	[Tooltip("The instructions text")]
	public GameObject instructText;

	[Range(5,15)]
	[Tooltip("The maximum speed for the dial for the easy level")]
	public float EasyMaxSpeed=8;

	[Range(5,15)]
	[Tooltip("The maximum speed for the dial for the medium level")]
	public float MediumMaxSpeed=6;

	[Range(5,15)]
	[Tooltip("The maximum speed for the dial for the hard level")]
	public float HardMaxSpeed=5;

	[Range(0.1f,1)]
	[Tooltip("The amount we will increase the dial speed")]
	public float SpeedIncrease=0.2f;

	// Use this for initialization
	void Start () {
		thisTransform = transform;

		//Get the animation component
		Anim=GetComponent<Animation>();

		//Get the sprite renderer of this object
		DialRenderer=GetComponent<SpriteRenderer>();

		// Get the game controller
		if (gameController == null)    gameController =(Controller)FindObjectOfType(typeof(Controller));

		//Set GameOver bool to true
		GameOver=true;

		//Show Instruction
		instructText.SetActive(true);

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
			Match=true;
		else
			Match=false;

		if(!GameOver)
		{
			if(!Clockwise)
				thisTransform.Rotate(Vector3.forward,InitialSpeed);
			else
				thisTransform.Rotate(Vector3.back,InitialSpeed);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "CirclePart") {
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

	public void ChangeDialColor()
	{
		//Pick a random color
		colorIndex=Random.Range(0,ArraySize);

		//Check if the color chosen above is the same as the current color.
		if(currentColor==colorIndex)
			ChangeDialColor();
		else
		{
			// Assign a random color from the list of colors in the gamecontroller
			DialRenderer.color = gameController.colorList[colorIndex];
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
		transform.localScale=new Vector3(0.9f,0.6f,1);
		currentColor=0;
		currentBlockColor=0;
		instructText.SetActive(true);

		//Set the max speed based on the level loaded
		if(gameController.Diff==Level.Easy)
			MaxSpeed=EasyMaxSpeed;
		else if(gameController.Diff==Level.Medium)
			MaxSpeed=MediumMaxSpeed;
		else if(gameController.Diff==Level.Hard)
			MaxSpeed=HardMaxSpeed;
	}

	//Change rotation based on whether we are moving clockwise or anticlockwise right now
	public void ChangeRotation()
	{
		if(!GameOver)
		{
			if(Match)
			{
				if(Clockwise)
					Clockwise=false;
				else
					Clockwise=true;

				//increase the dial's speed
				if(InitialSpeed<=MaxSpeed)
					InitialSpeed +=SpeedIncrease;

				//Update the current score
				gameController.UpdateScore();

				//Play animation
				Anim.Play();

				//Change dial color
				ChangeDialColor();
			}
			else
				gameController.GameOver();
		}
		else
		{
			//Set a random rotation (clockwise or anitclockwise)
			Clockwise=Random.value>0.5f;
			instructText.SetActive(false);
			GameOver=false;
		}
	}
}
