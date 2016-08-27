using UnityEngine;
using System.Collections;

public class CircleBlock : MonoBehaviour {
	
	internal Controller gameController;
	internal BallMove ballMover;

	//This object's sprite renderer. We will change this based on the current color set above
	internal SpriteRenderer objRenderer;

	[Tooltip("The index of the color of this object as defined in the controller")]
	public int colorIndex = 0;

	// Use this for initialization
	void Start () 
	{
		//Get the sprite renderer of this game object
		objRenderer=GetComponent<SpriteRenderer>();

		// Get the game controller
		if (gameController == null)    gameController =(Controller)FindObjectOfType(typeof(Controller));
		//Get the dial controller
		if (ballMover == null)    ballMover =(BallMove)FindObjectOfType(typeof(BallMove));
	}

	void OnCollisionEnter2D(Collision2D other) {
		ballMover.currentBlockColor=colorIndex;
	}
		

	//Executes when the dial exits the circle walls
	void OnCollisionEnter2D(Collider2D other)
	{	 
		//Check if the dial and circle block colors match but the player failed to press the button on time
		if(ballMover.currentColor==colorIndex)
			gameController.GameOver();
	}

	public void SetColor()
	{
		// Set the objects color
		objRenderer.color=gameController.colorList[colorIndex];
	}
}
