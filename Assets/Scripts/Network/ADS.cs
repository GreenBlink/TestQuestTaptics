using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class ADS : MonoBehaviour
{
    private RewardBasedVideoAd rewardBasedVideo;

    void Start()
    {
        MobileAds.Initialize("ca-app-pub-8031020776871928~6802399658");

        rewardBasedVideo = RewardBasedVideoAd.Instance;

        AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).AddTestDevice("3E6F127BD72965F2").Build();
        rewardBasedVideo.LoadAd(request, "ca-app-pub-3940256099942544~3347511713");

        //rewardBasedVideo.OnAdLoaded += OnAdLoaded;
        rewardBasedVideo.OnAdClosed += OnAdClosed;
        rewardBasedVideo.OnAdFailedToLoad += OnAdFailed;
    }

    public void Show()
    {
        if (rewardBasedVideo.IsLoaded())
            rewardBasedVideo.Show();
        else
            GameController.instance.AddTime();
    }

    public void OnAdLoaded(object sender, System.EventArgs args)
    {
        rewardBasedVideo.Show();
    }

    public void OnAdFailed(object sender, AdFailedToLoadEventArgs args)
    {
        UIController.instance.errorText.text = string.Concat("Video loading: ", args.Message);
    }

    public void OnAdClosed(object sender, System.EventArgs args)
    {
        GameController.instance.AddTime();
    }
}
