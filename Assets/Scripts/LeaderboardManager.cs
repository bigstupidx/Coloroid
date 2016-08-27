using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;
#if CW_Leaderboard && UNITY_ANDROID
using GooglePlayGames;
#endif

public class LeaderboardManager : MonoBehaviour
{
	#if CW_Leaderboard && UNITY_ANDROID
	private Controller GameController;

	public string EasyLeaderboard = "INSERT_EASY_LEADERBOARD_ID_HERE";
	public string MediumLeaderboard = "INSERT_MEDIUM_LEADERBOARD_ID_HERE";
	public string HardLeaderboard = "INSERT_HARD_LEADERBOARD_ID_HERE";

	void Start()
	{
		PlayGamesPlatform.Activate();
		GameController=(Controller)FindObjectOfType(typeof(Controller));
		SignIn();
	}

	public void SignIn()
	{
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
		});
	}

	public void PostScore(int highscore)
	{
		if(Social.localUser.authenticated)
		{
			long score = (long)(highscore*1);

			if(GameController.Diff==Level.Easy)
			{
				Social.ReportScore(score, EasyLeaderboard, (bool success) => {
       			 // handle success or failure
    			});
			}

			else if(GameController.Diff==Level.Medium)
			{
				Social.ReportScore(score, MediumLeaderboard, (bool success) => {
					// handle success or failure
				});
			}

			else if(GameController.Diff==Level.Hard)
			{
				Social.ReportScore(score, HardLeaderboard, (bool success) => {
					// handle success or failure
				});
			}
		}
	}

	public void ShowLeaderboard()
	{
		if(Social.localUser.authenticated)
			Social.ShowLeaderboardUI();
		else
			SignIn();
	}
#endif
}