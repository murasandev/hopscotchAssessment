using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameOver gameOverCS;

    public int health = 100;
    private float tickTimer;
    private float tickCD = .05f;
    public int totalDamage;
    public bool takingDamage;

    private bool gameOver;

    private void Update()
    {
        ReduceHealth();

        if (health <= 0 && !gameOver)
        {
            GameOver();
            gameOver = true;
        }
    }
    public void DamageTaken(int damageTaken)
    {
        totalDamage += damageTaken;
        takingDamage = true;
    }

    private void ReduceHealth()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer > tickCD && totalDamage >= 0 && takingDamage)
        {
            health--;
            slider.value = health;
            totalDamage--;
        }
        else if (totalDamage < 1)
        {
            takingDamage = false;
        }
    }

    private void GameOver()
    {
        //Ends game in GameOver.cs
        gameOverCS.gameOverBool = true;
    }
}
