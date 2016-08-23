using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI; 

public class MenuManager : MonoBehaviour {
	public GameObject pausePanel;

	void Start() {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale = 0; // pauznutie hry
			GameObject.FindGameObjectWithTag ("SwitchColor").GetComponent<SwitchColor>().SetScreenLock(false);
			pausePanel.SetActive(true);
		}
	}

	public void PauseGame() {
		Time.timeScale = 0; // pauznutie hry
		GameObject.FindGameObjectWithTag ("SwitchColor").GetComponent<SwitchColor>().SetScreenLock(false);
		pausePanel.SetActive(true);
	}

	public void EndGame() {
		int currentScene = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene (currentScene, LoadSceneMode.Single);
	}

	public void StartGame() {
		//menuPanel.SetActive(false);
		//Time.timeScale = 1; // start hry
	}

	public void ExitGame() {
		Application.Quit ();
	}
}