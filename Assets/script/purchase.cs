
using UnityEngine;
using UnityEngine.Purchasing;

public class purchase : MonoBehaviour
{
    const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
    public static string key = "X";
    public void BuyComplete(Product product)
    {
        Debug.Log("purchase complete");
        generate();
        Debug.Log(key);
        PlayerPrefs.SetString("key", key);
        PlayerPrefs.SetInt(key, 1);
        PlayerPrefs.Save();
    }
    public void BuyFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("purchase failed");
    }
  void generate()
    {
        for (int i = 0; i < 10; i++)
        {
           key += glyphs[Random.Range(0, glyphs.Length)];
        }
    }
}
