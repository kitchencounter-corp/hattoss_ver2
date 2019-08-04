
using UnityEngine;
using UnityEngine.SceneManagement;


public class screenmanager : MonoBehaviour
{
    public GameObject Playmenu;
    public GameObject Gameover;
    public GameObject scoreboard;
    public GameObject Hats;
    public Transform HatTranform;
   
    public void Playscreen()
    {
        Debug.Log("play");
        Playmenu.SetActive(false);
    
        Hats.SetActive(true);
        scoreboard.SetActive(true);
       
    }
    public void Resetscreen()
    {     
        Hats.SetActive(true);
        Gameover.SetActive(false);
        Time.timeScale = 0f;
        toss.respawn(HatTranform);
        adController.count++;
    }
    public void Restartscreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
