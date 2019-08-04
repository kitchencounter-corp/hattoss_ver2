
using UnityEngine;
using UnityEngine.Purchasing;

public class purchase : MonoBehaviour
{
   
    public void BuyComplete(Product product)
    {
        Debug.Log("purchase complete");
        PlayerPrefs.SetInt("adsremove", 1);
        PlayerPrefs.Save();
    }
    public void BuyFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("purchase failed");
    }
   
}
