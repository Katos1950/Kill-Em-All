using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    private string gameId = "4124718";
    private string bannerId = "banner";
    private string rewardedVideoId = "rewardedVideo";
    private string interstitialId = "interstitial";
    public bool testMode;
    //public Button showInterstitial;
    //public Button watchRewardedAd;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        //showInterstitial.interactable = Advertisement.IsReady(interstitialId);
        //watchRewardedAd.interactable = Advertisement.IsReady(rewardedVideoId);
        Advertisement.AddListener(this);

    }

    public void ShowInterstitial()
    {
        if(Advertisement.IsReady(interstitialId))
        {
            Advertisement.Show(interstitialId);
        }
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(rewardedVideoId);
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsReady(string placementId)
    {
        if(placementId == rewardedVideoId)
        {
            //watchRewardedAd.interactable = true;
        }
        if(placementId == interstitialId)
        {
            //showInterstitial.interactable = true;
        }
        if(placementId == bannerId)
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(bannerId);
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(placementId == rewardedVideoId)
        {
            if(showResult == ShowResult.Finished )
            {
                GetReward();
            }
            else if(showResult == ShowResult.Skipped)
            {

            }
            else if(showResult == ShowResult.Failed)
            {

            }
        }
    }

    public void ShowBanner()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(bannerId);
    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void GetReward()
    {

    }
}