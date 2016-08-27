using UnityEngine;
using System.Collections;
#if CW_Admob
using GoogleMobileAds.Api;
#endif

/*
 * Download the package here - https://github.com/googleads/googleads-mobile-unity/releases
 * Get the Ad Units from here - https://www.google.com/admob/
*/

public class AdManager : MonoBehaviour 
{
	#if CW_Admob
	#if UNITY_ANDROID
	public string BannerAdUnitId = "INSERT_ANDROID_BANNER_AD_UNIT_ID_HERE";
	#elif UNITY_IPHONE
	public string BannerAdUnitId = "INSERT_IOS_BANNER_AD_UNIT_ID_HERE";
	#else
	public const string BannerAdUnitId = "unexpected_platform";
	#endif

	#if UNITY_ANDROID
	public string InterstitialAdUnitId = "INSERT_ANDROID_INTERSTITIAL_AD_UNIT_ID_HERE";
	#elif UNITY_IPHONE
	public string InterstitialAdUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
	#else
	public const string InterstitialAdUnitId = "unexpected_platform";
	#endif

	[Tooltip("After how many 'gameovers' should we show an interstitial ad?")]
	public int AdCounter;

	private int c;

	internal BannerView bannerView;
	internal InterstitialAd interstitial;

	private void Awake()
	{
		RequestBanner();
		RequestInterstitial();
	}

	private void Start()
	{
		c=AdCounter;
	}

	private void RequestBanner()
	{
		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(BannerAdUnitId, AdSize.Banner, AdPosition.Bottom);
	
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();

		// Load the banner with the request.
		bannerView.LoadAd(request);
	}

	internal void RequestInterstitial()
	{
		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(InterstitialAdUnitId);

		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();

		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}

	internal void ShowInterstitial()
	{
		if(AdCounter<=0)
		{
			if (interstitial.IsLoaded()) 
			{
				interstitial.Show();
				RequestInterstitial();

				//Reset the ad counter
				AdCounter=c;
			}
		}
		else if(AdCounter>0)
			AdCounter -=1;
	}

	void OnDisable()
	{
		bannerView.Destroy();
		interstitial.Destroy();
	}
	#endif
}