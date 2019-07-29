
using UnityEngine;
using UnityEngine.SceneManagement;


public class screenmanager : MonoBehaviour
{
    public GameObject Playmenu;
    public GameObject Gameover;
    public GameObject scoreboard;
    public GameObject Hats;
    public Transform HatTranform;
    //public static bool freeze = false;




   /* public void gameover()
    {
        Debug.Log("gameover");
        Gameover.SetActive(true);
    } */
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
        scoreboard.SetActive(true);
        Gameover.SetActive(false);
        Time.timeScale = 0f;
        HatTranform.position = new Vector3(-1.35f ,3.97f ,-3.87f);
        HatTranform.rotation = Quaternion.Euler(-90f, -90f, 0f);
    }
    public void Restartscreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
