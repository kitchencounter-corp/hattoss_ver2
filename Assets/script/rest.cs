using System.Collections;
using UnityEngine;

public class rest : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject Score;
    public GameObject Hat;
     public static bool collided = true;
    IEnumerator OnTriggerEnter(Collider other)
    {
      //  Debug.Log("floor1 = " +collided);
        if (collided && other.gameObject == Hat)
        {
           // Debug.Log("floor hit");
            yield return new WaitForSeconds(1f);
            Score.SetActive(false);
     
            GameOver.SetActive(true);
            score.Scr = 0;
            collided = false;
            Debug.Log(collided);
            Hat.SetActive(false);
           
        }
    }
}
