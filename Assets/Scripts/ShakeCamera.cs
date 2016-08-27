using System.Collections;
using UnityEngine;

public class ShakeCamera:MonoBehaviour
{
	// The original position of the camera
	public Vector3 cameraOrigin;
	
	// How violently to shake the camera
	public Vector3 strength;
	private Vector3 strengthDefault;
	
	// How quickly to settle down from shaking
	public float decay = 0.8f;
	
	// How many seconds to shake
	public float shakeTime = 1f;
	private float shakeTimeDefault;

	// Is this effect playing now?
	public bool isShaking = false;

	void Start()
	{
		cameraOrigin = transform.position;

		strengthDefault = strength;
		
		shakeTimeDefault = shakeTime;
	}

	/// Update is called every frame, if the MonoBehaviour is enabled.
	void Update()
	{
		if( isShaking == true )
		{
			if( shakeTime > 0 )
			{		
				shakeTime -= Time.deltaTime;
				
				Vector3 tempPosition = Camera.main.transform.position;

				// Move the camera in all directions based on strength
				tempPosition.x = cameraOrigin.x + Random.Range(-strength.x, strength.x);
				tempPosition.y = cameraOrigin.y + Random.Range(-strength.y, strength.y);
				tempPosition.z = cameraOrigin.z + Random.Range(-strength.z, strength.z);

				Camera.main.transform.position = tempPosition;
				
				// Gradually reduce the strength value
				strength *= decay;
			}
			else if( Camera.main.transform.position != cameraOrigin )
			{
				shakeTime = 0;
				
				// Reset the camera position
				Camera.main.transform.position = cameraOrigin;
				
				isShaking = false;

				strength = strengthDefault;

				shakeTime = shakeTimeDefault;

			}
		}
	}

	/// Starts the shake of the camera.
	public void StartShake()
	{
		isShaking = true;
		
		strength = strengthDefault;
		
		shakeTime = shakeTimeDefault;
	}
}