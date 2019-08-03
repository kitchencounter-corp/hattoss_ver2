﻿
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
        scoreboard.SetActive(true);
        Gameover.SetActive(false);
        Time.timeScale = 0f;
        // HatTranform.position = new Vector3(-1.9f ,3.97f ,-3.87f);
        //HatTranform.rotation = Quaternion.Euler(-90f, -90f, 0f);
        toss.respawn(HatTranform);
    }
    public void Restartscreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}