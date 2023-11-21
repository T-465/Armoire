using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    //hud sprites
    public SpriteRenderer sword;

    private void Awake()
    {
        sword.enabled = false;
    }
    private void Start()
    {

    }
    public void UpdateInventoryUI(string itemTag)
    {

        // sword added to hud
        if (itemTag == "Sword")
        {
            sword.enabled = true;
        }


    }


}
