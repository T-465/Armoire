using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

// This class is used to store the player's attributes - might be better read in from a scriptable object
// A singleton might be better for this, but this is a quick and dirty way to get it working
public static class PlayerAttributes
{
    public static float plHealth = 100;
    public static float plMaxHealth = 100;
    public static float plSpeed = 100;
    public static float plMaxSpeed = 100;
    public static float plMinSpeed = 20;
    public static float plStamina = 100;
    public static float plMaxStamina = 100;
    public static float plHitPofloats = 10;
    public static float plScore = 0;
    public static float plLives = 3;
    public static float plLevel = 1;
    public static float plXP = 0;
    
    public static void Reset()
    {
        plHealth = 100;
        plMaxHealth = 100;
        plSpeed = 100;
        plMaxSpeed = 100;
        plMinSpeed = 20;
        plStamina = 100;
        plMaxStamina = 100;
        plHitPofloats = 10;
        plScore = 0;
        plLives = 3;
        plLevel = 1;
        plXP = 0;
    }

    public static void AddHealth(float amount)
    {
        plHealth += amount;
        if (plHealth > plMaxHealth)
        {
            plHealth = plMaxHealth;
        }
    }

    public static void AddSpeed(float amount)
    {
        plSpeed += amount;
        if (plSpeed > plMaxSpeed)
        {
            plSpeed = plMaxSpeed;
        }
    }

    public static void AddStamina(float amount)
    {
        plStamina += amount;
        if (plStamina > plMaxStamina)
        {
            plStamina = plMaxStamina;
        }
    }
    public static void AddDamage(float amount)
    {
        plHitPofloats += amount;
    }
    public static void AddScore(float amount)
    {
        plScore += amount;
    }
    public static void AddLives(float amount)
    {
        plLives += amount;
    }

    public static void AddLevel(float amount)
    {
        plLevel += amount;
    }

    public static void AddXP(float amount)
    {
        plXP += amount;
    }

    public static void AddMaxHealth(float amount)
    {
        plMaxHealth += amount;
    }

    public static void AddMaxSpeed(float amount)
    {
        plMaxSpeed += amount;
    }

    public static void AddMaxStamina(float amount)
    {
        plMaxStamina += amount;
    }

    public static void ResetHealth()
    {
        plHealth = plMaxHealth;
    }
    public static void ResetSpeed()
    {
        plSpeed = plMaxSpeed;
    }
    public static void ResetStamina()
    {
        plStamina = plMaxStamina;
    }
    public static void ResetDamage()
    {
        plHitPofloats = 10;
    }
}
