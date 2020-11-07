using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class Admanager : MonoBehaviour
{
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
 public static Admanager instance;
 private string appID = "ca-app-pub-7514190994015104~7098710564";

 private BannerView bannerView;
 private string bannerID = "ca-app-pub-7514190994015104/9444660547";

 private InterstitialAd fullscreenAd;
 private string fullscreenAdID = "ca-app-pub-7514190994015104/1566170528";

 private RewardBasedVideoAd rewardedAd;
 private string rewardedAdID = "ca-app-pub-7514190994015104/2328587856";

 private void Awake()
 {
  if (instance == null)
  {
      instance = this;
  } else {
Destroy(this);
  }
 }

 private void Start()
{
   MobileAds.Initialize(appID);
    RequestfullscreenAd();
    rewardedAd = RewardBasedVideoAd.Instance;
    RequestRewardedAd();
    rewardedAd.OnAdLoaded += HandleRewardBasedVideoLoaded;

    rewardedAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;

    rewardedAd.OnAdRewarded += HandleRewardBasedVideoRewarded;

    rewardedAd.OnAdClosed += HandleRewardBasedVideoClosed;
}

 public void RequestBanner()
 {
     bannerView = new BannerView(bannerID,AdSize.Banner,AdPosition.Bottom);
     AdRequest request = new AdRequest.Builder().Build();
     bannerView.LoadAd(request);
     bannerView.Show();
 }

  public void HideBanner()
  {
   bannerView.Hide();
  }

  public void RequestfullscreenAd()
  {
   fullscreenAd = new InterstitialAd(fullscreenAdID);
   AdRequest request = new AdRequest.Builder().Build();
   fullscreenAd.LoadAd(request);     
  }

  public void showfullscreenAd()
  {
   if (fullscreenAd.IsLoaded())
{
fullscreenAd.Show();
}
else
{
Debug.Log("full screen ad not loaded");
}
  }

  public void RequestRewardedAd()
  {
      AdRequest request = new AdRequest.Builder().Build();
      rewardedAd.LoadAd(request, rewardedAdID);
  }

  public void ShowRewardedAd()
  {
      if (rewardedAd.IsLoaded())
      {
          rewardedAd.Show();
      }
      else
      {
          Debug.Log("Rewarded ad not loaded");
      }
  }


  public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
  {
      Debug.Log("Rewarded Video ad loaded successfully");

  }

  public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
  {
      Debug.Log("Failed to load rewarded video ad : " + args.Message);


  }



  public void HandleRewardBasedVideoRewarded(object sender, Reward args)
  {
      string type = args.Type;
      double amount = args.Amount;
      Debug.Log("You have been rewarded with  " + amount.ToString() + " " + type);

      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      if (levelToUnlock > PlayerPrefs.GetInt("levelReached", 1))
      {
          PlayerPrefs.SetInt("levelReached", levelToUnlock);
      }
  }


  public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
  {
      Debug.Log("Rewarded video has closed");
      RequestRewardedAd();

  }
  
}
