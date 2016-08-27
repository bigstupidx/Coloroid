using UnityEngine;
using UnityEditor;

public class Menu: Editor {

	const string CWAds = "CW_Admob";
	const string CWLeaderboard = "CW_Leaderboard";

	[MenuItem("Tools/Mintonne/Configuration/Configure Admob")]
	static void Admob()
	{
#if UNITY_ANDROID
		var stringAds = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

		if(stringAds.Contains(CWLeaderboard))
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, CWLeaderboard + ";" + CWAds);
		else			
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, CWAds);
#elif UNITY_IOS
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, CWAds);
#endif
	}

	[MenuItem("Tools/Mintonne/Configuration/Configure Leaderboards")]
	static void Leaderboards()
	{
		var stringLd = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

		if(stringLd.Contains(CWAds))
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, CWLeaderboard + ";" + CWAds);
		else			
			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, CWLeaderboard);	
	}

	[MenuItem("Tools/Mintonne/Configuration/Reset Configurations")]
	static void Reset()
	{
		#if UNITY_ANDROID
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, "");
		#elif UNITY_IOS
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, "");
		#endif
	}

	[MenuItem("Tools/Mintonne/Documentation")]
	static void Documentation()
	{
		string path = "File://" + Application.dataPath + "/Crazy Wheel/GAME DOCUMENTATION.pdf";
		Application.OpenURL(path);
		Debug.Log("Opening file at " + path);
	}

	[MenuItem("Tools/Mintonne/Contact Support")]
	static void Support()
	{
		Application.OpenURL("mailto:mintonne@gmail.com");
	}

	[MenuItem("Tools/Mintonne/Rate Crazy Wheel")]
	static void Rate()
	{
		UnityEditorInternal.AssetStore.Open("content/58625"); 
	}

	[MenuItem("Tools/Mintonne/Request A Feature")]
	static void Request()
	{
		Application.OpenURL("mailto:mintonne@gmail.com?subject=Crazy Wheel Feature Request");
	}

	[MenuItem("Tools/Mintonne/More Unity Assets")]
	static void More()
	{
		Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/search/page=1/sortby=popularity/query=publisher:18385");
	}
}