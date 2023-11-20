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

    //player movement class 
    private PlayerMovement playerMovement;

    private void Awake()
    {
        //get the playermovement class reference
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        swordcollected = false;


       if (collision.gameObject.tag == "Spikes")
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


        }
        if (collision.gameObject.tag =="Sword")
        {
            Debug.Log("Sword Collected");
            //destroy the sword game object
            Destroy(collision.gameObject);

            swordcollected = true;

            //call the playermovement class to set doublejump true when sword is collected
            playerMovement.canDoubleJump = true;
            
        }

        //update the UI
        hud.UpdateInventoryUI(collision.gameObject.tag);

       
    }
  
}
