using UnityEngine;
using System.Collections;

public class ActivateOnEnable : MonoBehaviour {

	public EasyTween EasyTweenStart;

	public IEnumerator RunAnimation () 
	{
		yield return new WaitForEndOfFrame();
		EasyTweenStart.OpenCloseObjectAnimation();
	}
}
