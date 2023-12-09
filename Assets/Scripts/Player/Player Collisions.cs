using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    /// <summary>
    /// This class handles player collisions with world obects and informs the HUD class
    /// </summary>
    /// 

    public HUD hud;
    public bool swordcollected;
    public GameObject Wintext;
    public AudioSource WinSound2;
    public AudioSource Item1;
    public AudioSource music;
    //player movement class 
    public PlayerMovement playerMovement;

    private void Awake()
    {
        //get the playermovement class reference
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        swordcollected = false;

        //end of level reached
        if (collision.gameObject.tag == "Win")
        {
            Wintext.gameObject.SetActive(true);
            Debug.Log("End Reached");
            WinSound2.Play();
            Time.timeScale = 0;
            music.Pause();
            playerMovement.enabled =false;
        }

        //restart if hit spikes
        if (collision.gameObject.tag == "Spikes")
        {
           
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // gaining sword and destroying gameobject
        if (collision.gameObject.tag =="Sword")
        {
            Debug.Log("Sword Collected");
            Destroy(collision.gameObject);
            Item1.Play();
            swordcollected = true;

            //call the playermovement class to set doublejump true when sword is collected
            playerMovement.canDoubleJump = true;
        }

        //update the UI
        hud.UpdateInventoryUI(collision.gameObject.tag);

      
    }
  
}
