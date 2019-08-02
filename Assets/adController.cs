
using UnityEngine;
using UnityEngine.Monetization;

public class adController : MonoBehaviour
{
    private string store_id = "3237816";
    private string bannder_id = "Banner";
    public bool testMode = true;
    void Start()
    {
        Monetization.Initialize(store_id, testMode);
      
    }

    
   void Update()
    {
        if  (Monetization.IsReady(bannder_id))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(bannder_id) as ShowAdPlacementContent;
            if (ad != null)
            {
                ad.Show();
            }
        }

    }
}
