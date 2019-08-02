using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class adController : MonoBehaviour
{

    public string gameId = "3237816";
    public string placementId = "Banner";
    public bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);
    }
}
