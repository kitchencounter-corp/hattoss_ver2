using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;

public class adController : MonoBehaviour
{

    public string gameId = "3237816";
    public string bannerId = "Banner";
    public string videoId = "video";
    public bool testMode = true;
    public GameObject buybutton;
    public static int count = 0;
    public GameObject hat;

    void Start()
    {
        string check = PlayerPrefs.GetString("key","X");
        Debug.Log(check);
        if (PlayerPrefs.HasKey(check) == false)
        {

            Advertisement.Initialize(gameId, testMode);
            Monetization.Initialize(gameId, testMode);
            StartCoroutine(ShowBannerWhenReady());
            StartCoroutine(ShowAdWhenReady());
        }
        else
        {
            buybutton.SetActive(false);
        }
    }

    private IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(bannerId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("showbanner");
        Advertisement.Banner.Show(bannerId);
    }
    private IEnumerator ShowAdWhenReady()
    {
        count = 0;
        while (!Monetization.IsReady(videoId))
        {
            yield return new WaitForSeconds(0.5f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(videoId) as ShowAdPlacementContent;

        if (ad != null)
        {
            Debug.Log("showad");
            ad.Show();
        }
       
    }
    private void Update()
    {
        if (count ==5 && PlayerPrefs.HasKey("adsremove") == false )
        {
            StartCoroutine(ShowAdWhenReady());
        }
    }

}
