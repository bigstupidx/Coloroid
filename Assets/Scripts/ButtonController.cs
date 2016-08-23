using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	public void PlayGame() {
		SceneManager.LoadSceneAsync("GameScene");
	}
}
